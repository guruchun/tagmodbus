using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using TagModbusLib;

namespace TagModbusSvr
{
    public partial class FormServer : DockContent
    {
        // static members
        private static readonly ILog log = LogManager.GetLogger("Console");

        // private members
        private ModbusServerWrapper _modbusServer;
        private bool _preventRefresh = false;
        private string _mapName;
        private ConnectionSettings _connSettings;

        public FormServer()
        {
            InitializeComponent();

            // modbus server
            _modbusServer = ModbusServerWrapper.getInstance();

            // for TagTable changed
            TagStore.Instance.Table.RowChanged += OnTagTableRowChanged;
            // for ModbusServer's Registers changed
            _modbusServer.RegisterChanged += OnServerRegsChanged;
        }

        // TagTable's RowChanged
        private void OnTagTableRowChanged(object sender, DataRowChangeEventArgs e)
        {
            string tag = e.Row["Tag"]?.ToString() ?? "";
            string value = e.Row["Value"]?.ToString() ?? "";
            if (string.IsNullOrEmpty(tag) || string.IsNullOrEmpty(value))
                return;

            // Find register info from TagStore index
            if (!TagStore.Instance.TagIndex.TryGetValue(tag, out var regDef))
                return;

            try
            {
                ushort address = (ushort)regDef.Address;
                string dataType = regDef.DataType ?? "U16";
                string format = regDef.Format ?? "ABCD";
                int scale = regDef.Scale > 0 ? regDef.Scale : 1;

                if (dataType == "STR" || dataType == "CHR")
                {
                    // Use legacy MapHelper for string types
                    _modbusServer.SetValue(tag, value);
                }
                else
                {
                    // Numeric: convert value(s) to registers
                    double[] values = value.Split(',')
                        .Select(v => double.TryParse(v, out double d) ? d : 0.0)
                        .ToArray();
                    ushort[] regs = ModbusMapHelper.ConvertToRegisters(values, dataType, format, scale);
                    Array.Copy(regs, 0, _modbusServer.RegValues, address, regs.Length);
                    _modbusServer.SyncRegValuesToDataStore();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"OnTagTableRowChanged error: tag={tag}, {ex.Message}");
            }
        }

        private void OnServerRegsChanged(object sender, DataChangedEventArgs e)
        {
            Debug.WriteLine("server regs changed, " + e.Address + ", " + e.Value);

            //// update TagTable, but remove handler to prevent infinite loop
            //string[] addrParts = e.Address.Split(':');
            //string model = addrParts[0];        // BIT, REG
            //string address = addrParts[1];
            //Datas.Instance.TagTable.RowChanged -= OnTagTableRowChanged;
            //// FIXME: address -> tag -> convert value
            //Datas.Instance.SetValue(tag, values);
            //Datas.Instance.TagTable.RowChanged += OnTagTableRowChanged;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            // Initial button state
            btnStop.Enabled = false;

            // Load connection settings from config
            _connSettings = new ConnectionSettings
            {
                Mode = AppConfig.Modbus.Mode == "RTU" ? ConnectionMode.RTU : ConnectionMode.TCP,
                Ip = AppConfig.Modbus.Ip,
                Port = AppConfig.Modbus.Port,
                ComPort = AppConfig.Modbus.ComPort,
                BaudRate = AppConfig.Modbus.BaudRate,
                DataBits = AppConfig.Modbus.DataBits,
                Parity = Enum.TryParse<System.IO.Ports.Parity>(AppConfig.Modbus.Parity, out var p) ? p : System.IO.Ports.Parity.None,
                StopBits = Enum.TryParse<System.IO.Ports.StopBits>(AppConfig.Modbus.StopBits, out var s) ? s : System.IO.Ports.StopBits.One,
                UnitId = (byte)AppConfig.Modbus.UnitId
            };

            // Display connection info
            rdoTcp.Checked = (_connSettings.Mode == ConnectionMode.TCP);
            rdoRtu.Checked = (_connSettings.Mode == ConnectionMode.RTU);
            txtConnInfo.Text = _connSettings.ToString();
            txtUnitId.Text = _connSettings.UnitId.ToString();

            // List YAML map files from maps/ folder
            string mapsDir = Path.Combine(Application.StartupPath, "maps");
            if (Directory.Exists(mapsDir))
            {
                cbBindingMap.Items.Add(""); // empty selection
                foreach (string file in Directory.GetFiles(mapsDir, "*.yaml"))
                    cbBindingMap.Items.Add(Path.GetFileNameWithoutExtension(file));
                foreach (string file in Directory.GetFiles(mapsDir, "*.yml"))
                    cbBindingMap.Items.Add(Path.GetFileNameWithoutExtension(file));

                cbBindingMap.SelectedIndex = 0; // no selection
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            using var dlg = new FormConnection(_connSettings);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                _connSettings = dlg.Settings;
                rdoTcp.Checked = (_connSettings.Mode == ConnectionMode.TCP);
                rdoRtu.Checked = (_connSettings.Mode == ConnectionMode.RTU);
                txtConnInfo.Text = _connSettings.ToString();
            }
        }

