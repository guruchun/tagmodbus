namespace TagModbusSvr
{
    partial class ViewList
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Server");
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            treeView1 = new System.Windows.Forms.TreeView();
            panel1 = new System.Windows.Forms.Panel();
            DelServer = new System.Windows.Forms.Button();
            AddServer = new System.Windows.Forms.Button();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            textBox2 = new System.Windows.Forms.TextBox();
            panel3 = new System.Windows.Forms.Panel();
            sessionCount = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel3, 0, 4);
            tableLayoutPanel1.Controls.Add(treeView1, 0, 3);
            tableLayoutPanel1.Controls.Add(panel1, 0, 2);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            tableLayoutPanel1.Size = new System.Drawing.Size(261, 513);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // treeView1
            // 
            treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            treeView1.Location = new System.Drawing.Point(10, 88);
            treeView1.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            treeView1.Name = "treeView1";
            treeNode1.Name = "ServerList";
            treeNode1.Text = "Server";
            treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] { treeNode1 });
            treeView1.Size = new System.Drawing.Size(241, 382);
            treeView1.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(DelServer);
            panel1.Controls.Add(AddServer);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(3, 48);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(255, 34);
            panel1.TabIndex = 3;
            // 
            // DelServer
            // 
            DelServer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            DelServer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            DelServer.Location = new System.Drawing.Point(194, 3);
            DelServer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            DelServer.Name = "DelServer";
            DelServer.Size = new System.Drawing.Size(54, 29);
            DelServer.TabIndex = 2;
            DelServer.Text = "   삭제";
            DelServer.UseVisualStyleBackColor = true;
            // 
            // AddServer
            // 
            AddServer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            AddServer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            AddServer.Location = new System.Drawing.Point(132, 2);
            AddServer.Name = "AddServer";
            AddServer.Size = new System.Drawing.Size(55, 30);
            AddServer.TabIndex = 1;
            AddServer.Text = "   추가";
            AddServer.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(textBox1);
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(textBox2);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel1.Location = new System.Drawing.Point(3, 11);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(255, 31);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 3);
            label1.Margin = new System.Windows.Forms.Padding(3);
            label1.Name = "label1";
            label1.Padding = new System.Windows.Forms.Padding(3);
            label1.Size = new System.Drawing.Size(26, 21);
            label1.TabIndex = 3;
            label1.Text = "IP:";
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(35, 4);
            textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(114, 23);
            textBox1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(155, 3);
            label2.Margin = new System.Windows.Forms.Padding(3);
            label2.Name = "label2";
            label2.Padding = new System.Windows.Forms.Padding(3);
            label2.Size = new System.Drawing.Size(38, 21);
            label2.TabIndex = 3;
            label2.Text = "Port:";
            // 
            // textBox2
            // 
            textBox2.Location = new System.Drawing.Point(199, 4);
            textBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(49, 23);
            textBox2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(sessionCount);
            panel3.Controls.Add(label3);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(3, 476);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(255, 34);
            panel3.TabIndex = 14;
            // 
            // sessionCount
            // 
            sessionCount.AutoSize = true;
            sessionCount.Location = new System.Drawing.Point(113, 10);
            sessionCount.Name = "sessionCount";
            sessionCount.Size = new System.Drawing.Size(28, 15);
            sessionCount.TabIndex = 54;
            sessionCount.Text = "###";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(15, 9);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(85, 15);
            label3.TabIndex = 54;
            label3.Text = "Total Sessions:";
            // 
            // ViewList
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(261, 513);
            Controls.Add(tableLayoutPanel1);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "ViewList";
            Text = "Server/Sessions";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button AddServer;
        private System.Windows.Forms.Button DelServer;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label sessionCount;
        private System.Windows.Forms.Label label3;
    }
}