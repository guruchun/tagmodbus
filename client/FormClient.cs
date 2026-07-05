using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using TagModbusLib;
using NModbus;
using System.Collections.Generic;
using log4net;

namespace TagModbus
{
    public partial class FormClient : DockContent
    {
        private TcpClient tcpClient;
        private IModbusMaster modbusMaster;
        private ModbusFactory modbusFactory;
        private ConnectionSettings connSettings;
        // dic(svrType, dic(regType:regAddr, regInfo))
        private Dictionary<string, Dictionary<string, ModbusMap.AddressInfo>> dicModbusRegs
            = new Dictionary<string, Dictionary<string, ModbusMap.AddressInfo>>();
        private Timer timerScan;
        private byte unitId;

        // Public accessors for FormTags
        public IModbusMaster ModbusMaster => modbusMaster;
        public byte UnitId => unitId;

        // used in tab control
        //private UInt32 _periodicCount;
        private ushort[] writeValues = new ushort[2];

        private static readonly ILog log = LogManager.GetLogger("Console");

        public FormClient()
        {
            InitializeComponent();

            // Enable double-buffered rendering for DataGridView performance
            typeof(System.Windows.Forms.DataGridView)
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(dgvModbus, true);

            modbusFactory = new ModbusFactory();
            connSettings = new ConnectionSettings();

            // timer
            timerScan = new Timer();
            timerScan.Tick += new EventHandler(this.timerScan_Tick);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            // Load connection settings from config
            connSettings.Mode = AppConfig.Modbus.Mode == "RTU" ? ConnectionMode.RTU : ConnectionMode.TCP;
            connSettings.Ip = AppConfig.Modbus.Ip;
            connSettings.Port = AppConfig.Modbus.Port;
            connSettings.ConnTimeout = AppConfig.Modbus.ConnTimeout;
            connSettings.ComPort = AppConfig.Modbus.ComPort;
            connSettings.BaudRate = AppConfig.Modbus.BaudRate;
            connSettings.DataBits = AppConfig.Modbus.DataBits;
            connSettings.Parity = Enum.Parse<System.IO.Ports.Parity>(AppConfig.Modbus.Parity);
            connSettings.StopBits = Enum.Parse<System.IO.Ports.StopBits>(AppConfig.Modbus.StopBits);
            connSettings.UnitId = (byte)AppConfig.Modbus.UnitId;
            connSettings.ResponseTimeout = AppConfig.Modbus.ResponseTimeout;
            unitId = connSettings.UnitId;

            // Display connection info
            rdoTcp.Checked = (connSettings.Mode == ConnectionMode.TCP);
            rdoRtu.Checked = (connSettings.Mode == ConnectionMode.RTU);
            txtConnInfo.Text = connSettings.ToString();
            txtUnitId.Text = connSettings.UnitId.ToString();
            txtRespTimeout.Text = connSettings.ResponseTimeout.ToString();
            if (connSettings.Mode == ConnectionMode.TCP)
            {
                btnConnect.Text = "Connect";
                btnDisconnect.Text = "Disconnect";
            }
            else
            {
                btnConnect.Text = "Open";
                btnDisconnect.Text = "Close";
            }

            // Update mode on radio button change
            rdoTcp.CheckedChanged += (s, ev) =>
            {
                if (rdoTcp.Checked)
                {
                    connSettings.Mode = ConnectionMode.TCP;
                    txtConnInfo.Text = connSettings.ToString();
                    btnConnect.Text = "Connect";
                    btnDisconnect.Text = "Disconnect";
                }
            };
            rdoRtu.CheckedChanged += (s, ev) =>
            {
                if (rdoRtu.Checked)
                {
                    connSettings.Mode = ConnectionMode.RTU;
                    txtConnInfo.Text = connSettings.ToString();
                    btnConnect.Text = "Open";
                    btnDisconnect.Text = "Close";
                }
            };

            txtAddrOffset.Text = "0";
            txtAddrStart.Text = "0";
            txtAddrQty.Text = "10";

            // connection state
            picConnState.Image = Properties.Resources.dot_red;
            btnDisconnect.Enabled = false;
            txtInterval.Text = AppConfig.Modbus.MonInterval.ToString();

            // RegType
            var regData = new KeyValuePair<string, RegisterModel>[4];
            regData[0] = new KeyValuePair<string, RegisterModel>("Coils", RegisterModel.COIL);
            regData[1] = new KeyValuePair<string, RegisterModel>("Discrete Inputs", RegisterModel.DISC);
            regData[2] = new KeyValuePair<string, RegisterModel>("Holding Registers", RegisterModel.HOREG);
            regData[3] = new KeyValuePair<string, RegisterModel>("Input Registers", RegisterModel.INREG);
            cbRegType.DisplayMember = "Key";
            cbRegType.ValueMember = "Value";
            cbRegType.DataSource = regData;
            cbRegType.SelectedIndex = 2;

            // Function Code
            int funcCount = 8;
            var funcs = new KeyValuePair<string, Function>[funcCount];
            funcs[0] = new KeyValuePair<string, Function>("0x01 - Read Coils", Function.READ_COIL);
            funcs[1] = new KeyValuePair<string, Function>("0x02 - Read Discrete Inputs", Function.READ_DISC);
            funcs[2] = new KeyValuePair<string, Function>("0x03 - Read Holding Registers", Function.READ_HOREG);
            funcs[3] = new KeyValuePair<string, Function>("0x04 - Read Input Registers", Function.READ_INREG);
            funcs[4] = new KeyValuePair<string, Function>("0x05 - Write Single Coil", Function.WRITE_COIL);
            funcs[5] = new KeyValuePair<string, Function>("0x06 - Write Single Register", Function.WRITE_REG);
            funcs[6] = new KeyValuePair<string, Function>("0x0F - Write Multiple Coils", Function.WRITE_MCOIL);
            funcs[7] = new KeyValuePair<string, Function>("0x10 - Write Multiple Registers", Function.WRITE_MREG);
            cbFunction.DisplayMember = "Key";
            cbFunction.ValueMember = "Value";
            cbFunction.DataSource = funcs;
            cbFunction.SelectedIndex = 0;
            
            // map file
            if (AppConfig.Modbus.MapList.Count > 0)
            {
                // load modbus map
                foreach (var map in AppConfig.Modbus.MapList)
                {
                    cbBindingMap.Items.Add(map.Key);    // server Type(master, slave, scada)
                    loadModbusMap(map.Key, map.Value);  // server Type, filename
                }
                if (cbBindingMap.Items.Count > 0)
                    cbBindingMap.SelectedIndex = 0;
            }
        }

