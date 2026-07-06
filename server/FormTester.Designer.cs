
namespace TagModbusSvr
{
    partial class FormTester
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTester));
            panel1 = new System.Windows.Forms.Panel();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            panelUpper = new System.Windows.Forms.Panel();
            groupBox3 = new System.Windows.Forms.GroupBox();
            checkBox1 = new System.Windows.Forms.CheckBox();
            chkTxnId = new System.Windows.Forms.CheckBox();
            txtLength = new System.Windows.Forms.TextBox();
            txtProtocol = new System.Windows.Forms.TextBox();
            txtSlave = new System.Windows.Forms.TextBox();
            txtSeq = new System.Windows.Forms.TextBox();
            textBox2 = new System.Windows.Forms.TextBox();
            txtRawPreview = new System.Windows.Forms.TextBox();
            textBox1 = new System.Windows.Forms.TextBox();
            txtStartAddress = new System.Windows.Forms.TextBox();
            cbFunction = new System.Windows.Forms.ComboBox();
            label11 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            btnRawPreview = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            panel2 = new System.Windows.Forms.Panel();
            textBox3 = new System.Windows.Forms.TextBox();
            richTextBox1 = new System.Windows.Forms.RichTextBox();
            label5 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            listBox1 = new System.Windows.Forms.ListBox();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panelUpper.SuspendLayout();
            groupBox3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(751, 655);
            panel1.TabIndex = 8;
            // 
            // tableLayoutMain
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(panelUpper);
            flowLayoutPanel1.Controls.Add(panel2);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel1.Name = "tableLayoutMain";
            flowLayoutPanel1.Size = new System.Drawing.Size(751, 655);
            flowLayoutPanel1.TabIndex = 11;
            // 
            // panelUpper
            // 
            panelUpper.Controls.Add(groupBox3);
            panelUpper.Location = new System.Drawing.Point(3, 3);
            panelUpper.Name = "panelUpper";
            panelUpper.Size = new System.Drawing.Size(739, 191);
            panelUpper.TabIndex = 11;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(checkBox1);
            groupBox3.Controls.Add(chkTxnId);
            groupBox3.Controls.Add(txtLength);
            groupBox3.Controls.Add(txtProtocol);
            groupBox3.Controls.Add(txtSlave);
            groupBox3.Controls.Add(txtSeq);
            groupBox3.Controls.Add(textBox2);
            groupBox3.Controls.Add(txtRawPreview);
            groupBox3.Controls.Add(textBox1);
            groupBox3.Controls.Add(txtStartAddress);
            groupBox3.Controls.Add(cbFunction);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(btnRawPreview);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(label21);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(label18);
            groupBox3.Location = new System.Drawing.Point(17, 9);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(721, 165);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "Generate Response Message";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new System.Drawing.Point(596, 42);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(117, 16);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "Function is fixed";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += chkTxnId_CheckedChanged;
            // 
            // chkTxnId
            // 
            chkTxnId.AutoSize = true;
            chkTxnId.Location = new System.Drawing.Point(596, 20);
            chkTxnId.Name = "chkTxnId";
            chkTxnId.Size = new System.Drawing.Size(97, 16);
            chkTxnId.TabIndex = 5;
            chkTxnId.Text = "Txn# is fixed";
            chkTxnId.UseVisualStyleBackColor = true;
            chkTxnId.CheckedChanged += chkTxnId_CheckedChanged;
            // 
            // txtLength
            // 
            txtLength.BackColor = System.Drawing.SystemColors.InactiveCaption;
            txtLength.Location = new System.Drawing.Point(129, 60);
            txtLength.Name = "txtLength";
            txtLength.Size = new System.Drawing.Size(43, 21);
            txtLength.TabIndex = 4;
            txtLength.Text = "0";
            txtLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtProtocol
            // 
            txtProtocol.BackColor = System.Drawing.SystemColors.InactiveCaption;
            txtProtocol.Location = new System.Drawing.Point(68, 60);
            txtProtocol.Name = "txtProtocol";
            txtProtocol.Size = new System.Drawing.Size(43, 21);
            txtProtocol.TabIndex = 4;
            txtProtocol.Text = "0";
            txtProtocol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSlave
            // 
            txtSlave.BackColor = System.Drawing.SystemColors.InactiveCaption;
            txtSlave.Location = new System.Drawing.Point(187, 60);
            txtSlave.Name = "txtSlave";
            txtSlave.Size = new System.Drawing.Size(82, 21);
            txtSlave.TabIndex = 4;
            txtSlave.Text = "0";
            txtSlave.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSeq
            // 
            txtSeq.BackColor = System.Drawing.SystemColors.InactiveCaption;
            txtSeq.Location = new System.Drawing.Point(21, 60);
            txtSeq.Name = "txtSeq";
            txtSeq.Size = new System.Drawing.Size(37, 21);
            txtSeq.TabIndex = 4;
            txtSeq.Text = "0";
            txtSeq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox2
            // 
            textBox2.BackColor = System.Drawing.Color.LemonChiffon;
            textBox2.Location = new System.Drawing.Point(20, 125);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new System.Drawing.Size(685, 21);
            textBox2.TabIndex = 4;
            // 
            // txtRawPreview
            // 
            txtRawPreview.Location = new System.Drawing.Point(20, 93);
            txtRawPreview.Name = "txtRawPreview";
            txtRawPreview.ReadOnly = true;
            txtRawPreview.Size = new System.Drawing.Size(560, 21);
            txtRawPreview.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(406, 60);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(65, 21);
            textBox1.TabIndex = 4;
            // 
            // txtStartAddress
            // 
            txtStartAddress.Location = new System.Drawing.Point(484, 60);
            txtStartAddress.Name = "txtStartAddress";
            txtStartAddress.Size = new System.Drawing.Size(221, 21);
            txtStartAddress.TabIndex = 4;
            // 
            // cbFunction
            // 
            cbFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbFunction.FormattingEnabled = true;
            cbFunction.Items.AddRange(new object[] { "1", "2" });
            cbFunction.Location = new System.Drawing.Point(283, 60);
            cbFunction.Name = "cbFunction";
            cbFunction.Size = new System.Drawing.Size(111, 20);
            cbFunction.TabIndex = 2;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(516, 39);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(30, 12);
            label11.TabIndex = 0;
            label11.Text = "Data";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(389, 39);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(100, 12);
            label14.TabIndex = 0;
            label14.Text = "Count/Exception";
            // 
            // btnRawPreview
            // 
            btnRawPreview.Location = new System.Drawing.Point(596, 88);
            btnRawPreview.Name = "btnRawPreview";
            btnRawPreview.Size = new System.Drawing.Size(109, 28);
            btnRawPreview.TabIndex = 3;
            btnRawPreview.Text = "Preview";
            btnRawPreview.UseVisualStyleBackColor = true;
            btnRawPreview.Click += btnRawPreview_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(281, 39);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(86, 12);
            label1.TabIndex = 0;
            label1.Text = "Function/Error";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new System.Drawing.Point(187, 39);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(82, 12);
            label21.TabIndex = 0;
            label21.Text = "Unit ID(Slave)";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = System.Drawing.Color.RoyalBlue;
            label10.Location = new System.Drawing.Point(280, 21);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(300, 12);
            label10.TabIndex = 0;
            label10.Text = "| <------------ MODBUS Response -----------> |";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = System.Drawing.Color.Red;
            label9.Location = new System.Drawing.Point(20, 21);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(254, 12);
            label9.TabIndex = 0;
            label9.Text = "| <------------ MBAP Header ---------> |";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(20, 39);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(27, 12);
            label4.TabIndex = 0;
            label4.Text = "Txn";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(66, 39);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(51, 12);
            label2.TabIndex = 0;
            label2.Text = "Protocol";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new System.Drawing.Point(129, 39);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(43, 12);
            label18.TabIndex = 0;
            label18.Text = "Length";
            // 
            // panel2
            // 
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(richTextBox1);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(listBox1);
            panel2.Location = new System.Drawing.Point(3, 200);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(739, 433);
            panel2.TabIndex = 12;
            // 
            // textBox3
            // 
            textBox3.Location = new System.Drawing.Point(17, 261);
            textBox3.Name = "textBox3";
            textBox3.Size = new System.Drawing.Size(705, 21);
            textBox3.TabIndex = 3;
            // 
            // richTextBox1
            // 
            richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            richTextBox1.Location = new System.Drawing.Point(17, 288);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new System.Drawing.Size(705, 128);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(15, 245);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(115, 12);
            label5.TabIndex = 1;
            label5.Text = "Message Decoding";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(17, 27);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(105, 12);
            label3.TabIndex = 1;
            label3.Text = "Rx/Tx Messages";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 12;
            listBox1.Location = new System.Drawing.Point(17, 48);
            listBox1.Name = "listBox1";
            listBox1.Size = new System.Drawing.Size(705, 184);
            listBox1.TabIndex = 0;
            // 
            // FormTester
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            AutoScroll = true;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ClientSize = new System.Drawing.Size(751, 655);
            CloseButton = false;
            CloseButtonVisible = false;
            Controls.Add(panel1);
            Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            HideOnClose = true;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "FormTester";
            Text = "Modbus Monitor";
            Load += Form_Load;
            panel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            panelUpper.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelUpper;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.TextBox txtProtocol;
        private System.Windows.Forms.TextBox txtSlave;
        private System.Windows.Forms.TextBox txtSeq;
        private System.Windows.Forms.TextBox txtRawPreview;
        private System.Windows.Forms.TextBox txtStartAddress;
        private System.Windows.Forms.ComboBox cbFunction;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnRawPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkTxnId;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox1;
    }
}