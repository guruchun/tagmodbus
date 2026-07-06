namespace TagModbus
{
    partial class FormClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClient));
            panelTop = new System.Windows.Forms.Panel();
            grpOptions = new System.Windows.Forms.GroupBox();
            tblOptions = new System.Windows.Forms.TableLayoutPanel();
            flowOptRow1 = new System.Windows.Forms.FlowLayoutPanel();
            label16 = new System.Windows.Forms.Label();
            cbBindingMap = new System.Windows.Forms.ComboBox();
            flowOptRow2 = new System.Windows.Forms.FlowLayoutPanel();
            chkMonitoring = new System.Windows.Forms.CheckBox();
            txtInterval = new System.Windows.Forms.TextBox();
            label14 = new System.Windows.Forms.Label();
            chkCycleAll = new System.Windows.Forms.CheckBox();
            flowOptRow3 = new System.Windows.Forms.FlowLayoutPanel();
            chkHexView = new System.Windows.Forms.CheckBox();
            label19 = new System.Windows.Forms.Label();
            txtSearch = new System.Windows.Forms.TextBox();
            grpCommand = new System.Windows.Forms.GroupBox();
            tblCommand = new System.Windows.Forms.TableLayoutPanel();
            flowCmdRow1 = new System.Windows.Forms.FlowLayoutPanel();
            label3 = new System.Windows.Forms.Label();
            cbRegType = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
            cbFunction = new System.Windows.Forms.ComboBox();
            flowCmdRow2 = new System.Windows.Forms.FlowLayoutPanel();
            label5 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            txtAddrOffset = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            txtAddrStart = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            txtAddrQty = new System.Windows.Forms.TextBox();
            flowCmdRow3 = new System.Windows.Forms.FlowLayoutPanel();
            rdSingle = new System.Windows.Forms.RadioButton();
            rdMultiple = new System.Windows.Forms.RadioButton();
            rdMixed = new System.Windows.Forms.RadioButton();
            btnRead = new System.Windows.Forms.Button();
            btnExec = new System.Windows.Forms.Button();
            grpConnection = new System.Windows.Forms.GroupBox();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            rdoTcp = new System.Windows.Forms.RadioButton();
            rdoRtu = new System.Windows.Forms.RadioButton();
            btnSettings = new System.Windows.Forms.Button();
            txtConnInfo = new System.Windows.Forms.TextBox();
            lblUnitId = new System.Windows.Forms.Label();
            txtUnitId = new System.Windows.Forms.TextBox();
            lblRespTimeout = new System.Windows.Forms.Label();
            txtRespTimeout = new System.Windows.Forms.TextBox();
            flowBtnComm = new System.Windows.Forms.FlowLayoutPanel();
            picConnState = new System.Windows.Forms.PictureBox();
            btnConnect = new System.Windows.Forms.Button();
            btnDisconnect = new System.Windows.Forms.Button();
            label4 = new System.Windows.Forms.Label();
            panelBottom = new System.Windows.Forms.Panel();
            tableOnBottom = new System.Windows.Forms.TableLayoutPanel();
            flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            panelMiddle = new System.Windows.Forms.Panel();
            dgvModbus = new System.Windows.Forms.DataGridView();
            Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Converted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Format = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ScaleFactor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            panelTop.SuspendLayout();
            grpOptions.SuspendLayout();
            tblOptions.SuspendLayout();
            flowOptRow1.SuspendLayout();
            flowOptRow2.SuspendLayout();
            flowOptRow3.SuspendLayout();
            grpCommand.SuspendLayout();
            tblCommand.SuspendLayout();
            flowCmdRow1.SuspendLayout();
            flowCmdRow2.SuspendLayout();
            flowCmdRow3.SuspendLayout();
            grpConnection.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowBtnComm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picConnState).BeginInit();
            panelBottom.SuspendLayout();
            tableOnBottom.SuspendLayout();
            panelMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvModbus).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(grpOptions);
            panelTop.Controls.Add(grpCommand);
            panelTop.Controls.Add(grpConnection);
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new System.Windows.Forms.Padding(10);
            panelTop.Size = new System.Drawing.Size(1123, 130);
            panelTop.TabIndex = 9;
            // 
            // grpOptions
            // 
            grpOptions.Controls.Add(tblOptions);
            grpOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            grpOptions.Location = new System.Drawing.Point(820, 10);
            grpOptions.Name = "grpOptions";
            grpOptions.Size = new System.Drawing.Size(293, 110);
            grpOptions.TabIndex = 2;
            grpOptions.TabStop = false;
            grpOptions.Text = "Options";
            // 
            // tblOptions
            // 
            tblOptions.ColumnCount = 1;
            tblOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tblOptions.Controls.Add(flowOptRow1, 0, 0);
            tblOptions.Controls.Add(flowOptRow2, 0, 1);
            tblOptions.Controls.Add(flowOptRow3, 0, 2);
            tblOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            tblOptions.Location = new System.Drawing.Point(3, 19);
            tblOptions.Name = "tblOptions";
            tblOptions.RowCount = 3;
            tblOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            tblOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            tblOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            tblOptions.Size = new System.Drawing.Size(287, 88);
            tblOptions.TabIndex = 0;
            // 
            // flowOptRow1
            // 
            flowOptRow1.Controls.Add(label16);
            flowOptRow1.Controls.Add(cbBindingMap);
            flowOptRow1.Dock = System.Windows.Forms.DockStyle.Fill;
            flowOptRow1.Location = new System.Drawing.Point(3, 3);
            flowOptRow1.Name = "flowOptRow1";
            flowOptRow1.Size = new System.Drawing.Size(281, 23);
            flowOptRow1.TabIndex = 0;
            // 
            // label16
            // 
            label16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(10, 6);
            label16.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(78, 15);
            label16.TabIndex = 88;
            label16.Text = "Binding Map:";
            // 
            // cbBindingMap
            // 
            cbBindingMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbBindingMap.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            cbBindingMap.FormattingEnabled = true;
            cbBindingMap.Location = new System.Drawing.Point(94, 3);
            cbBindingMap.Name = "cbBindingMap";
            cbBindingMap.Size = new System.Drawing.Size(176, 22);
            cbBindingMap.TabIndex = 102;
            // 
            // flowOptRow2
            // 
            flowOptRow2.Controls.Add(chkMonitoring);
            flowOptRow2.Controls.Add(txtInterval);
            flowOptRow2.Controls.Add(label14);
            flowOptRow2.Controls.Add(chkCycleAll);
            flowOptRow2.Dock = System.Windows.Forms.DockStyle.Fill;
            flowOptRow2.Location = new System.Drawing.Point(3, 32);
            flowOptRow2.Name = "flowOptRow2";
            flowOptRow2.Size = new System.Drawing.Size(281, 23);
            flowOptRow2.TabIndex = 1;
            // 
            // chkMonitoring
            // 
            chkMonitoring.Anchor = System.Windows.Forms.AnchorStyles.None;
            chkMonitoring.AutoSize = true;
            chkMonitoring.Location = new System.Drawing.Point(10, 5);
            chkMonitoring.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            chkMonitoring.Name = "chkMonitoring";
            chkMonitoring.Size = new System.Drawing.Size(86, 19);
            chkMonitoring.TabIndex = 0;
            chkMonitoring.Text = "Monitoring";
            chkMonitoring.UseVisualStyleBackColor = true;
            chkMonitoring.CheckedChanged += chkMonitoring_CheckedChanged;
            // 
            // txtInterval
            // 
            txtInterval.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtInterval.Location = new System.Drawing.Point(102, 3);
            txtInterval.Name = "txtInterval";
            txtInterval.Size = new System.Drawing.Size(48, 23);
            txtInterval.TabIndex = 111;
            txtInterval.TextChanged += txtInterval_TextChanged;
            // 
            // label14
            // 
            label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(154, 7);
            label14.Margin = new System.Windows.Forms.Padding(1);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(31, 15);
            label14.TabIndex = 112;
            label14.Text = "(ms)";
            // 
            // chkCycleAll
            // 
            chkCycleAll.Anchor = System.Windows.Forms.AnchorStyles.None;
            chkCycleAll.AutoSize = true;
            chkCycleAll.Location = new System.Drawing.Point(189, 5);
            chkCycleAll.Name = "chkCycleAll";
            chkCycleAll.Size = new System.Drawing.Size(82, 19);
            chkCycleAll.TabIndex = 0;
            chkCycleAll.Text = "Cycle Data";
            chkCycleAll.UseVisualStyleBackColor = true;
            chkCycleAll.CheckedChanged += chkMonitoring_CheckedChanged;
            // 
            // flowOptRow3
            // 
            flowOptRow3.Controls.Add(chkHexView);
            flowOptRow3.Controls.Add(label19);
            flowOptRow3.Controls.Add(txtSearch);
            flowOptRow3.Dock = System.Windows.Forms.DockStyle.Fill;
            flowOptRow3.Location = new System.Drawing.Point(3, 61);
            flowOptRow3.Name = "flowOptRow3";
            flowOptRow3.Size = new System.Drawing.Size(281, 24);
            flowOptRow3.TabIndex = 2;
            // 
            // chkHexView
            // 
            chkHexView.Anchor = System.Windows.Forms.AnchorStyles.None;
            chkHexView.AutoSize = true;
            chkHexView.Checked = true;
            chkHexView.CheckState = System.Windows.Forms.CheckState.Checked;
            chkHexView.Location = new System.Drawing.Point(10, 5);
            chkHexView.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            chkHexView.Name = "chkHexView";
            chkHexView.Size = new System.Drawing.Size(87, 19);
            chkHexView.TabIndex = 0;
            chkHexView.Text = "Display Hex";
            chkHexView.UseVisualStyleBackColor = true;
            chkHexView.CheckedChanged += chkHexView_CheckedChanged;
            // 
            // label19
            // 
            label19.Anchor = System.Windows.Forms.AnchorStyles.None;
            label19.AutoSize = true;
            label19.Location = new System.Drawing.Point(110, 7);
            label19.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(45, 15);
            label19.TabIndex = 88;
            label19.Text = "Search:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new System.Drawing.Point(161, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(110, 23);
            txtSearch.TabIndex = 91;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // grpCommand
            // 
            grpCommand.Controls.Add(tblCommand);
            grpCommand.Dock = System.Windows.Forms.DockStyle.Left;
            grpCommand.Location = new System.Drawing.Point(357, 10);
            grpCommand.Name = "grpCommand";
            grpCommand.Size = new System.Drawing.Size(463, 110);
            grpCommand.TabIndex = 1;
            grpCommand.TabStop = false;
            grpCommand.Text = "Modbus Request";
            // 
            // tblCommand
            // 
            tblCommand.ColumnCount = 2;
            tblCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tblCommand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            tblCommand.Controls.Add(flowCmdRow1, 0, 0);
            tblCommand.Controls.Add(flowCmdRow2, 0, 1);
            tblCommand.Controls.Add(flowCmdRow3, 0, 2);
            tblCommand.Controls.Add(btnRead, 1, 1);
            tblCommand.Controls.Add(btnExec, 1, 2);
            tblCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            tblCommand.Location = new System.Drawing.Point(3, 19);
            tblCommand.Name = "tblCommand";
            tblCommand.RowCount = 3;
            tblCommand.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            tblCommand.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            tblCommand.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            tblCommand.Size = new System.Drawing.Size(457, 88);
            tblCommand.TabIndex = 0;
            // 
            // flowCmdRow1
            // 
            flowCmdRow1.Controls.Add(label3);
            flowCmdRow1.Controls.Add(cbRegType);
            flowCmdRow1.Controls.Add(label6);
            flowCmdRow1.Controls.Add(cbFunction);
            flowCmdRow1.Dock = System.Windows.Forms.DockStyle.Fill;
            flowCmdRow1.Location = new System.Drawing.Point(3, 3);
            flowCmdRow1.Name = "flowCmdRow1";
            flowCmdRow1.Size = new System.Drawing.Size(375, 23);
            flowCmdRow1.TabIndex = 0;
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(10, 6);
            label3.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(55, 15);
            label3.TabIndex = 116;
            label3.Text = "RegType:";
            // 
            // cbRegType
            // 
            cbRegType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbRegType.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            cbRegType.FormattingEnabled = true;
            cbRegType.Location = new System.Drawing.Point(71, 3);
            cbRegType.Name = "cbRegType";
            cbRegType.Size = new System.Drawing.Size(116, 22);
            cbRegType.TabIndex = 102;
            // 
            // label6
            // 
            label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(200, 6);
            label6.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(36, 15);
            label6.TabIndex = 95;
            label6.Text = "Func:";
            // 
            // cbFunction
            // 
            cbFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbFunction.Enabled = false;
            cbFunction.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            cbFunction.FormattingEnabled = true;
            cbFunction.Location = new System.Drawing.Point(242, 3);
            cbFunction.Name = "cbFunction";
            cbFunction.Size = new System.Drawing.Size(89, 22);
            cbFunction.TabIndex = 102;
            // 
            // flowCmdRow2
            // 
            flowCmdRow2.Controls.Add(label5);
            flowCmdRow2.Controls.Add(label1);
            flowCmdRow2.Controls.Add(txtAddrOffset);
            flowCmdRow2.Controls.Add(label7);
            flowCmdRow2.Controls.Add(txtAddrStart);
            flowCmdRow2.Controls.Add(label8);
            flowCmdRow2.Controls.Add(txtAddrQty);
            flowCmdRow2.Dock = System.Windows.Forms.DockStyle.Fill;
            flowCmdRow2.Location = new System.Drawing.Point(3, 32);
            flowCmdRow2.Name = "flowCmdRow2";
            flowCmdRow2.Size = new System.Drawing.Size(375, 23);
            flowCmdRow2.TabIndex = 1;
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(10, 7);
            label5.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(57, 15);
            label5.TabIndex = 110;
            label5.Text = "(Address)";
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(75, 7);
            label1.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(34, 15);
            label1.TabIndex = 115;
            label1.Text = "Base:";
            // 
            // txtAddrOffset
            // 
            txtAddrOffset.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtAddrOffset.Location = new System.Drawing.Point(115, 3);
            txtAddrOffset.Name = "txtAddrOffset";
            txtAddrOffset.Size = new System.Drawing.Size(48, 23);
            txtAddrOffset.TabIndex = 109;
            // 
            // label7
            // 
            label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(171, 7);
            label7.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(34, 15);
            label7.TabIndex = 111;
            label7.Text = "Start:";
            // 
            // txtAddrStart
            // 
            txtAddrStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtAddrStart.Location = new System.Drawing.Point(211, 3);
            txtAddrStart.Name = "txtAddrStart";
            txtAddrStart.Size = new System.Drawing.Size(48, 23);
            txtAddrStart.TabIndex = 112;
            // 
            // label8
            // 
            label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(267, 7);
            label8.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(56, 15);
            label8.TabIndex = 113;
            label8.Text = "Quantity:";
            // 
            // txtAddrQty
            // 
            txtAddrQty.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtAddrQty.Location = new System.Drawing.Point(329, 3);
            txtAddrQty.Name = "txtAddrQty";
            txtAddrQty.Size = new System.Drawing.Size(30, 23);
            txtAddrQty.TabIndex = 114;
            // 
            // flowCmdRow3
            // 
            flowCmdRow3.Controls.Add(rdSingle);
            flowCmdRow3.Controls.Add(rdMultiple);
            flowCmdRow3.Controls.Add(rdMixed);
            flowCmdRow3.Dock = System.Windows.Forms.DockStyle.Fill;
            flowCmdRow3.Location = new System.Drawing.Point(3, 61);
            flowCmdRow3.Name = "flowCmdRow3";
            flowCmdRow3.Size = new System.Drawing.Size(375, 24);
            flowCmdRow3.TabIndex = 2;
            // 
            // rdSingle
            // 
            rdSingle.AutoSize = true;
            rdSingle.Location = new System.Drawing.Point(10, 3);
            rdSingle.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            rdSingle.Name = "rdSingle";
            rdSingle.Size = new System.Drawing.Size(57, 19);
            rdSingle.TabIndex = 0;
            rdSingle.Text = "Single";
            // 
            // rdMultiple
            // 
            rdMultiple.AutoSize = true;
            rdMultiple.Location = new System.Drawing.Point(73, 3);
            rdMultiple.Name = "rdMultiple";
            rdMultiple.Size = new System.Drawing.Size(69, 19);
            rdMultiple.TabIndex = 1;
            rdMultiple.Text = "Multiple";
            // 
            // rdMixed
            // 
            rdMixed.AutoSize = true;
            rdMixed.Checked = true;
            rdMixed.Location = new System.Drawing.Point(148, 3);
            rdMixed.Name = "rdMixed";
            rdMixed.Size = new System.Drawing.Size(57, 19);
            rdMixed.TabIndex = 2;
            rdMixed.TabStop = true;
            rdMixed.Text = "Mixed";
            // 
            // btnRead
            // 
            btnRead.Dock = System.Windows.Forms.DockStyle.Fill;
            btnRead.Location = new System.Drawing.Point(384, 32);
            btnRead.Name = "btnRead";
            btnRead.Size = new System.Drawing.Size(70, 23);
            btnRead.TabIndex = 109;
            btnRead.Text = "Read";
            btnRead.UseVisualStyleBackColor = true;
            btnRead.Click += btnRead_Click;
            // 
            // btnExec
            // 
            btnExec.Dock = System.Windows.Forms.DockStyle.Fill;
            btnExec.Location = new System.Drawing.Point(384, 61);
            btnExec.Name = "btnExec";
            btnExec.Size = new System.Drawing.Size(70, 24);
            btnExec.TabIndex = 110;
            btnExec.Text = "Write";
            btnExec.UseVisualStyleBackColor = true;
            btnExec.Click += btnExec_Click;
            // 
            // grpConnection
            // 
            grpConnection.Controls.Add(flowLayoutPanel2);
            grpConnection.Controls.Add(flowBtnComm);
            grpConnection.Dock = System.Windows.Forms.DockStyle.Left;
            grpConnection.Location = new System.Drawing.Point(10, 10);
            grpConnection.Name = "grpConnection";
            grpConnection.Size = new System.Drawing.Size(347, 110);
            grpConnection.TabIndex = 0;
            grpConnection.TabStop = false;
            grpConnection.Text = "Communication Setup";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(rdoTcp);
            flowLayoutPanel2.Controls.Add(rdoRtu);
            flowLayoutPanel2.Controls.Add(btnSettings);
            flowLayoutPanel2.Controls.Add(txtConnInfo);
            flowLayoutPanel2.Controls.Add(lblUnitId);
            flowLayoutPanel2.Controls.Add(txtUnitId);
            flowLayoutPanel2.Controls.Add(lblRespTimeout);
            flowLayoutPanel2.Controls.Add(txtRespTimeout);
            flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            flowLayoutPanel2.Location = new System.Drawing.Point(3, 19);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new System.Drawing.Size(341, 55);
            flowLayoutPanel2.TabIndex = 103;
            // 
            // rdoTcp
            // 
            rdoTcp.AutoSize = true;
            rdoTcp.Checked = true;
            rdoTcp.Location = new System.Drawing.Point(5, 3);
            rdoTcp.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            rdoTcp.Name = "rdoTcp";
            rdoTcp.Size = new System.Drawing.Size(46, 19);
            rdoTcp.TabIndex = 120;
            rdoTcp.TabStop = true;
            rdoTcp.Text = "TCP";
            // 
            // rdoRtu
            // 
            rdoRtu.AutoSize = true;
            rdoRtu.Location = new System.Drawing.Point(57, 3);
            rdoRtu.Name = "rdoRtu";
            rdoRtu.Size = new System.Drawing.Size(46, 19);
            rdoRtu.TabIndex = 121;
            rdoRtu.Text = "RTU";
            // 
            // btnSettings
            // 
            btnSettings.Location = new System.Drawing.Point(109, 3);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new System.Drawing.Size(76, 24);
            btnSettings.TabIndex = 123;
            btnSettings.Text = "Settings...";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // txtConnInfo
            // 
            txtConnInfo.Location = new System.Drawing.Point(193, 3);
            txtConnInfo.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            txtConnInfo.Name = "txtConnInfo";
            txtConnInfo.ReadOnly = true;
            txtConnInfo.Size = new System.Drawing.Size(131, 23);
            txtConnInfo.TabIndex = 122;
            // 
            // lblUnitId
            // 
            lblUnitId.AutoSize = true;
            lblUnitId.Location = new System.Drawing.Point(5, 33);
            lblUnitId.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            lblUnitId.Name = "lblUnitId";
            lblUnitId.Size = new System.Drawing.Size(32, 15);
            lblUnitId.TabIndex = 130;
            lblUnitId.Text = "Unit:";
            // 
            // txtUnitId
            // 
            txtUnitId.Location = new System.Drawing.Point(43, 33);
            txtUnitId.Name = "txtUnitId";
            txtUnitId.Size = new System.Drawing.Size(35, 23);
            txtUnitId.TabIndex = 131;
            txtUnitId.Text = "1";
            // 
            // lblRespTimeout
            // 
            lblRespTimeout.AutoSize = true;
            lblRespTimeout.Location = new System.Drawing.Point(89, 33);
            lblRespTimeout.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            lblRespTimeout.Name = "lblRespTimeout";
            lblRespTimeout.Size = new System.Drawing.Size(108, 15);
            lblRespTimeout.TabIndex = 132;
            lblRespTimeout.Text = "Response Timeout:";
            // 
            // txtRespTimeout
            // 
            txtRespTimeout.Location = new System.Drawing.Point(203, 33);
            txtRespTimeout.Name = "txtRespTimeout";
            txtRespTimeout.Size = new System.Drawing.Size(50, 23);
            txtRespTimeout.TabIndex = 133;
            txtRespTimeout.Text = "1000";
            // 
            // flowBtnComm
            // 
            flowBtnComm.Controls.Add(picConnState);
            flowBtnComm.Controls.Add(btnConnect);
            flowBtnComm.Controls.Add(btnDisconnect);
            flowBtnComm.Dock = System.Windows.Forms.DockStyle.Bottom;
            flowBtnComm.Location = new System.Drawing.Point(3, 77);
            flowBtnComm.Name = "flowBtnComm";
            flowBtnComm.Size = new System.Drawing.Size(341, 30);
            flowBtnComm.TabIndex = 130;
            // 
            // picConnState
            // 
            picConnState.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            picConnState.Dock = System.Windows.Forms.DockStyle.Bottom;
            picConnState.Image = Properties.Resources.dot_gray;
            picConnState.Location = new System.Drawing.Point(5, 4);
            picConnState.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            picConnState.Name = "picConnState";
            picConnState.Size = new System.Drawing.Size(25, 25);
            picConnState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            picConnState.TabIndex = 125;
            picConnState.TabStop = false;
            // 
            // btnConnect
            // 
            btnConnect.Location = new System.Drawing.Point(36, 3);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new System.Drawing.Size(136, 26);
            btnConnect.TabIndex = 99;
            btnConnect.Text = "Open(Connect)";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new System.Drawing.Point(178, 3);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new System.Drawing.Size(136, 26);
            btnDisconnect.TabIndex = 99;
            btnDisconnect.Text = "Close(Disconnect)";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // label4
            // 
            label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            label4.Location = new System.Drawing.Point(170, 7);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(55, 23);
            label4.TabIndex = 124;
            label4.Text = "Status";
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(tableOnBottom);
            panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelBottom.Location = new System.Drawing.Point(0, 551);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new System.Drawing.Size(1123, 32);
            panelBottom.TabIndex = 10;
            // 
            // tableOnBottom
            // 
            tableOnBottom.ColumnCount = 1;
            tableOnBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 332F));
            tableOnBottom.Controls.Add(flowLayoutPanel4, 0, 0);
            tableOnBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            tableOnBottom.Location = new System.Drawing.Point(0, 0);
            tableOnBottom.Name = "tableOnBottom";
            tableOnBottom.RowCount = 1;
            tableOnBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableOnBottom.Size = new System.Drawing.Size(1123, 32);
            tableOnBottom.TabIndex = 0;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new System.Drawing.Size(1117, 26);
            flowLayoutPanel4.TabIndex = 111;
            // 
            // panelMiddle
            // 
            panelMiddle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panelMiddle.Controls.Add(dgvModbus);
            panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMiddle.Location = new System.Drawing.Point(0, 130);
            panelMiddle.Name = "panelMiddle";
            panelMiddle.Padding = new System.Windows.Forms.Padding(10);
            panelMiddle.Size = new System.Drawing.Size(1123, 421);
            panelMiddle.TabIndex = 11;
            // 
            // dgvModbus
            // 
            dgvModbus.AllowUserToAddRows = false;
            dgvModbus.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dgvModbus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvModbus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Address, Value, Converted, DataType, Format, ScaleFactor, Tag, Description });
            dgvModbus.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvModbus.Location = new System.Drawing.Point(10, 10);
            dgvModbus.Name = "dgvModbus";
            dgvModbus.RowHeadersWidth = 62;
            dgvModbus.RowTemplate.Height = 23;
            dgvModbus.Size = new System.Drawing.Size(1103, 401);
            dgvModbus.TabIndex = 86;
            dgvModbus.CurrentCellDirtyStateChanged += dgvModbus_CurrentCellDirtyStateChanged;
            dgvModbus.DoubleClick += dgvModbus_DoubleClick;
            // 
            // Address
            // 
            Address.DataPropertyName = "Address";
            Address.HeaderText = "Address";
            Address.MinimumWidth = 8;
            Address.Name = "Address";
            Address.ReadOnly = true;
            Address.Width = 65;
            // 
            // Value
            // 
            Value.DataPropertyName = "RawValue";
            Value.HeaderText = "Raw Value";
            Value.MinimumWidth = 8;
            Value.Name = "Value";
            Value.Width = 75;
            // 
            // Converted
            // 
            Converted.DataPropertyName = "Converted";
            Converted.HeaderText = "Converted";
            Converted.Name = "Converted";
            Converted.ReadOnly = true;
            Converted.Width = 90;
            // 
            // DataType
            // 
            DataType.DataPropertyName = "Type";
            DataType.HeaderText = "Type";
            DataType.MinimumWidth = 8;
            DataType.Name = "DataType";
            DataType.ReadOnly = true;
            DataType.Width = 50;
            // 
            // Format
            // 
            Format.DataPropertyName = "Format";
            Format.HeaderText = "Format";
            Format.MinimumWidth = 8;
            Format.Name = "Format";
            Format.ReadOnly = true;
            Format.Width = 55;
            // 
            // ScaleFactor
            // 
            ScaleFactor.DataPropertyName = "Scale";
            ScaleFactor.HeaderText = "Scale";
            ScaleFactor.MinimumWidth = 8;
            ScaleFactor.Name = "ScaleFactor";
            ScaleFactor.ReadOnly = true;
            ScaleFactor.Width = 45;
            // 
            // Tag
            // 
            Tag.DataPropertyName = "Tag";
            Tag.HeaderText = "Tag";
            Tag.MinimumWidth = 8;
            Tag.Name = "Tag";
            Tag.ReadOnly = true;
            Tag.Width = 150;
            // 
            // Description
            // 
            Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            Description.DataPropertyName = "Description";
            Description.HeaderText = "Description";
            Description.MinimumWidth = 8;
            Description.Name = "Description";
            Description.ReadOnly = true;
            // 
            // FormClient
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            AutoScroll = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ClientSize = new System.Drawing.Size(1123, 583);
            CloseButton = false;
            CloseButtonVisible = false;
            Controls.Add(panelMiddle);
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            HideOnClose = true;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "FormClient";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Modbus Client";
            Load += Form_Load;
            HelpRequested += Form_HelpRequested;
            panelTop.ResumeLayout(false);
            grpOptions.ResumeLayout(false);
            tblOptions.ResumeLayout(false);
            flowOptRow1.ResumeLayout(false);
            flowOptRow1.PerformLayout();
            flowOptRow2.ResumeLayout(false);
            flowOptRow2.PerformLayout();
            flowOptRow3.ResumeLayout(false);
            flowOptRow3.PerformLayout();
            grpCommand.ResumeLayout(false);
            tblCommand.ResumeLayout(false);
            flowCmdRow1.ResumeLayout(false);
            flowCmdRow1.PerformLayout();
            flowCmdRow2.ResumeLayout(false);
            flowCmdRow2.PerformLayout();
            flowCmdRow3.ResumeLayout(false);
            flowCmdRow3.PerformLayout();
            grpConnection.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowBtnComm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picConnState).EndInit();
            panelBottom.ResumeLayout(false);
            tableOnBottom.ResumeLayout(false);
            panelMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvModbus).EndInit();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.GroupBox grpConnection;
        private System.Windows.Forms.GroupBox grpCommand;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.TableLayoutPanel tblOptions;
        private System.Windows.Forms.FlowLayoutPanel flowOptRow1;
        private System.Windows.Forms.FlowLayoutPanel flowOptRow2;
        private System.Windows.Forms.FlowLayoutPanel flowOptRow3;
        private System.Windows.Forms.CheckBox chkHexView;
        private System.Windows.Forms.TableLayoutPanel tblCommand;
        private System.Windows.Forms.FlowLayoutPanel flowCmdRow1;
        private System.Windows.Forms.FlowLayoutPanel flowCmdRow2;
        private System.Windows.Forms.FlowLayoutPanel flowCmdRow3;
        private System.Windows.Forms.FlowLayoutPanel flowBtnComm;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton rdoTcp;
        private System.Windows.Forms.RadioButton rdoRtu;
        private System.Windows.Forms.TextBox txtConnInfo;
        private System.Windows.Forms.Label lblUnitId;
        private System.Windows.Forms.TextBox txtUnitId;
        private System.Windows.Forms.Label lblRespTimeout;
        private System.Windows.Forms.TextBox txtRespTimeout;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picConnState;
        private System.Windows.Forms.Button btnExec;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAddrOffset;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbFunction;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAddrStart;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAddrQty;
        private System.Windows.Forms.TableLayoutPanel tableOnBottom;
        private System.Windows.Forms.Panel panelMiddle;
        private System.Windows.Forms.DataGridView dgvModbus;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbBindingMap;
        private System.Windows.Forms.CheckBox chkMonitoring;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbRegType;
        private System.Windows.Forms.RadioButton rdSingle;
        private System.Windows.Forms.RadioButton rdMultiple;
        private System.Windows.Forms.RadioButton rdMixed;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.CheckBox chkCycleAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Converted;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Format;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScaleFactor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
    }
}
