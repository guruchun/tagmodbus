using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace TagModbusSvr
{
    public partial class ViewData : DockContent
    {
        private static readonly ILog log = LogManager.GetLogger("Console");
        private BindingSource bindingSrc = new();

        public ViewData()
        {
            InitializeComponent();
        }

        private void ViewData_Load(object sender, EventArgs e)
        {
            try
            {
                // Apply theme to toolstrip
                new VS2015BlueTheme().ApplyTo(this.toolStrip);

                // Bind to TagStore DataTable
                dgvTags.SuspendLayout();
                bindingSrc.DataSource = TagStore.Instance.Table.DefaultView;
                dgvTags.DataSource = bindingSrc;

                // Configure columns
                if (dgvTags.Columns.Count > 0)
                {
                    dgvTags.Columns["Tag"].Width = 100;
                    dgvTags.Columns["Tag"].ReadOnly = true;
                    dgvTags.Columns["Address"].Width = 50;
                    dgvTags.Columns["Address"].Visible = false;
                    dgvTags.Columns["Value"].Width = 60;
                    dgvTags.Columns["Value"].ReadOnly = false;
                    dgvTags.Columns["Value"].DefaultCellStyle.Format = "0.00##";
                    dgvTags.Columns["Unit"].Width = 40;
                    dgvTags.Columns["Unit"].ReadOnly = true;
                    dgvTags.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvTags.Columns["Description"].ReadOnly = true;
                    dgvTags.Columns["Updated"].Width = 60;
                    dgvTags.Columns["Updated"].ReadOnly = true;
                    dgvTags.Columns["Updated"].DefaultCellStyle.Format = "HH:mm:ss";

                    // Disable sorting for all columns
                    foreach (DataGridViewColumn col in dgvTags.Columns)
                        col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dgvTags.ResumeLayout();

                // Enable double buffering
                typeof(DataGridView)
                    .GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                    ?.SetValue(dgvTags, true);

                // Hide array editing panel initially
                tableLayoutPanel.RowStyles[tableLayoutPanel.RowCount - 1].Height = 0;

                // Load default data file if available
                string defaultData = Path.Combine(Application.StartupPath, "data", "PMBG2_defaults.json");
                if (File.Exists(defaultData))
                    LoadDataFile(defaultData);
            }
            catch (Exception ex)
            {
                log.Error($"ViewData_Load error: {ex.Message}");
            }
        }

        #region Search and Filter

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            try
            {
                if (string.IsNullOrEmpty(txtSearch.Text.Trim()))
                    bindingSrc.RemoveFilter();
                else
                    bindingSrc.Filter = $"[Tag] LIKE '%{txtSearch.Text}%' OR [Description] LIKE '%{txtSearch.Text}%'";
            }
            catch (Exception ex)
            {
                log.Error($"Search error: {ex.Message}");
            }
        }

        #endregion

        #region JSON Import/Export

        private async void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                using var dialog = new SaveFileDialog
                {
                    Filter = "JSON Files (*.json)|*.json",
                    DefaultExt = "json",
                    RestoreDirectory = true,
                    InitialDirectory = Path.Combine(Application.StartupPath, "data"),
                };

                if (dialog.ShowDialog() != DialogResult.OK) return;

                var sb = new StringBuilder();
                using var sw = new StringWriter(sb);
                using var writer = new JsonTextWriter(sw)
                {
                    Formatting = Formatting.Indented,
                    Indentation = 2
                };

                writer.WriteStartObject();
                foreach (DataRow row in TagStore.Instance.Table.Rows)
                {
                    string tagName = $"{row["Tag"]}";
                    string tagValue = $"{row["Value"]}";
                    if (string.IsNullOrEmpty(tagName) || string.IsNullOrEmpty(tagValue))
                        continue;

                    writer.WritePropertyName(tagName);
                    if (tagValue.Contains(','))
                    {
                        double[] dblValues = Array.ConvertAll(tagValue.Split(','), double.Parse);
                        new JArray(dblValues).WriteTo(writer);
                    }
                    else if (double.TryParse(tagValue, out double dblValue))
                    {
                        writer.WriteValue(dblValue);
                    }
                    else
                    {
                        writer.WriteValue(tagValue);
                    }
                }
                writer.WriteEndObject();

                await File.WriteAllTextAsync(dialog.FileName, sb.ToString());
            }
            catch (Exception ex)
            {
                log.Error($"Export error: {ex.Message}");
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                using var dialog = new OpenFileDialog
                {
                    Filter = "JSON Files (*.json)|*.json",
                    DefaultExt = "json",
                    RestoreDirectory = true,
                    InitialDirectory = Path.Combine(Application.StartupPath, "data"),
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                    LoadDataFile(dialog.FileName);
            }
            catch (Exception ex)
            {
                log.Error($"Import error: {ex.Message}");
            }
        }

        private void LoadDataFile(string dataFile)
        {
            if (!File.Exists(dataFile)) return;

            try
            {
                using var sr = new StreamReader(dataFile);
                using var jsonReader = new JsonTextReader(sr);
                var jsonData = JToken.ReadFrom(jsonReader) as JObject;
                if (jsonData == null) return;

                foreach (JProperty prop in jsonData.Properties())
                {
                    string value = string.Join(",", JArray.FromObject(prop.Values()));
                    TagStore.Instance.SetValue(prop.Name, value);
                }
            }
            catch (Exception ex)
            {
                log.Error($"LoadDataFile error: {ex.Message}");
            }
        }

        #endregion

        #region DataGridView Events

        private void dgvDatas_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Only allow editing Value column
            if (e.ColumnIndex != dgvTags.Columns["Value"]?.Index)
                e.Cancel = true;
        }

        private void dgvDatas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

                // Show array editor for comma-separated values
                if (e.ColumnIndex == dgvTags.Columns["Value"]?.Index)
                {
                    string tagValue = $"{dgvTags[e.ColumnIndex, e.RowIndex].Value}";
                    if (tagValue.Contains(","))
                    {
                        tableLayoutPanel.RowStyles[tableLayoutPanel.RowCount - 1].SizeType = SizeType.AutoSize;

                        dgvDatasArray.SuspendLayout();
                        dgvDatasArray.Rows.Clear();
                        dgvDatasArray.Columns.Clear();

                        var values = tagValue.Split(',');
                        for (int i = 0; i < values.Length; i++)
                            dgvDatasArray.Columns.Add("", "");

                        // Current values (read-only)
                        var idx = dgvDatasArray.Rows.Add(values);
                        dgvDatasArray.Rows[idx].DefaultCellStyle.BackColor = Color.LightGray;
                        dgvDatasArray.Rows[idx].ReadOnly = true;

                        // Editable row
                        if (!dgvTags[e.ColumnIndex, e.RowIndex].ReadOnly)
                            dgvDatasArray.Rows.Add(values);

                        dgvDatasArray.ResumeLayout();
                    }
                    else
                    {
                        tableLayoutPanel.RowStyles[tableLayoutPanel.RowCount - 1].SizeType = SizeType.Absolute;
                        tableLayoutPanel.RowStyles[tableLayoutPanel.RowCount - 1].Height = 0;
                    }
                }
                else
                {
                    tableLayoutPanel.RowStyles[tableLayoutPanel.RowCount - 1].SizeType = SizeType.Absolute;
                    tableLayoutPanel.RowStyles[tableLayoutPanel.RowCount - 1].Height = 0;
                }
            }
            catch (Exception ex)
            {
                log.Error($"CellEnter error: {ex.Message}");
            }
        }

        private void dgvDatas_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null)
                log.Info($"DataError: {e.Exception.Message}");
        }

        private void dgvDatas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Access-based styling can be added here if needed
        }

        #endregion

        #region Array Editor

        private void btnArrayWrite_Click(object sender, EventArgs e)
        {
            try
            {
                var tag = $"{dgvTags[0, dgvTags.CurrentCell.RowIndex].Value}";
                var values = dgvDatasArray.Rows[1].Cells
                    .Cast<DataGridViewCell>()
                    .Select(x => $"{x.Value}");
                var value = string.Join(",", values);

                // Update TagStore -> triggers Modbus write via RowChanged
                TagStore.Instance.SetValue(tag, value);
            }
            catch (Exception ex)
            {
                log.Error($"ArrayWrite error: {ex.Message}");
            }
        }

        #endregion

        private void ShowAddress_Click(object sender, EventArgs e)
        {
            if (dgvTags.Columns["Address"] != null)
                dgvTags.Columns["Address"].Visible = !dgvTags.Columns["Address"].Visible;
        }
    }
}
