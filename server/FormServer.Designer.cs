
namespace TagModbusSvr
{
    partial class FormServer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormServer));
            tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            tabUpper = new System.Windows.Forms.TableLayoutPanel();
            grpConnection = new System.Windows.Forms.GroupBox();
            rdoTcp = new System.Windows.Forms.RadioButton();
            rdoRtu = new System.Windows.Forms.RadioButton();
            txtConnInfo = new System.Windows.Forms.TextBox();
            lblUnitId = new System.Windows.Forms.Label();
            txtUnitId = new System.Windows.Forms.TextBox();
            btnSettings = new System.Windows.Forms.Button();
            grpMap = new System.Windows.Forms.GroupBox();
            lblMap = new System.Windows.Forms.Label();
            cbBindingMap = new System.Windows.Forms.ComboBox();
            txtMapFile = new System.Windows.Forms.TextBox();
            grpControl = new System.Windows.Forms.GroupBox();
            btnStop = new System.Windows.Forms.Button();
            btnStart = new System.Windows.Forms.Button();
            clientCount = new System.Windows.Forms.Label();
            lblClients = new System.Windows.Forms.Label();
            panel4 = new System.Windows.Forms.Panel();
            DataQty = new System.Windows.Forms.TextBox();
            CmdRead = new System.Windows.Forms.Button();
            txtSearch = new System.Windows.Forms.TextBox();
            label23 = new System.Windows.Forms.Label();
            StartAddr = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            tabDisplay = new System.Windows.Forms.TabControl();
            pageRegs = new System.Windows.Forms.TabPage();
            dgvRegs = new System.Windows.Forms.DataGridView();
            regAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            regValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            regDataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            regFormat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            regScale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            regTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            regDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            pageBits = new System.Windows.Forms.TabPage();
            dgvBits = new System.Windows.Forms.DataGridView();
            bitAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            bitValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            bitTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            bitDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            CmdReadTag = new System.Windows.Forms.Button();
            tableLayoutMain.SuspendLayout();
            tabUpper.SuspendLayout();
            grpConnection.SuspendLayout();
            grpMap.SuspendLayout();
            grpControl.SuspendLayout();
            panel4.SuspendLayout();
            tabDisplay.SuspendLayout();
            pageRegs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRegs).BeginInit();
            pageBits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBits).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutMain
            // 
            tableLayoutMain.AutoScroll = true;
            tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutMain.Controls.Add(tabUpper, 0, 0);
            tableLayoutMain.Controls.Add(panel4, 0, 1);
            tableLayoutMain.Controls.Add(tabDisplay, 0, 2);
            tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutMain.Location = new System.Drawing.Point(0, 0);
            tableLayoutMain.Name = "tableLayoutMain";
            tableLayoutMain.RowCount = 3;
            tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 156F));
            tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutMain.Size = new System.Drawing.Size(810, 612);
            tableLayoutMain.TabIndex = 11;
            // 
            // tabUpper
            // 
            tabUpper.ColumnCount = 3;
            tabUpper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            tabUpper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            tabUpper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            tabUpper.Controls.Add(grpConnection, 0, 0);
            tabUpper.Controls.Add(grpMap, 1, 0);
            tabUpper.Controls.Add(grpControl, 2, 0);
            tabUpper.Dock = System.Windows.Forms.DockStyle.Fill;
            tabUpper.Location = new System.Drawing.Point(3, 3);
            tabUpper.Name = "tabUpper";
            tabUpper.RowCount = 1;
            tabUpper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tabUpper.Size = new System.Drawing.Size(804, 150);
            tabUpper.TabIndex = 21;
            // 
            // grpConnection
            // 
            grpConnection.Controls.Add(rdoTcp);
            grpConnection.Controls.Add(rdoRtu);
            grpConnection.Controls.Add(txtConnInfo);
            grpConnection.Controls.Add(lblUnitId);
            grpConnection.Controls.Add(txtUnitId);
            grpConnection.Controls.Add(btnSettings);
            grpConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            grpConnection.Font = new System.Drawing.Font("Segoe UI", 9F);
            grpConnection.Location = new System.Drawing.Point(3, 3);
            grpConnection.Name = "grpConnection";
            grpConnection.Size = new System.Drawing.Size(261, 144);
            grpConnection.TabIndex = 0;
            grpConnection.TabStop = false;
            grpConnection.Text = "Communication";
            // 
            // rdoTcp
            // 
            rdoTcp.AutoSize = true;
            rdoTcp.Checked = true;
            rdoTcp.Location = new System.Drawing.Point(15, 25);
            rdoTcp.Name = "rdoTcp";
            rdoTcp.Size = new System.Drawing.Size(46, 19);
            rdoTcp.TabIndex = 0;
            rdoTcp.TabStop = true;
            rdoTcp.Text = "TCP";
            rdoTcp.CheckedChanged += rdoMode_CheckedChanged;
            // 
            // rdoRtu
            // 
            rdoRtu.AutoSize = true;
            rdoRtu.Location = new System.Drawing.Point(75, 25);
            rdoRtu.Name = "rdoRtu";
            rdoRtu.Size = new System.Drawing.Size(46, 19);
            rdoRtu.TabIndex = 1;
            rdoRtu.Text = "RTU";
            // 
            // txtConnInfo
            // 
            txtConnInfo.BackColor = System.Drawing.SystemColors.Window;
            txtConnInfo.Location = new System.Drawing.Point(15, 56);
            txtConnInfo.Name = "txtConnInfo";
            txtConnInfo.ReadOnly = true;
            txtConnInfo.Size = new System.Drawing.Size(219, 23);
            txtConnInfo.TabIndex = 2;
            // 
            // lblUnitId
            // 
            lblUnitId.AutoSize = true;
            lblUnitId.Location = new System.Drawing.Point(15, 92);
            lblUnitId.Name = "lblUnitId";
            lblUnitId.Size = new System.Drawing.Size(81, 15);
            lblUnitId.TabIndex = 3;
            lblUnitId.Text = "Unit(Slave) ID:";
            // 
            // txtUnitId
            // 
            txtUnitId.Location = new System.Drawing.Point(108, 88);
            txtUnitId.Name = "txtUnitId";
            txtUnitId.Size = new System.Drawing.Size(40, 23);
            txtUnitId.TabIndex = 3;
            txtUnitId.Text = "1";
            txtUnitId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSettings
            // 
            btnSettings.Location = new System.Drawing.Point(144, 20);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new System.Drawing.Size(90, 28);
            btnSettings.TabIndex = 4;
            btnSettings.Text = "Settings...";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // grpMap
            // 
            grpMap.Controls.Add(lblMap);
            grpMap.Controls.Add(cbBindingMap);
            grpMap.Controls.Add(txtMapFile);
            grpMap.Dock = System.Windows.Forms.DockStyle.Fill;
            grpMap.Font = new System.Drawing.Font("Segoe UI", 9F);
            grpMap.Location = new System.Drawing.Point(270, 3);
            grpMap.Name = "grpMap";
            grpMap.Size = new System.Drawing.Size(261, 144);
            grpMap.TabIndex = 1;
            grpMap.TabStop = false;
            grpMap.Text = "Modbus Map";
            // 
            // lblMap
            // 
            lblMap.AutoSize = true;
            lblMap.Location = new System.Drawing.Point(15, 28);
            lblMap.Name = "lblMap";
            lblMap.Size = new System.Drawing.Size(78, 15);
            lblMap.TabIndex = 0;
            lblMap.Text = "Binding Map:";
            // 
            // cbBindingMap
            // 
            cbBindingMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbBindingMap.Location = new System.Drawing.Point(15, 56);
            cbBindingMap.Name = "cbBindingMap";
            cbBindingMap.Size = new System.Drawing.Size(180, 23);
            cbBindingMap.TabIndex = 0;
            cbBindingMap.SelectedIndexChanged += cbBindingMap_SelectedIndexChanged;
            // 
            // txtMapFile
            // 
            txtMapFile.BackColor = System.Drawing.SystemColors.Window;
            txtMapFile.Location = new System.Drawing.Point(14, 88);
            txtMapFile.Name = "txtMapFile";
            txtMapFile.ReadOnly = true;
            txtMapFile.Size = new System.Drawing.Size(220, 23);
            txtMapFile.TabIndex = 1;
            // 
            // grpControl
            // 
            grpControl.Controls.Add(btnStop);
            grpControl.Controls.Add(btnStart);
            grpControl.Controls.Add(clientCount);
            grpControl.Controls.Add(lblClients);
            grpControl.Dock = System.Windows.Forms.DockStyle.Fill;
            grpControl.Font = new System.Drawing.Font("Segoe UI", 9F);
            grpControl.Location = new System.Drawing.Point(537, 3);
            grpControl.Name = "grpControl";
            grpControl.Size = new System.Drawing.Size(264, 144);
            grpControl.TabIndex = 2;
            grpControl.TabStop = false;
            grpControl.Text = "Server Control";
            // 
            // btnStop
            // 
            btnStop.Location = new System.Drawing.Point(130, 50);
            btnStop.Name = "btnStop";
            btnStop.Size = new System.Drawing.Size(98, 35);
            btnStop.TabIndex = 0;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new System.Drawing.Point(15, 50);
            btnStart.Name = "btnStart";
            btnStart.Size = new System.Drawing.Size(98, 35);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // clientCount
            // 
            clientCount.AutoSize = true;
            clientCount.Location = new System.Drawing.Point(100, 25);
            clientCount.Name = "clientCount";
            clientCount.Size = new System.Drawing.Size(13, 15);
            clientCount.TabIndex = 1;
            clientCount.Text = "0";
            // 
            // lblClients
            // 
            lblClients.AutoSize = true;
            lblClients.Location = new System.Drawing.Point(15, 25);
            lblClients.Name = "lblClients";
            lblClients.Size = new System.Drawing.Size(77, 15);
            lblClients.TabIndex = 2;
            lblClients.Text = "Connections:";
            // 
            // panel4
            // 
            panel4.Controls.Add(DataQty);
            panel4.Controls.Add(CmdReadTag);
            panel4.Controls.Add(CmdRead);
            panel4.Controls.Add(txtSearch);
            panel4.Controls.Add(label23);
            panel4.Controls.Add(StartAddr);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(label5);
            panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            panel4.Location = new System.Drawing.Point(3, 159);
            panel4.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(804, 35);
            panel4.TabIndex = 0;
            // 
            // DataQty
            // 
            DataQty.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            DataQty.Font = new System.Drawing.Font("Tahoma", 9F);
            DataQty.Location = new System.Drawing.Point(506, 10);
            DataQty.Name = "DataQty";
            DataQty.Size = new System.Drawing.Size(47, 22);
            DataQty.TabIndex = 64;
            DataQty.Text = "20";
            DataQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CmdRead
            // 
            CmdRead.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            CmdRead.Font = new System.Drawing.Font("Tahoma", 9F);
            CmdRead.Location = new System.Drawing.Point(564, 7);
            CmdRead.Name = "CmdRead";
            CmdRead.Size = new System.Drawing.Size(109, 28);
            CmdRead.TabIndex = 59;
            CmdRead.Tag = "";
            CmdRead.Text = "Read Map";
            CmdRead.UseVisualStyleBackColor = true;
            CmdRead.Click += btnReadMap_Click;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = System.Drawing.SystemColors.Window;
            txtSearch.Font = new System.Drawing.Font("Tahoma", 9F);
            txtSearch.Location = new System.Drawing.Point(69, 10);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tag or Description";
            txtSearch.Size = new System.Drawing.Size(141, 22);
            txtSearch.TabIndex = 65;
            txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new System.Drawing.Font("Tahoma", 9F);
            label23.Location = new System.Drawing.Point(14, 16);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(48, 14);
            label23.TabIndex = 63;
            label23.Text = "Search:";
            // 
            // StartAddr
            // 
            StartAddr.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            StartAddr.Font = new System.Drawing.Font("Tahoma", 9F);
            StartAddr.Location = new System.Drawing.Point(395, 10);
            StartAddr.Name = "StartAddr";
            StartAddr.Size = new System.Drawing.Size(51, 22);
            StartAddr.TabIndex = 66;
            StartAddr.Text = "0";
            StartAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            label6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Tahoma", 9F);
            label6.Location = new System.Drawing.Point(310, 16);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(85, 14);
            label6.TabIndex = 62;
            label6.Text = "Start Address:";
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Tahoma", 9F);
            label5.Location = new System.Drawing.Point(448, 16);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(58, 14);
            label5.TabIndex = 61;
            label5.Text = "Quantity:";
            // 
            // tabDisplay
            // 
            tabDisplay.Controls.Add(pageRegs);
            tabDisplay.Controls.Add(pageBits);
            tabDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            tabDisplay.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            tabDisplay.Location = new System.Drawing.Point(10, 199);
            tabDisplay.Margin = new System.Windows.Forms.Padding(10, 5, 10, 10);
            tabDisplay.Name = "tabDisplay";
            tabDisplay.SelectedIndex = 0;
            tabDisplay.Size = new System.Drawing.Size(790, 403);
            tabDisplay.TabIndex = 19;
            tabDisplay.SelectedIndexChanged += tabDisplay_SelectedIndexChanged;
            // 
            // pageRegs
            // 
            pageRegs.Controls.Add(dgvRegs);
            pageRegs.Location = new System.Drawing.Point(4, 23);
            pageRegs.Name = "pageRegs";
            pageRegs.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            pageRegs.Size = new System.Drawing.Size(782, 376);
            pageRegs.TabIndex = 5;
            pageRegs.Text = "Registers";
            pageRegs.UseVisualStyleBackColor = true;
            // 
            // dgvRegs
            // 
            dgvRegs.AllowUserToAddRows = false;
            dgvRegs.AllowUserToDeleteRows = false;
            dgvRegs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvRegs.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dgvRegs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvRegs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvRegs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { regAddress, regValue, regDataType, regFormat, regScale, regTag, regDesc });
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvRegs.DefaultCellStyle = dataGridViewCellStyle4;
            dgvRegs.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvRegs.GridColor = System.Drawing.SystemColors.ScrollBar;
            dgvRegs.Location = new System.Drawing.Point(0, 5);
            dgvRegs.Name = "dgvRegs";
            dgvRegs.RowHeadersVisible = false;
            dgvRegs.RowHeadersWidth = 62;
            dgvRegs.RowTemplate.Height = 23;
            dgvRegs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            dgvRegs.Size = new System.Drawing.Size(782, 371);
            dgvRegs.TabIndex = 59;
            dgvRegs.CellValueChanged += dgvRegs_CellValueChanged;
            // 
            // regAddress
            // 
            regAddress.HeaderText = "Address";
            regAddress.MinimumWidth = 8;
            regAddress.Name = "regAddress";
            regAddress.Width = 75;
            // 
            // regValue
            // 
            regValue.HeaderText = "Value";
            regValue.MinimumWidth = 8;
            regValue.Name = "regValue";
            regValue.Width = 62;
            // 
            // regDataType
            // 
            regDataType.HeaderText = "Data Type";
            regDataType.MinimumWidth = 8;
            regDataType.Name = "regDataType";
            regDataType.Width = 89;
            // 
            // regFormat
            // 
            regFormat.HeaderText = "Format";
            regFormat.MinimumWidth = 8;
            regFormat.Name = "regFormat";
            regFormat.Width = 70;
            // 
            // regScale
            // 
            regScale.HeaderText = "Scale";
            regScale.MinimumWidth = 8;
            regScale.Name = "regScale";
            regScale.Width = 60;
            // 
            // regTag
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            regTag.DefaultCellStyle = dataGridViewCellStyle2;
            regTag.HeaderText = "Tag";
            regTag.MinimumWidth = 8;
            regTag.Name = "regTag";
            regTag.Width = 53;
            // 
            // regDesc
            // 
            regDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            regDesc.DefaultCellStyle = dataGridViewCellStyle3;
            regDesc.HeaderText = "Description";
            regDesc.MinimumWidth = 8;
            regDesc.Name = "regDesc";
            // 
            // pageBits
            // 
            pageBits.Controls.Add(dgvBits);
            pageBits.Location = new System.Drawing.Point(4, 23);
            pageBits.Name = "pageBits";
            pageBits.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            pageBits.Size = new System.Drawing.Size(782, 376);
            pageBits.TabIndex = 4;
            pageBits.Tag = "8";
            pageBits.Text = "Coils";
            pageBits.UseVisualStyleBackColor = true;
            // 
            // dgvBits
            // 
            dgvBits.AllowUserToAddRows = false;
            dgvBits.AllowUserToDeleteRows = false;
            dgvBits.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvBits.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dgvBits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvBits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { bitAddress, bitValue, bitTag, bitDesc });
            dgvBits.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvBits.Location = new System.Drawing.Point(0, 5);
            dgvBits.Name = "dgvBits";
            dgvBits.RowHeadersVisible = false;
            dgvBits.RowHeadersWidth = 62;
            dgvBits.RowTemplate.Height = 23;
            dgvBits.ShowEditingIcon = false;
            dgvBits.Size = new System.Drawing.Size(782, 371);
            dgvBits.TabIndex = 58;
            dgvBits.CellDoubleClick += dgvBits_CellDoubleClick;
            // 
            // bitAddress
            // 
            bitAddress.HeaderText = "Address";
            bitAddress.MinimumWidth = 8;
            bitAddress.Name = "bitAddress";
            bitAddress.ReadOnly = true;
            bitAddress.Width = 75;
            // 
            // bitValue
            // 
            bitValue.HeaderText = "Value";
            bitValue.MinimumWidth = 8;
            bitValue.Name = "bitValue";
            bitValue.ReadOnly = true;
            bitValue.Width = 62;
            // 
            // bitTag
            // 
            bitTag.HeaderText = "Tag";
            bitTag.MinimumWidth = 8;
            bitTag.Name = "bitTag";
            bitTag.Width = 53;
            // 
            // bitDesc
            // 
            bitDesc.HeaderText = "Description";
            bitDesc.MinimumWidth = 8;
            bitDesc.Name = "bitDesc";
            bitDesc.ReadOnly = true;
            bitDesc.Width = 92;
            // 
            // CmdReadTag
            // 
            CmdReadTag.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            CmdReadTag.Font = new System.Drawing.Font("Tahoma", 9F);
            CmdReadTag.Location = new System.Drawing.Point(679, 7);
            CmdReadTag.Name = "CmdReadTag";
            CmdReadTag.Size = new System.Drawing.Size(109, 28);
            CmdReadTag.TabIndex = 59;
            CmdReadTag.Tag = "";
            CmdReadTag.Text = "Read Tag";
            CmdReadTag.UseVisualStyleBackColor = true;
            CmdReadTag.Click += btnReadTag_Click;
            // 
            // FormServer
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            AutoScroll = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ClientSize = new System.Drawing.Size(810, 612);
            CloseButton = false;
            CloseButtonVisible = false;
            Controls.Add(tableLayoutMain);
            Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            HideOnClose = true;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MinimumSize = new System.Drawing.Size(700, 610);
            Name = "FormServer";
            Text = "Modbus Server";
            FormClosing += FormServer_FormClosing;
            Load += Form_Load;
            tableLayoutMain.ResumeLayout(false);
            tabUpper.ResumeLayout(false);
            grpConnection.ResumeLayout(false);
            grpConnection.PerformLayout();
            grpMap.ResumeLayout(false);
            grpMap.PerformLayout();
            grpControl.ResumeLayout(false);
            grpControl.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            tabDisplay.ResumeLayout(false);
            pageRegs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRegs).EndInit();
            pageBits.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBits).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.TableLayoutPanel tabUpper;
        private System.Windows.Forms.GroupBox grpConnection;
        private System.Windows.Forms.RadioButton rdoTcp;
        private System.Windows.Forms.RadioButton rdoRtu;
        private System.Windows.Forms.TextBox txtConnInfo;
        private System.Windows.Forms.Label lblUnitId;
        private System.Windows.Forms.TextBox txtUnitId;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.GroupBox grpMap;
        private System.Windows.Forms.Label lblMap;
        private System.Windows.Forms.ComboBox cbBindingMap;
        private System.Windows.Forms.TextBox txtMapFile;
        private System.Windows.Forms.GroupBox grpControl;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label clientCount;
        private System.Windows.Forms.Label lblClients;
        private System.Windows.Forms.TabControl tabDisplay;
        private System.Windows.Forms.TabPage pageBits;
        private System.Windows.Forms.TextBox DataQty;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox StartAddr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button CmdRead;
        private System.Windows.Forms.DataGridView dgvBits;
        private System.Windows.Forms.DataGridViewTextBoxColumn bitAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn bitValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn bitTag;
        private System.Windows.Forms.DataGridViewTextBoxColumn bitDesc;
        private System.Windows.Forms.TabPage pageRegs;
        private System.Windows.Forms.DataGridView dgvRegs;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn regAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn regValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn regDataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn regFormat;
        private System.Windows.Forms.DataGridViewTextBoxColumn regScale;
        private System.Windows.Forms.DataGridViewTextBoxColumn regTag;
        private System.Windows.Forms.DataGridViewTextBoxColumn regDesc;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button CmdReadTag;
    }
}