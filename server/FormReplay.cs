using CsvHelper;
using CsvHelper.Configuration;
using log4net;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace TagModbusSvr
{
    /// <summary>
    /// CSV Replay form - loads CSV data files and plays them row by row,
    /// updating TagStore values which are then synced to Modbus registers.
    /// </summary>
    public partial class FormReplay : DockContent
    {
        private static readonly ILog log = LogManager.GetLogger("Console");

        private DataTable _playTable = new();
        private Timer _timer = new();
        private int _selectedRow;
        private int _skipRows = 1;

        public FormReplay()
        {
            InitializeComponent();
        }

        private void FormReplay_Load(object sender, EventArgs e)
        {
            _timer.Interval = 1000;
            _timer.Tick += Timer_Tick;

            // List CSV files in data folder
            string dir = Path.Combine(Application.StartupPath, "data");
            if (Directory.Exists(dir))
            {
                string[] files = Directory.GetFiles(dir, "*.csv");
                foreach (string file in files)
                    cbCsvFile.Items.Add(Path.GetFileName(file));
                if (cbCsvFile.Items.Count > 0)
                    cbCsvFile.SelectedIndex = 0;
            }

            dgvReplay.EnableHeadersVisualStyles = false;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (cbCsvFile.SelectedItem == null) return;

            string filePath = Path.Combine(Application.StartupPath, "data", cbCsvFile.Text);
            if (!File.Exists(filePath))
            {
                log.Error($"File not found: {filePath}");
                return;
            }

            try
            {
                using var reader = new StreamReader(filePath);
                using var csv = new CsvReader(reader,
                    new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = true });
                using var dr = new CsvDataReader(csv);

                dgvReplay.DataSource = null;
                _playTable.Clear();
                _playTable.Columns.Clear();
                _playTable.Load(dr);
                _selectedRow = 0;
                txtRows.Text = _playTable.Rows.Count.ToString();

                dgvReplay.DataSource = _playTable;

                // Disable column sorting
                foreach (DataGridViewColumn col in dgvReplay.Columns)
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            catch (Exception ex)
            {
                log.Error($"CSV load error: {ex.Message}");
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (btnPlay.Text == "Play")
            {
                if (_playTable.Rows.Count == 0 || _selectedRow >= _playTable.Rows.Count)
                {
                    MessageBox.Show("Please [Load] a replay file first.", "Replay",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Clear row highlights
                foreach (DataGridViewRow row in dgvReplay.Rows)
                    row.DefaultCellStyle.BackColor = Color.Empty;

                btnPlay.Text = "Stop";
                _timer.Start();
            }
            else
            {
                btnPlay.Text = "Play";
                _timer.Stop();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_selectedRow >= dgvReplay.RowCount)
            {
                _timer.Stop();
                btnPlay.Text = "Play";
                return;
            }

            var record = dgvReplay.Rows[_selectedRow];
            record.DefaultCellStyle.BackColor = Color.LightBlue;

            // Update TagStore with current row values
            for (int i = 0; i < record.Cells.Count; i++)
            {
                string tag = dgvReplay.Columns[i].HeaderText;
                string value = record.Cells[i].Value?.ToString() ?? "";

                // Convert "[0/0/0/0/0]" format to "0,0,0,0,0"
                if (value.StartsWith('[') && value.EndsWith(']'))
                {
                    value = value[1..^1].Replace("/", ",");
                }

                TagStore.Instance.SetValue(tag, value);
            }

            // Advance to next row
            _selectedRow += _skipRows;

            // Scroll to current row
            if (_selectedRow < dgvReplay.RowCount)
            {
                dgvReplay.ClearSelection();
                dgvReplay.Rows[_selectedRow].Selected = true;
                if (_selectedRow > 5)
                    dgvReplay.FirstDisplayedScrollingRowIndex = _selectedRow - 5;
            }
        }

        private void txtSkipRows_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtSkipRows.Text, out int skip) && skip > 0)
                _skipRows = skip;
        }

        private void dgvReplay_SelectionChanged(object sender, EventArgs e)
        {
            // Allow manual row selection when not playing
            if (btnPlay.Text == "Play" && dgvReplay.SelectedRows.Count > 0)
                _selectedRow = dgvReplay.SelectedRows[0].Index;
        }

        private void txtInterval_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtInterval.Text, out int interval) && interval >= 100)
                _timer.Interval = interval;
        }
    }
}