        private void rdoMode_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTcp.Checked)
                _connSettings.Mode = ConnectionMode.TCP;
            else
                _connSettings.Mode = ConnectionMode.RTU;
            txtConnInfo.Text = _connSettings.ToString();
        }

        private void FormServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            _modbusServer.Stop();
        }

        private void cbBindingMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cbBindingMap.SelectedItem?.ToString() ?? "";
            if (string.IsNullOrEmpty(selected))
            {
                txtMapFile.Text = "";
                return;
            }

            if (_modbusServer.IsRunning())
            {
                MessageBox.Show("Please [Stop] the server before changing the map.", "Map",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Find the actual file (try .yaml first, then .yml)
            string mapsDir = Path.Combine(Application.StartupPath, "maps");
            string mapPath = Path.Combine(mapsDir, selected + ".yaml");
            if (!File.Exists(mapPath))
                mapPath = Path.Combine(mapsDir, selected + ".yml");

            txtMapFile.Text = Path.GetFileName(mapPath);

            try
            {
                TagStore.Instance.LoadMap(mapPath);
                _mapName = selected;
                Text = $"{_connSettings}:{_mapName}";
                if (TagStore.Instance.AddrIndex.Count > 0)
                {
                    var firstAddr = TagStore.Instance.AddrIndex.Keys.First().Split(':')[1];
                    StartAddr.Text = firstAddr;
                }
                log.Info($"Map loaded: {txtMapFile.Text}");
            }
            catch (Exception ex)
            {
                log.Error($"Failed to load map: {mapPath}, {ex.Message}");
                txtMapFile.Text = "";
            }
        }

        private void tabDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabDisplay.SelectedTab.Name.Equals("pageBits"))
            {
            }
            else if (tabDisplay.SelectedTab.Name.Equals("pageRegs"))
            {
            }
        }

#if false
        delegate void coilsChangedCallback();
        private void CoilsChanged()
        {
            if (_preventRefresh)
                return;

            if (this.tabDisplay.InvokeRequired)
            {
                {
                    coilsChangedCallback d = new coilsChangedCallback(CoilsChanged);
                    this.Invoke(d);
                }
            }
            else
            {
                if (tabDisplay.SelectedTab.Name.Equals("pageBits"))
                    tabDisplay_SelectedIndexChanged(null, null);
            }
        }

        delegate void registersChangedCallback();
        bool registersChanegesLocked;
        private void HoldingRegistersChanged()
        {
            if (_preventRefresh)
                return;

            try
            {
                log.Info("Server received message");

                if (this.tabDisplay.InvokeRequired)
                {
                    {
                        if (!registersChanegesLocked)
                            lock (this)
                            {
                                registersChanegesLocked = true;

                                registersChangedCallback d = new registersChangedCallback(HoldingRegistersChanged);
                                this.Invoke(d);
                            }
                    }
                }
                else
                {
                    if (tabDisplay.SelectedTab.Name.Equals("pageRegs"))
                        tabDisplay_SelectedIndexChanged(null, null);
                }
            }
            catch (Exception) { }
            registersChanegesLocked = false;
        }
