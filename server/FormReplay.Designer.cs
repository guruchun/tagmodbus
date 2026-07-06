namespace TagModbusSvr
{
    partial class FormReplay
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelTop = new System.Windows.Forms.Panel();
            lblFile = new System.Windows.Forms.Label();
            cbCsvFile = new System.Windows.Forms.ComboBox();
            btnLoad = new System.Windows.Forms.Button();
            btnPlay = new System.Windows.Forms.Button();
            lblRows = new System.Windows.Forms.Label();
            txtRows = new System.Windows.Forms.TextBox();
            lblSkip = new System.Windows.Forms.Label();
            txtSkipRows = new System.Windows.Forms.TextBox();
            lblInterval = new System.Windows.Forms.Label();
            txtInterval = new System.Windows.Forms.TextBox();
            lblMs = new System.Windows.Forms.Label();
            dgvReplay = new System.Windows.Forms.DataGridView();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReplay).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(lblFile);
            panelTop.Controls.Add(cbCsvFile);
            panelTop.Controls.Add(btnLoad);
            panelTop.Controls.Add(btnPlay);
            panelTop.Controls.Add(lblRows);
            panelTop.Controls.Add(txtRows);
            panelTop.Controls.Add(lblSkip);
            panelTop.Controls.Add(txtSkipRows);
            panelTop.Controls.Add(lblInterval);
            panelTop.Controls.Add(txtInterval);
            panelTop.Controls.Add(lblMs);
            panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            panelTop.Location = new System.Drawing.Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new System.Drawing.Size(784, 36);
            panelTop.TabIndex = 0;
            // 
            // lblFile
            // 
            lblFile.AutoSize = true;
            lblFile.Location = new System.Drawing.Point(8, 10);
            lblFile.Name = "lblFile";
            lblFile.Size = new System.Drawing.Size(28, 15);
            lblFile.Text = "File:";
            // 
            // cbCsvFile
            // 
            cbCsvFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbCsvFile.Location = new System.Drawing.Point(40, 7);
            cbCsvFile.Name = "cbCsvFile";
            cbCsvFile.Size = new System.Drawing.Size(150, 23);
            cbCsvFile.TabIndex = 0;
            // 
            // btnLoad
            // 
            btnLoad.Location = new System.Drawing.Point(196, 6);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new System.Drawing.Size(55, 25);
            btnLoad.TabIndex = 1;
            btnLoad.Text = "Load";
            btnLoad.Click += btnLoad_Click;
            // 
            // btnPlay
            // 
            btnPlay.Location = new System.Drawing.Point(258, 6);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new System.Drawing.Size(55, 25);
            btnPlay.TabIndex = 2;
            btnPlay.Text = "Play";
            btnPlay.Click += btnPlay_Click;
            // 
            // lblRows
            // 
            lblRows.AutoSize = true;
            lblRows.Location = new System.Drawing.Point(324, 10);
            lblRows.Name = "lblRows";
            lblRows.Size = new System.Drawing.Size(38, 15);
            lblRows.Text = "Rows:";
            // 
            // txtRows
            // 
            txtRows.Location = new System.Drawing.Point(364, 7);
            txtRows.Name = "txtRows";
            txtRows.ReadOnly = true;
            txtRows.Size = new System.Drawing.Size(45, 23);
            txtRows.TabIndex = 3;
            txtRows.Text = "0";
            txtRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSkip
            // 
            lblSkip.AutoSize = true;
            lblSkip.Location = new System.Drawing.Point(420, 10);
            lblSkip.Name = "lblSkip";
            lblSkip.Size = new System.Drawing.Size(32, 15);
            lblSkip.Text = "Skip:";
            // 
            // txtSkipRows
            // 
            txtSkipRows.Location = new System.Drawing.Point(454, 7);
            txtSkipRows.Name = "txtSkipRows";
            txtSkipRows.Size = new System.Drawing.Size(30, 23);
            txtSkipRows.TabIndex = 4;
            txtSkipRows.Text = "1";
            txtSkipRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            txtSkipRows.TextChanged += txtSkipRows_TextChanged;
            // 
            // lblInterval
            // 
            lblInterval.AutoSize = true;
            lblInterval.Location = new System.Drawing.Point(496, 10);
            lblInterval.Name = "lblInterval";
            lblInterval.Size = new System.Drawing.Size(49, 15);
            lblInterval.Text = "Interval:";
            // 
            // txtInterval
            // 
            txtInterval.Location = new System.Drawing.Point(548, 7);
            txtInterval.Name = "txtInterval";
            txtInterval.Size = new System.Drawing.Size(45, 23);
            txtInterval.TabIndex = 5;
            txtInterval.Text = "1000";
            txtInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            txtInterval.TextChanged += txtInterval_TextChanged;
            // 
            // lblMs
            // 
            lblMs.AutoSize = true;
            lblMs.Location = new System.Drawing.Point(596, 10);
            lblMs.Name = "lblMs";
            lblMs.Size = new System.Drawing.Size(23, 15);
            lblMs.Text = "ms";
            // 
            // dgvReplay
            // 
            dgvReplay.AllowUserToAddRows = false;
            dgvReplay.AllowUserToDeleteRows = false;
            dgvReplay.BackgroundColor = System.Drawing.SystemColors.Window;
            dgvReplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvReplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReplay.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvReplay.Location = new System.Drawing.Point(0, 36);
            dgvReplay.Name = "dgvReplay";
            dgvReplay.ReadOnly = true;
            dgvReplay.RowHeadersVisible = false;
            dgvReplay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvReplay.Size = new System.Drawing.Size(784, 325);
            dgvReplay.TabIndex = 1;
            dgvReplay.SelectionChanged += dgvReplay_SelectionChanged;
            // 
            // FormReplay
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(784, 361);
            Controls.Add(dgvReplay);
            Controls.Add(panelTop);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            Name = "FormReplay";
            Text = "Replay";
            Load += FormReplay_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReplay).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.ComboBox cbCsvFile;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.TextBox txtRows;
        private System.Windows.Forms.Label lblSkip;
        private System.Windows.Forms.TextBox txtSkipRows;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Label lblMs;
        private System.Windows.Forms.DataGridView dgvReplay;
    }
}
