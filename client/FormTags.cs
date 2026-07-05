using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using NModbus;
using TagModbusLib;
using log4net;

namespace TagModbus
{
    /// <summary>
    /// Tag list view - displays all tags from Modbus Map.
    /// Supports search filtering and value editing with Modbus write-back.
    /// </summary>
    public class FormTags : DockContent
    {
        private static readonly ILog log = LogManager.GetLogger("Console");

        private DataGridView dgvTags;
        private TextBox txtSearch;
        private BindingSource bindingSource;
        private ToolStrip toolStrip;

        // Reference to modbus master for write operations
        private Func<IModbusMaster> getModbusMaster;
        private Func<byte> getUnitId;

        public FormTags(Func<IModbusMaster> masterProvider, Func<byte> unitIdProvider)
        {
            getModbusMaster = masterProvider;
            getUnitId = unitIdProvider;
            InitializeUI();
        }

        private void InitializeUI()
        {
            Text = "Tags";
            DockAreas = DockAreas.DockRight | DockAreas.DockLeft | DockAreas.Float | DockAreas.Document;
            HideOnClose = true;
            Font = new Font("Segoe UI", 9F);

            // ToolStrip with search
            toolStrip = new ToolStrip();
            var lblSearch = new ToolStripLabel("Search:");
            var txtSearchItem = new ToolStripTextBox("txtSearch") { Size = new Size(150, 23) };
            txtSearchItem.KeyDown += TxtSearch_KeyDown;
            toolStrip.Items.Add(lblSearch);
            toolStrip.Items.Add(txtSearchItem);
            Controls.Add(toolStrip);

            // DataGridView
            dgvTags = new DataGridView
            {
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = SystemColors.Window,
                RowHeadersVisible = false,
            };

            // Enable double buffering
            typeof(DataGridView)
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(dgvTags, true);

            dgvTags.CellValueChanged += DgvTags_CellValueChanged;
            dgvTags.CellEndEdit += DgvTags_CellEndEdit;
            Controls.Add(dgvTags);
            dgvTags.BringToFront();

            // Binding source
            bindingSource = new BindingSource();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Bind to TagStore's DataTable
            bindingSource.DataSource = TagStore.Instance.Table.DefaultView;
            dgvTags.DataSource = bindingSource;

            // Configure columns
            if (dgvTags.Columns.Count > 0)
            {
                dgvTags.Columns["Tag"].Width = 150;
                dgvTags.Columns["Tag"].ReadOnly = true;
                dgvTags.Columns["Value"].Width = 80;
                dgvTags.Columns["Value"].ReadOnly = false; // editable
                dgvTags.Columns["Unit"].Width = 40;
                dgvTags.Columns["Unit"].ReadOnly = true;
                dgvTags.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvTags.Columns["Description"].ReadOnly = true;
                dgvTags.Columns["Updated"].Width = 70;
                dgvTags.Columns["Updated"].ReadOnly = true;
                dgvTags.Columns["Updated"].DefaultCellStyle.Format = "HH:mm:ss";
            }

            // Disable sorting for all columns
            foreach (DataGridViewColumn col in dgvTags.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            string text = ((ToolStripTextBox)sender).Text.Trim();
            if (string.IsNullOrEmpty(text))
                bindingSource.RemoveFilter();
            else
                bindingSource.Filter = $"[Tag] LIKE '%{text}%' OR [Description] LIKE '%{text}%'";
        }

        private void DgvTags_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Commit the edit to trigger CellValueChanged
            dgvTags.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DgvTags_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvTags.Columns[e.ColumnIndex].Name != "Value") return;

            try
            {
                string tag = dgvTags.Rows[e.RowIndex].Cells["Tag"].Value?.ToString() ?? "";
                string newValue = dgvTags.Rows[e.RowIndex].Cells["Value"].Value?.ToString() ?? "";

                if (string.IsNullOrEmpty(tag)) return;

                // Write to Modbus device
                var master = getModbusMaster();
                byte unitId = getUnitId();
                if (master == null)
                {
                    log.Debug("Cannot write: not connected.");
                    return;
                }

                // Find register info from TagStore
                if (!TagStore.Instance.TagIndex.TryGetValue(tag, out var regDef))
                {
                    log.Debug($"Tag '{tag}' not found in map.");
                    return;
                }

                // Convert value and write
                ushort address = (ushort)regDef.Address;
                int scale = regDef.Scale > 0 ? regDef.Scale : 1;

                if (double.TryParse(newValue, out double dval))
                {
                    ushort rawValue = (ushort)(dval * scale);
                    master.WriteSingleRegister(unitId, address, rawValue);
                    log.Debug($"Write: tag={tag}, addr={address}, value={rawValue}");

                    // Update TagStore
                    TagStore.Instance.SetValue(tag, newValue);
                }
            }
            catch (Exception ex)
            {
                log.Error($"Tag write error: {ex.Message}");
            }
        }
    }
}