        private void loadModbusMap(string serverType, string mapFile)
        {
            try
            {
                // load modbus map (auto-detect YAML/JSON)
                string path = Path.Combine(Application.StartupPath, "maps", mapFile);
                var map = ModbusMapLoader.Load(path);

                // load Register info on dictionary
                Dictionary<string, ModbusMap.AddressInfo> dicRegs = new Dictionary<string, ModbusMap.AddressInfo>();
                foreach (var section in map.Sections)
                {
                    foreach (var reg in section.Registers)
                    {
                        try
                        {
                            var info = new ModbusMap.AddressInfo
                            {
                                Address = reg.Address,
                                Tag = reg.Tag,
                                DataType = reg.DataType,
                                Scale = reg.Scale,
                                Format = reg.Format,
                                Unit = reg.Unit,
                                Description = reg.Description,
                                Width = reg.GetRegisterCount(),
                                Access = reg.Access
                            };
                            dicRegs.TryAdd(section.Type + ":" + (section.BaseAddress + reg.Address), info);
                        }
                        catch (Exception)
                        {
                            log.Debug($"mapping error, Type:{serverType}, map:{mapFile}, {section.Type}:{section.BaseAddress + reg.Address} --> {reg.Tag}");
                        }
                    }
                }
                dicModbusRegs.TryAdd(serverType, dicRegs);

                // Also populate TagStore
                TagStore.Instance.LoadMap(path);
            }
            catch (Exception e1)
            {
                log.Debug($"Modbus map file loading error, Type:{serverType}, map:{mapFile}, {e1.Message}");
            }
        }

