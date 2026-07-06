using System;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace TagModbusSvr
{
    public enum ConnectionMode { TCP, RTU }

    public class ConnectionSettings
    {
        public ConnectionMode Mode { get; set; } = ConnectionMode.TCP;

        // TCP (Server listens on this IP:Port)
        public string Ip { get; set; } = "0.0.0.0";
        public int Port { get; set; } = 1502;

        // RTU
        public string ComPort { get; set; } = "COM1";
        public int BaudRate { get; set; } = 9600;
        public int DataBits { get; set; } = 8;
        public Parity Parity { get; set; } = Parity.None;
        public StopBits StopBits { get; set; } = StopBits.One;

        // Common
        public byte UnitId { get; set; } = 1;

        public override string ToString()
        {
            if (Mode == ConnectionMode.TCP)
                return $"{Ip}:{Port}";
            else
                return $"{ComPort}  {BaudRate},{DataBits},{Parity.ToString()[0]},{(StopBits == StopBits.One ? "1" : "2")}";
        }
    }

    public partial class FormConnection : Form
    {
        public ConnectionSettings Settings { get; private set; }

        // TCP controls
        private RadioButton rdoTcp;
        private RadioButton rdoRtu;
        private Panel panelTcp;
        private Panel panelRtu;
        private ComboBox cbListenIp;
        private TextBox txtPort;

        // RTU controls
        private ComboBox cbComPort;
        private ComboBox cbBaudRate;
        private ComboBox cbDataBits;
        private ComboBox cbParity;
        private ComboBox cbStopBits;

        // Common
        private Button btnOk;
        private Button btnSave;
        private Button btnCancel;

        public FormConnection(ConnectionSettings settings)
        {
            Settings = settings ?? new ConnectionSettings();
            InitializeUI();
            LoadSettings();
        }

        private void InitializeUI()
        {
            Text = "Server Connection Settings";
            Size = new System.Drawing.Size(380, 270);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Font = new System.Drawing.Font("Segoe UI", 9F);

            // Radio buttons
            rdoTcp = new RadioButton { Text = "TCP", Location = new System.Drawing.Point(20, 15), AutoSize = true };
            rdoRtu = new RadioButton { Text = "RTU", Location = new System.Drawing.Point(100, 15), AutoSize = true };
            rdoTcp.CheckedChanged += (s, e) => { panelTcp.Visible = rdoTcp.Checked; panelRtu.Visible = rdoRtu.Checked; };
            Controls.Add(rdoTcp);
            Controls.Add(rdoRtu);

            // TCP Panel
            panelTcp = new Panel { Location = new System.Drawing.Point(10, 45), Size = new System.Drawing.Size(350, 70) };
            panelTcp.Controls.Add(new Label { Text = "Listen IP:", Location = new System.Drawing.Point(10, 10), AutoSize = true });
            cbListenIp = new ComboBox { Location = new System.Drawing.Point(130, 7), Size = new System.Drawing.Size(180, 23), DropDownStyle = ComboBoxStyle.DropDownList };
            cbListenIp.Items.Add("0.0.0.0 (All)");
            try
            {
                foreach (var addr in Dns.GetHostAddresses(Dns.GetHostName()))
                {
                    if (addr.AddressFamily == AddressFamily.InterNetwork)
                        cbListenIp.Items.Add(addr.ToString());
                }
            }
            catch { }
            panelTcp.Controls.Add(cbListenIp);
            panelTcp.Controls.Add(new Label { Text = "Port:", Location = new System.Drawing.Point(10, 40), AutoSize = true });
            txtPort = new TextBox { Location = new System.Drawing.Point(130, 37), Size = new System.Drawing.Size(80, 23) };
            panelTcp.Controls.Add(txtPort);
            Controls.Add(panelTcp);

            // RTU Panel
            panelRtu = new Panel { Location = new System.Drawing.Point(10, 45), Size = new System.Drawing.Size(350, 150), Visible = false };
            panelRtu.Controls.Add(new Label { Text = "COM Port:", Location = new System.Drawing.Point(10, 10), AutoSize = true });
            cbComPort = new ComboBox { Location = new System.Drawing.Point(110, 7), Size = new System.Drawing.Size(100, 23), DropDownStyle = ComboBoxStyle.DropDownList };
            cbComPort.Items.AddRange(SerialPort.GetPortNames());
            panelRtu.Controls.Add(cbComPort);
            panelRtu.Controls.Add(new Label { Text = "Baud Rate:", Location = new System.Drawing.Point(10, 40), AutoSize = true });
            cbBaudRate = new ComboBox { Location = new System.Drawing.Point(110, 37), Size = new System.Drawing.Size(100, 23), DropDownStyle = ComboBoxStyle.DropDownList };
            cbBaudRate.Items.AddRange(new object[] { 9600, 19200, 38400, 57600, 115200 });
            panelRtu.Controls.Add(cbBaudRate);
            panelRtu.Controls.Add(new Label { Text = "Data Bits:", Location = new System.Drawing.Point(10, 70), AutoSize = true });
            cbDataBits = new ComboBox { Location = new System.Drawing.Point(110, 67), Size = new System.Drawing.Size(60, 23), DropDownStyle = ComboBoxStyle.DropDownList };
            cbDataBits.Items.AddRange(new object[] { 7, 8 });
            panelRtu.Controls.Add(cbDataBits);
            panelRtu.Controls.Add(new Label { Text = "Parity:", Location = new System.Drawing.Point(10, 100), AutoSize = true });
            cbParity = new ComboBox { Location = new System.Drawing.Point(110, 97), Size = new System.Drawing.Size(100, 23), DropDownStyle = ComboBoxStyle.DropDownList };
            cbParity.Items.AddRange(new object[] { Parity.None, Parity.Even, Parity.Odd });
            panelRtu.Controls.Add(cbParity);
            panelRtu.Controls.Add(new Label { Text = "Stop Bits:", Location = new System.Drawing.Point(10, 130), AutoSize = true });
            cbStopBits = new ComboBox { Location = new System.Drawing.Point(110, 127), Size = new System.Drawing.Size(60, 23), DropDownStyle = ComboBoxStyle.DropDownList };
            cbStopBits.Items.AddRange(new object[] { StopBits.One, StopBits.Two });
            panelRtu.Controls.Add(cbStopBits);
            Controls.Add(panelRtu);

            // Buttons
            btnSave = new Button { Text = "Save", Location = new System.Drawing.Point(10, 205), Size = new System.Drawing.Size(80, 28) };
            btnOk = new Button { Text = "OK", Location = new System.Drawing.Point(190, 205), Size = new System.Drawing.Size(80, 28), DialogResult = DialogResult.OK };
            btnCancel = new Button { Text = "Cancel", Location = new System.Drawing.Point(275, 205), Size = new System.Drawing.Size(80, 28), DialogResult = DialogResult.Cancel };
            btnOk.Click += BtnOk_Click;
            btnSave.Click += BtnSave_Click;
            Controls.Add(btnOk);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            AcceptButton = btnOk;
            CancelButton = btnCancel;
        }

        private void LoadSettings()
        {
            rdoTcp.Checked = (Settings.Mode == ConnectionMode.TCP);
            rdoRtu.Checked = (Settings.Mode == ConnectionMode.RTU);
            panelTcp.Visible = (Settings.Mode == ConnectionMode.TCP);
            panelRtu.Visible = (Settings.Mode == ConnectionMode.RTU);

            // TCP
            SelectListenIp(Settings.Ip);
            txtPort.Text = Settings.Port.ToString();

            // RTU
            if (cbComPort.Items.Contains(Settings.ComPort))
                cbComPort.SelectedItem = Settings.ComPort;
            else if (cbComPort.Items.Count > 0)
                cbComPort.SelectedIndex = 0;
            cbBaudRate.SelectedItem = Settings.BaudRate;
            cbDataBits.SelectedItem = Settings.DataBits;
            cbParity.SelectedItem = Settings.Parity;
            cbStopBits.SelectedItem = Settings.StopBits;
        }

        private void SelectListenIp(string ip)
        {
            for (int i = 0; i < cbListenIp.Items.Count; i++)
            {
                if (cbListenIp.Items[i].ToString().StartsWith(ip))
                {
                    cbListenIp.SelectedIndex = i;
                    return;
                }
            }
            // Default to "0.0.0.0 (All)"
            if (cbListenIp.Items.Count > 0)
                cbListenIp.SelectedIndex = 0;
        }

        private string GetSelectedIp()
        {
            string selected = cbListenIp.SelectedItem?.ToString() ?? "0.0.0.0";
            // Strip " (All)" suffix
            int space = selected.IndexOf(' ');
            return space > 0 ? selected[..space] : selected;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Settings.Mode = rdoTcp.Checked ? ConnectionMode.TCP : ConnectionMode.RTU;

            if (Settings.Mode == ConnectionMode.TCP)
            {
                Settings.Ip = GetSelectedIp();
                Settings.Port = int.Parse(txtPort.Text);
            }
            else
            {
                Settings.ComPort = cbComPort.SelectedItem?.ToString() ?? "COM1";
                Settings.BaudRate = (int)(cbBaudRate.SelectedItem ?? 9600);
                Settings.DataBits = (int)(cbDataBits.SelectedItem ?? 8);
                Settings.Parity = (Parity)(cbParity.SelectedItem ?? Parity.None);
                Settings.StopBits = (StopBits)(cbStopBits.SelectedItem ?? StopBits.One);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            BtnOk_Click(sender, e);

            // Write to AppConfig and save
            var cfg = AppConfig.Modbus;
            cfg.Mode = Settings.Mode.ToString();
            cfg.Ip = Settings.Ip;
            cfg.Port = Settings.Port;
            cfg.ComPort = Settings.ComPort;
            cfg.BaudRate = Settings.BaudRate;
            cfg.DataBits = Settings.DataBits;
            cfg.Parity = Settings.Parity.ToString();
            cfg.StopBits = Settings.StopBits.ToString();

            AppConfig.Save();
            MessageBox.Show("Settings saved.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