#endif

        bool LockNumberOfConnectionsChanged = false;
        delegate void numberOfConnectionsCallback();
        private void NumberOfConnectionsChanged()
        {
            if (this.clientCount.InvokeRequired & !LockNumberOfConnectionsChanged)
            {
                {
                    lock (this)
                    {
                        LockNumberOfConnectionsChanged = true;
                        numberOfConnectionsCallback d = new numberOfConnectionsCallback(NumberOfConnectionsChanged);
                        try
                        {
                            this.Invoke(d);
                        }
                        catch (Exception) { }
                        finally
                        {
                            LockNumberOfConnectionsChanged = false;
                        }
                    }
                }
            }
            else
            {
                try
                {
                    clientCount.Text = _modbusServer.NumberOfConnections.ToString();
                }
                catch (Exception)
                { }
            }
        }

        private void CmdRead_Click(object sender, EventArgs e)
        {
            // Read raw registers/coils by Start Address + Quantity (no map needed)
            try
            {
                int addrFrom = int.Parse(StartAddr.Text);
                int qty = int.Parse(DataQty.Text);
                int addrTo = addrFrom + qty;

                string activeTab = tabDisplay.SelectedTab.Name;
                if (activeTab == "pageBits")
                {
                    bool[] bitValues = _modbusServer.BitValues;
                    dgvBits.Rows.Clear();
                    for (int i = addrFrom; i < addrTo; i++)
                    {
                        dgvBits.Rows.Add(i, "", bitValues[i]);
                        dgvBits[2, i - addrFrom].Style.BackColor = bitValues[i] ? Color.Green : Color.Red;
                    }
                    dgvBits.ClearSelection();
                }
                else
                {
                    UInt16[] regValues = _modbusServer.RegValues;
                    dgvRegs.Rows.Clear();
                    for (int i = addrFrom; i < addrTo; i++)
                    {
                        dgvRegs.Rows.Add(i, $"0x{regValues[i]:X04}", "", "", "", "", "");
                    }
                }
            }
            catch (Exception e1)
            {
                log.Error("Read error: " + e1.Message);
            }
        }

        private void btnReadMap_Click(object sender, EventArgs e)
        {
            // Read registers/coils with Modbus Map info (Start Address + Quantity)
            if (TagStore.Instance.AddrIndex.Count == 0)
            {
                CmdRead_Click(sender, e); // fallback to raw read
                return;
            }

            try
            {
                int addrFrom = int.Parse(StartAddr.Text);
                int qty = int.Parse(DataQty.Text);
                int addrTo = addrFrom + qty;

                string activeTab = tabDisplay.SelectedTab.Name;
                if (activeTab == "pageBits")
                {
                    bool[] bitValues = _modbusServer.BitValues;
                    dgvBits.Rows.Clear();
                    for (int i = addrFrom; i < addrTo; i++)
                    {
                        string tag = "";
                        if (TagStore.Instance.AddrIndex.TryGetValue($"COIL:{i}", out var regDef))
                            tag = regDef.Tag;
                        dgvBits.Rows.Add(i, tag, bitValues[i]);
                        dgvBits[2, i - addrFrom].Style.BackColor = bitValues[i] ? Color.Green : Color.Red;
                    }
                    dgvBits.ClearSelection();
                }
                else
                {
                    UInt16[] regValues = _modbusServer.RegValues;
                    dgvRegs.Rows.Clear();
                    for (int i = addrFrom; i < addrTo; )
                    {
                        UInt16 value = regValues[i];
                        if (TagStore.Instance.AddrIndex.TryGetValue($"HREG:{i}", out var info))
                        {
                            int regCount = info.GetRegisterCount();
                            if (regCount <= 1)
                            {
                                dgvRegs.Rows.Add(i, $"0x{value:X04}", info.DataType, info.Format, info.Scale, info.Tag, info.Description);
                                i++;
                            }
                            else
                            {
                                dgvRegs.Rows.Add(i, $"0x{value:X04}", info.DataType, info.Format, info.Scale, $"{info.Tag}:0", info.Description);
                                for (int w = 1; w < regCount; w++)
                                    dgvRegs.Rows.Add(i + w, $"0x{regValues[i + w]:X04}", "", "", "", $"{info.Tag}:{w}", "");
                                i += regCount;
                            }
                        }
                        else
                        {
                            dgvRegs.Rows.Add(i, $"0x{value:X04}", "", "", "", "", "");
                            i++;
                        }
                    }
                }
            }
            catch (Exception e1)
            {
                log.Error("Read Map error: " + e1.Message);
            }
        }

        private void btnReadTag_Click(object sender, EventArgs e)
        {
            // Read all tags from Modbus Map and display their register values
            if (TagStore.Instance.AddrIndex.Count == 0)
            {
                MessageBox.Show("No Modbus Map is loaded.", "Read Tag",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string activeTab = tabDisplay.SelectedTab.Name;
                if (activeTab == "pageBits")
                {
                    bool[] bitValues = _modbusServer.BitValues;
                    dgvBits.Rows.Clear();
                    foreach (var kvp in TagStore.Instance.AddrIndex)
                    {
                        if (!kvp.Key.StartsWith("COIL:")) continue;
                        int addr = int.Parse(kvp.Key.Split(':')[1]);
                        dgvBits.Rows.Add(addr, kvp.Value.Tag, bitValues[addr]);
                        int rowIdx = dgvBits.Rows.Count - 1;
                        dgvBits[2, rowIdx].Style.BackColor = bitValues[addr] ? Color.Green : Color.Red;
                    }
                    dgvBits.ClearSelection();
                }
                else
                {
                    UInt16[] regValues = _modbusServer.RegValues;
                    dgvRegs.Rows.Clear();
                    foreach (var kvp in TagStore.Instance.AddrIndex)
                    {
                        if (!kvp.Key.StartsWith("HREG:") && !kvp.Key.StartsWith("IREG:")) continue;
                        int addr = int.Parse(kvp.Key.Split(':')[1]);
                        var info = kvp.Value;
                        UInt16 value = regValues[addr];

                        if (info.GetRegisterCount() <= 1)
                        {
                            dgvRegs.Rows.Add(addr, $"0x{value:X04}", info.DataType, info.Format, info.Scale, info.Tag, info.Description);
                        }
                        else
                        {
                            dgvRegs.Rows.Add(addr, $"0x{value:X04}", info.DataType, info.Format, info.Scale, $"{info.Tag}:0", info.Description);
                            for (int w = 1; w < info.GetRegisterCount(); w++)
                                dgvRegs.Rows.Add(addr + w, $"0x{regValues[addr + w]:X04}", "", "", "", $"{info.Tag}:{w}", "");
                        }
                    }
                }
            }
            catch (Exception e1)
            {
                log.Error("Read Tag error: " + e1.Message);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_modbusServer.IsRunning())
                return;

            // Apply connection settings to server
            _modbusServer.Port = _connSettings.Port;
            _modbusServer.UnitId = byte.TryParse(txtUnitId.Text, out byte uid) ? uid : (byte)1;
            _modbusServer.ComPort = _connSettings.ComPort;
            _modbusServer.BaudRate = _connSettings.BaudRate;
            _modbusServer.DataBits = _connSettings.DataBits;
            _modbusServer.RtuParity = _connSettings.Parity;
            _modbusServer.RtuStopBits = _connSettings.StopBits;

            if (_connSettings.Mode == ConnectionMode.TCP)
                _modbusServer.StartTcp();
            else
                _modbusServer.StartRtu();

            btnStart.Enabled = false;
            btnStop.Enabled = true;
            rdoTcp.Enabled = false;
            rdoRtu.Enabled = false;
            btnSettings.Enabled = false;
            Text = $"{_connSettings}:{_mapName} (Running)";
            log.Info($"Modbus Server started: {_connSettings}");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (!_modbusServer.IsRunning())
                return;

            _modbusServer.Stop();

            btnStart.Enabled = true;
            btnStop.Enabled = false;
            rdoTcp.Enabled = true;
            rdoRtu.Enabled = true;
            btnSettings.Enabled = true;
            Text = $"{_connSettings}:{_mapName} (Stopped)";
            log.Info("Modbus Server stopped");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
            {
                dgvRegs.Rows.Clear();
                dgvBits.Rows.Clear();
                return;
            }

            // wait for user input
            if (txtSearch.Text.Length < 3)
                return;

            dgvRegs.Rows.Clear();
            try
            {
                DataTable dsFiltered = TagStore.Instance.Table.Select($"[Tag] like '%{txtSearch.Text}%' OR [Description] like '%{txtSearch.Text}%'")?.CopyToDataTable();
                foreach (DataRow row in dsFiltered.Rows)
                {
                    dgvRegs.Rows.Add($"{row["Address"]}", $"0x----", "", "", "", $"{row["Tag"]}", $"{row["Description"]}");
                }
            }
            catch (Exception ex)
            {
                log.Error("searching error, " + ex.Message);
            }
        }

        private void dgvBits_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (sender is not DataGridView grid)
                    return;

                // check dgvBits
                if (grid != dgvBits)
                    return;

                int colindex = grid.SelectedCells[0].ColumnIndex;
                // check a selected column is 'Value'
                if (colindex != 2)
                    return;

                int rowindex = grid.SelectedCells[0].RowIndex;
                int address = int.Parse(grid.Rows[rowindex].Cells["bitAddress"].Value.ToString());

                // toggle Value: true <--> false
                if (_modbusServer.BitValues[address] == false)
                    _modbusServer.BitValues[address] = true;
                else
                    _modbusServer.BitValues[address] = false;

                // set TAG result
                string tag = $"{grid.Rows[rowindex].Cells["bitTag"].Value}";
                //Datas.
                // set backgroud color by new Value
                if (_modbusServer.BitValues[address])
                    grid.Rows[rowindex].Cells[0].Style.BackColor = Color.Green;
                else
                    grid.Rows[rowindex].Cells[0].Style.BackColor = Color.Empty;
            }
            catch (Exception e1)
            {
                log.Error("data grid editing error, " + e1.Message);
            }
        }

        private void dgvRegs_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is not DataGridView grid)
                return;

            // check selected cell count
            if (grid.SelectedCells.Count < 1)
                return;

            int colindex = grid.SelectedCells[0].ColumnIndex;
            if (colindex != 1) // selected column: not 'Value'
                return;
            int rowindex = grid.SelectedCells[0].RowIndex;

            // get changed Value of selected Address
            int address; UInt16 value;
            try
            {
                address = int.Parse(grid.Rows[rowindex].Cells["regAddress"].Value.ToString());
                value = UInt16.Parse(grid.SelectedCells[0].Value.ToString(), System.Globalization.NumberStyles.HexNumber);
            }
            catch (Exception)
            {
                return;
            }

            // update Register
            try
            {
                if (grid == dgvRegs)
                {
                    _modbusServer.RegValues[address] = value;
                }
            }
            catch (Exception e1)
            {
                log.Error("data grid updating error, " + e1.Message);
            }
        }
    }
}