        private void Form_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            ((MainForm)this.ParentForm).ShowHelp("ToolModbusClient");
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            connSettings.Mode = rdoTcp.Checked ? ConnectionMode.TCP : ConnectionMode.RTU;
            using var dlg = new FormConnection(connSettings);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                connSettings = dlg.Settings;
                unitId = connSettings.UnitId;
                rdoTcp.Checked = (connSettings.Mode == ConnectionMode.TCP);
                rdoRtu.Checked = (connSettings.Mode == ConnectionMode.RTU);
                txtConnInfo.Text = connSettings.ToString();
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // Apply UI values to connSettings
                connSettings.UnitId = byte.Parse(txtUnitId.Text);
                connSettings.ResponseTimeout = int.Parse(txtRespTimeout.Text);

                if (connSettings.Mode == ConnectionMode.TCP)
                {
                    tcpClient = new TcpClient();
                    var result = tcpClient.BeginConnect(connSettings.Ip, connSettings.Port, null, null);
                    if (!result.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(connSettings.ConnTimeout)))
                    {
                        tcpClient.Close();
                        throw new Exception("Connection timeout");
                    }
                    tcpClient.EndConnect(result);
                    tcpClient.GetStream().ReadTimeout = connSettings.ResponseTimeout;

                    modbusMaster = modbusFactory.CreateMaster(tcpClient);
                    modbusMaster.Transport.ReadTimeout = connSettings.ResponseTimeout;
                    modbusMaster.Transport.WriteTimeout = connSettings.ResponseTimeout;
                }
                else // RTU
                {
                    var serialPort = new System.IO.Ports.SerialPort(
                        connSettings.ComPort,
                        connSettings.BaudRate,
                        connSettings.Parity,
                        connSettings.DataBits,
                        connSettings.StopBits);
                    serialPort.ReadTimeout = connSettings.ResponseTimeout;
                    serialPort.WriteTimeout = connSettings.ResponseTimeout;
                    serialPort.Open();

                    var adapter = new NModbus.Serial.SerialPortAdapter(serialPort);
                    modbusMaster = modbusFactory.CreateRtuMaster(adapter);
                    modbusMaster.Transport.ReadTimeout = connSettings.ResponseTimeout;
                    modbusMaster.Transport.WriteTimeout = connSettings.ResponseTimeout;
                }

                unitId = connSettings.UnitId;
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                log.Debug("Connected: " + connSettings.ToString());
                picConnState.Image = Properties.Resources.dot_green;
                this.Text = connSettings.ToString();
            }
            catch (Exception e1)
            {
                log.Debug("Connection Error, " + e1.Message);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                modbusMaster?.Dispose();
                modbusMaster = null;
                tcpClient?.Close();
                tcpClient = null;
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
                log.Debug("Disconnected");
                picConnState.Image = Properties.Resources.dot_red;
            }
            catch (Exception e1)
            {
                log.Debug("Disconnect Error, " + e1.Message);
            }
        }

        private void readModbus(Function funcCode)
        {
            int addrOffset = int.Parse(txtAddrOffset.Text);
            int addrFrom = int.Parse(txtAddrStart.Text);
            int quantity = int.Parse(txtAddrQty.Text);
            string serverType = cbBindingMap.Text;
            bool hexDisplay = chkHexView.Checked;

            // Build DataTable for fast binding
            var dt = new System.Data.DataTable();
            dt.Columns.Add("Address");
            dt.Columns.Add("RawValue");
            dt.Columns.Add("Converted");
            dt.Columns.Add("Type");
            dt.Columns.Add("Format");
            dt.Columns.Add("Scale");
            dt.Columns.Add("Tag");
            dt.Columns.Add("Description");

            if (funcCode == Function.READ_COIL || funcCode == Function.READ_DISC)
            {
                bool[] serverResponse;
                if (funcCode == Function.READ_COIL)
                    serverResponse = modbusMaster.ReadCoils(unitId, (ushort)(addrOffset + addrFrom), (ushort)quantity);
                else
                    serverResponse = modbusMaster.ReadInputs(unitId, (ushort)(addrOffset + addrFrom), (ushort)quantity);

                ModbusMap.AddressInfo info = new ModbusMap.AddressInfo();
                for (int i = 0; i < serverResponse.Length; i++)
                {
                    string tag = "", desc = "";
                    string key = (funcCode == Function.READ_COIL ? "COIL:" : "DISC:") + (addrOffset + addrFrom + i).ToString();

                    if (dicModbusRegs.ContainsKey(serverType))
                    {
                        if (dicModbusRegs[serverType].TryGetValue(key, out info))
                        {
                            tag = info.Tag;
                            desc = info.Description;
                        }
                    }

                    string rawVal = Convert.ToInt32(serverResponse[i]).ToString();
                    dt.Rows.Add(addrOffset + addrFrom + i, rawVal, serverResponse[i], "", "", "", tag, desc);
                }
            }
            else if (funcCode == Function.READ_HOREG || funcCode == Function.READ_INREG)
            {
                ushort[] serverResponse;
                if (funcCode == Function.READ_HOREG)
                    serverResponse = modbusMaster.ReadHoldingRegisters(unitId, (ushort)(addrOffset + addrFrom), (ushort)quantity);
                else
                    serverResponse = modbusMaster.ReadInputRegisters(unitId, (ushort)(addrOffset + addrFrom), (ushort)quantity);

                ModbusMap.AddressInfo info = new ModbusMap.AddressInfo();
                for (int i = 0; i < serverResponse.Length; )
                {
                    string tag = "", desc = "", type = "", format = "";
                    int scale = 1;
                    string rawStr = hexDisplay ? serverResponse[i].ToString("X4") : serverResponse[i].ToString();
                    string key = (funcCode == Function.READ_INREG ? "IREG:" : "HREG:") + (addrOffset + addrFrom + i).ToString();

                    // No map binding
                    if (!dicModbusRegs.ContainsKey(serverType) || !dicModbusRegs[serverType].TryGetValue(key, out info))
                    {
                        dt.Rows.Add(addrOffset + addrFrom + i, rawStr, "", type, format, scale, tag, desc);
                        i++;
                        continue;
                    }

                    type = info.DataType;
                    tag = info.Tag;
                    desc = info.Description;
                    format = info.Format;
                    scale = info.Scale;

                    // Convert using ModbusUtils
                    var (convertedStr, regCount) = ModbusMapHelper.ConvertFromRegisters(
                        serverResponse, i, type, format, scale);

                    // First register row (with converted value)
                    dt.Rows.Add(addrOffset + addrFrom + i, rawStr, convertedStr, type, format, scale, tag, desc);

                    // Additional registers consumed (for multi-register types)
                    for (int j = 1; j < regCount; j++)
                    {
                        string rawN = hexDisplay ? serverResponse[i + j].ToString("X4") : serverResponse[i + j].ToString();
                        dt.Rows.Add(addrOffset + addrFrom + i + j, rawN, "", "", "", "", "", "");
                    }

                    // B16 bitfield expansion
                    if (type == "B16")
                    {
                        for (int pos = 0; pos < 16; pos++)
                        {
                            bool flag = (serverResponse[i] & (1 << pos)) > 0;
                            dt.Rows.Add($"{addrOffset + addrFrom + i}:{pos}", "", flag, "", "", "", "", "");
                        }
                    }

                    i += regCount;
                }
            }
            else
            {
                log.Debug("not supported function code.");
            }

            // Bind DataTable to grid (single paint operation)
            dgvModbus.DataSource = dt;

            // Update TagStore with read values
            updateTagStore(dt);

            // Row headers: start address based index
            for (int i = 0; i < dgvModbus.Rows.Count; i++)
            {
                if (dgvModbus.Rows[i].IsNewRow) continue;
                dgvModbus.Rows[i].HeaderCell.Value = (addrFrom + i).ToString();
            }
        }

        private ushort parseRawValue(string rawStr)
        {
            if (string.IsNullOrWhiteSpace(rawStr)) return 0;
            rawStr = rawStr.Trim();
            if (chkHexView.Checked || rawStr.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            {
                rawStr = rawStr.Replace("0x", "").Replace("0X", "");
                return ushort.Parse(rawStr, System.Globalization.NumberStyles.HexNumber);
            }
            return ushort.Parse(rawStr);
        }

        private string formatConverted(double value)
        {
            // Max 5 decimal places, trim trailing zeros
            return value.ToString("0.#####");
        }

        private void writeModbusBit() // addrOffset
        {
            // send for each coil bit
            for (int i = 0; i < dgvModbus.RowCount; i++)
            {
                DataGridViewRowHeaderCell header = dgvModbus.Rows[i].HeaderCell;
                if (header.Value != null && header.Value.ToString() == "*")
                {
                    int addr = (ushort)int.Parse(dgvModbus.Rows[i].Cells["Address"].Value?.ToString() ?? "0");
                    string rawStr = dgvModbus.Rows[i].Cells["Value"].Value?.ToString() ?? "0";
                    bool coilValue = (parseRawValue(rawStr) != 0);

                    try
                    {
                        modbusMaster.WriteSingleCoil(unitId, (ushort)addr, coilValue);
                    }
                    catch (Exception ex)
                    {
                        log.Debug("error, " + ex.Message);
                    }
                    header.Value = null;
                }
            }

            // refresh registers
            readModbus(Function.READ_COIL);
        }

        private void writeModbusBits()
        {
            // find dirty rows
            int first = -1;
            int last = -1;
            for (int i = 0; i < dgvModbus.RowCount; i++)
            {
                DataGridViewRowHeaderCell header = dgvModbus.Rows[i].HeaderCell;
                if (header.Value != null && header.Value.ToString() == "*")
                {
                    if (first < 0)
                        first = i;

                    last = i;
                    header.Value = null;
                }
            }
            if (first < 0)
                return;

            // get changed rows
            int addrFrom = (ushort)int.Parse(dgvModbus.Rows[first].Cells["Address"].Value?.ToString() ?? "0");
            ushort quantity = (ushort)(last - first + 1);
            bool[] values = new bool[quantity];
            for (int i = 0; i < quantity; i++)
            {
                string rawStr = dgvModbus.Rows[first + i].Cells["Value"].Value?.ToString() ?? "0";
                values[i] = (parseRawValue(rawStr) != 0);
                dgvModbus.Rows[first + i].HeaderCell.Value = null;
            }

            try
            {
                modbusMaster.WriteMultipleCoils(unitId, (ushort)addrFrom, values);
            }
            catch (Exception ex)
            {
                log.Debug("error, " + ex.Message);
                return;
            }

            // refresh registers
            readModbus(Function.READ_COIL);
        }

        private void writeModbusReg()
        {
            try
            {
                for (int i = 0; i < dgvModbus.RowCount; i++)
                {
                    DataGridViewRowHeaderCell header = dgvModbus.Rows[i].HeaderCell;
                    if (header.Value != null && header.Value.ToString() == "*")
                    {
                        header.Value = null;
                        string addrStr = dgvModbus.Rows[i].Cells["Address"].Value?.ToString() ?? "";
                        string rawStr = dgvModbus.Rows[i].Cells["Value"].Value?.ToString() ?? "";
                        if (string.IsNullOrWhiteSpace(addrStr) || string.IsNullOrWhiteSpace(rawStr))
                            continue;

                        ushort addr = ushort.Parse(addrStr);
                        ushort value = parseRawValue(rawStr);
                        modbusMaster.WriteSingleRegister(unitId, addr, value);
                    }
                }
            }
            catch (Exception e)
            {
                log.Debug("write single Register error, " + e.Message);
                return;
            }

            // refresh registers
            readModbus(Function.READ_HOREG);
        }

        private void writeModbusRegs()
        {
            // find dirty rows
            int first = -1;
            int last = -1;
            for (int i = 0; i < dgvModbus.RowCount; i++)
            {
                DataGridViewRowHeaderCell header = dgvModbus.Rows[i].HeaderCell;
                if (header.Value != null && header.Value.ToString() == "*")
                {
                    if (first < 0)
                        first = i;

                    last = i;
                    header.Value = null;
                }
            }
            if (first < 0)
                return;
            ushort qty = (ushort)(last - first + 1);

            // write registers
            if (qty > 0)
            {
                ushort start = ushort.Parse(dgvModbus.Rows[first].Cells["Address"].Value?.ToString() ?? "0");
                ushort[] values = new ushort[qty];
                for (int i = 0; i < qty; i++)
                {
                    string rawStr = dgvModbus.Rows[first + i].Cells["Value"].Value?.ToString() ?? "0";
                    values[i] = parseRawValue(rawStr);
                }

                // write via NModbus
                if (qty == 1)
                    modbusMaster.WriteSingleRegister(unitId, start, values[0]);
                else
                    modbusMaster.WriteMultipleRegisters(unitId, start, values);
            }

            // refresh registers
            readModbus(Function.READ_HOREG);
        }

        /// <summary>
        /// Mixed write: groups consecutive dirty registers and sends
        /// each group as a single WriteMultipleRegisters call.
        /// </summary>
        private void writeModbusRegsMixed()
        {
            // collect dirty row indices
            var dirtyIndices = new List<int>();
            for (int i = 0; i < dgvModbus.RowCount; i++)
            {
                DataGridViewRowHeaderCell header = dgvModbus.Rows[i].HeaderCell;
                if (header.Value != null && header.Value.ToString() == "*")
                {
                    dirtyIndices.Add(i);
                    header.Value = null;
                }
            }
            if (dirtyIndices.Count == 0)
                return;

            // group consecutive addresses
            var groups = new List<List<int>> { new List<int> { dirtyIndices[0] } };
            for (int i = 1; i < dirtyIndices.Count; i++)
            {
                int prevAddr = int.Parse(dgvModbus.Rows[dirtyIndices[i - 1]].Cells["Address"].Value?.ToString() ?? "0");
                int currAddr = int.Parse(dgvModbus.Rows[dirtyIndices[i]].Cells["Address"].Value?.ToString() ?? "0");
                if (currAddr == prevAddr + 1)
                    groups[groups.Count - 1].Add(dirtyIndices[i]);
                else
                    groups.Add(new List<int> { dirtyIndices[i] });
            }

            // send each group
            foreach (var group in groups)
            {
                ushort start = ushort.Parse(dgvModbus.Rows[group[0]].Cells["Address"].Value?.ToString() ?? "0");
                ushort[] values = new ushort[group.Count];
                for (int i = 0; i < group.Count; i++)
                {
                    string rawStr = dgvModbus.Rows[group[i]].Cells["Value"].Value?.ToString() ?? "0";
                    values[i] = parseRawValue(rawStr);
                }

                if (values.Length == 1)
                    modbusMaster.WriteSingleRegister(unitId, start, values[0]);
                else
                    modbusMaster.WriteMultipleRegisters(unitId, start, values);
            }

            // refresh registers
            readModbus(Function.READ_HOREG);
        }

        /// <summary>
        /// Updates TagStore with converted values from the read result.
        /// </summary>
        private void updateTagStore(System.Data.DataTable dt)
        {
            foreach (System.Data.DataRow row in dt.Rows)
            {
                string tag = row["Tag"]?.ToString() ?? "";
                string converted = row["Converted"]?.ToString() ?? "";
                if (!string.IsNullOrEmpty(tag) && !string.IsNullOrEmpty(converted))
                {
                    TagStore.Instance.SetValue(tag, converted);
                }
            }
        }

        /// <summary>
        /// Handles connection lost: cleans up and resets UI state.
        /// </summary>
        private void handleConnectionLost(string context, Exception ex)
        {
            log.Error($"{context}: {ex.Message}");
            try
            {
                modbusMaster?.Dispose();
                modbusMaster = null;
                tcpClient?.Close();
                tcpClient = null;
            }
            catch { }
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            picConnState.Image = Properties.Resources.dot_red;
            log.Debug("Connection lost, disconnected automatically.");
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            dgvModbus.DataSource = null;

            if (modbusMaster == null)
            {
                log.Debug("Client is not connected to the MODBUS server");
                return;
            }
            try
            {
                // Use register type as function code
                Function funcCode = (Function)cbRegType.SelectedValue;
                readModbus(funcCode);
            }
            catch (Exception e1)
            {
                handleConnectionLost("btnRead_Click", e1);
            }
        }
        private void btnExec_Click(object sender, EventArgs e)
        {
            if (modbusMaster == null)
            {
                log.Debug("Client is not connected to the MODBUS server");
                return;
            }
            try
            {
                RegisterModel regType = (RegisterModel)cbRegType.SelectedValue;

                // Write mode based on radio selection
                if (regType == RegisterModel.COIL)
                {
                    if (rdSingle.Checked)
                        writeModbusBit();
                    else
                        writeModbusBits(); // Multiple and Mixed use same logic for coils
                }
                else if (regType == RegisterModel.HOREG)
                {
                    if (rdSingle.Checked)
                        writeModbusReg();
                    else if (rdMultiple.Checked)
                        writeModbusRegs();
                    else // Mixed
                        writeModbusRegsMixed();
                }
                else
                {
                    log.Debug("not supported register type for write.");
                }
            }
            catch (Exception e1)
            {
                handleConnectionLost("btnExec_Click", e1);
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            dgvModbus.DataSource = null;

            if (modbusMaster == null)
            {
                log.Info("Client is not connected to the MODBUS server");
                return;
            }

            byte unitId = byte.Parse(txtAddrOffset.Text);

            try
            {
                String tag = ((Control)sender).Tag.ToString();
                if (tag.Equals("coil"))
                {
                }
                else if (tag.Equals("holdReg"))
                {
                }
            }
            catch (Exception e1)
            {
                log.Error("write Register error, " + e1.Message);
                return;
            }
        }

        private void dgvModbus_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("cell dirty changed, " + sender.GetType().ToString());
            DataGridView dgview = (DataGridView)sender;
            dgview.CurrentRow.HeaderCell.Value = "*";
        }

        private void timerScan_Tick(object sender, EventArgs e)
        {
            try
            {
                // Use register type as function code
                Function funcCode = (Function)cbRegType.SelectedValue;
                readModbus(funcCode);
            }
            catch (Exception e1)
            {
                timerScan.Stop();
                chkMonitoring.Checked = false;
                handleConnectionLost("timerScan_Tick", e1);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
                return;

            dgvModbus.DataSource = null;
            string serverType = cbBindingMap.Text;
            foreach (var item in dicModbusRegs[serverType])
            {
                if (item.Value == null)
                    continue;

                if (item.Value.Tag.IndexOf(txtSearch.Text) >= 0
                    || item.Value.Description.IndexOf(txtSearch.Text) >= 0)
                {
                    dgvModbus.Rows.Add(item.Key, "", "", item.Value.DataType, item.Value.Format, item.Value.Scale, item.Value.Tag, item.Value.Description);
                }
            }
        }

        private void dgvModbus_DoubleClick(object sender, EventArgs e)
        {
        }

        private void chkMonitoring_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMonitoring.Checked && tcpClient != null && tcpClient.Connected)
            {
                timerScan.Interval = int.Parse(txtInterval.Text);
                timerScan.Enabled = true;
                timerScan.Start();
                log.Debug("scan timer is started");
            }
            else if (timerScan.Enabled)
            {
                timerScan.Stop();
                log.Debug("scan timer is stopped");
                return;
            }
        }

        private void txtInterval_TextChanged(object sender, EventArgs e)
        {
            log.Debug("scan timer is changed");
            if (chkMonitoring.Checked && tcpClient != null && tcpClient.Connected)
            {
                int interval = int.Parse(txtInterval.Text);
                if (interval >= 100)
                {
                    timerScan.Stop();
                    timerScan.Interval = interval;
                    timerScan.Start();
                    log.Debug("scan timer is restarted, interval=" + interval);
                }
            }
        }

        private void chkHexView_CheckedChanged(object sender, EventArgs e)
        {
            bool hex = chkHexView.Checked;
            for (int i = 0; i < dgvModbus.Rows.Count; i++)
            {
                if (dgvModbus.Rows[i].IsNewRow) continue;
                var cell = dgvModbus.Rows[i].Cells[1]; // RawValue column
                string val = cell.Value?.ToString() ?? "";
                if (string.IsNullOrEmpty(val)) continue;

                if (hex)
                {
                    // Decimal -> Hex
                    if (ushort.TryParse(val, out ushort num))
                        cell.Value = num.ToString("X4");
                }
                else
                {
                    // Hex -> Decimal
                    if (ushort.TryParse(val, System.Globalization.NumberStyles.HexNumber, null, out ushort num))
                        cell.Value = num.ToString();
                }
            }
        }
    }
}
