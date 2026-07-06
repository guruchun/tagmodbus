
using System.Drawing;
using System.Windows.Forms;

namespace TagModbusSvr
{
    partial class ViewData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewData));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            toolStrip = new ToolStrip();
            lbSearch = new ToolStripLabel();
            txtSearch = new ToolStripTextBox();
            ShowAddress = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            CmdImport = new ToolStripButton();
            CmdExport = new ToolStripButton();
            dgvTags = new DataGridView();
            tableLayoutPanel = new TableLayoutPanel();
            panel1 = new Panel();
            btnArrayWrite = new Button();
            dgvDatasArray = new DataGridView();
            toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTags).BeginInit();
            tableLayoutPanel.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatasArray).BeginInit();
            SuspendLayout();
            // 
            // toolStrip
            // 
            toolStrip.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip.Items.AddRange(new ToolStripItem[] { lbSearch, txtSearch, ShowAddress, toolStripSeparator2, CmdImport, CmdExport });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.RenderMode = ToolStripRenderMode.System;
            toolStrip.Size = new Size(344, 25);
            toolStrip.TabIndex = 0;
            toolStrip.Text = "toolStrip1";
            // 
            // lbSearch
            // 
            lbSearch.Name = "lbSearch";
            lbSearch.Size = new Size(50, 22);
            lbSearch.Text = "Search :";
            // 
            // txtSearch
            // 
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(100, 25);
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // ShowAddress
            // 
            ShowAddress.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ShowAddress.Image = (Image)resources.GetObject("ShowAddress.Image");
            ShowAddress.ImageTransparentColor = Color.Magenta;
            ShowAddress.Name = "ShowAddress";
            ShowAddress.Size = new Size(23, 22);
            ShowAddress.Text = "Show/Hide Modbus Address";
            ShowAddress.Click += ShowAddress_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // CmdImport
            // 
            CmdImport.Image = (Image)resources.GetObject("CmdImport.Image");
            CmdImport.ImageTransparentColor = Color.Magenta;
            CmdImport.Name = "CmdImport";
            CmdImport.Size = new Size(63, 22);
            CmdImport.Text = "Import";
            CmdImport.ToolTipText = "Import Tag Values";
            CmdImport.Click += btnImport_Click;
            // 
            // CmdExport
            // 
            CmdExport.Image = (Image)resources.GetObject("CmdExport.Image");
            CmdExport.ImageTransparentColor = Color.Magenta;
            CmdExport.Name = "CmdExport";
            CmdExport.Size = new Size(61, 22);
            CmdExport.Text = "Export";
            CmdExport.ToolTipText = "Export Tag Values";
            CmdExport.Click += btnExport_Click;
            // 
            // dgvTags
            // 
            dgvTags.AllowUserToAddRows = false;
            dgvTags.AllowUserToDeleteRows = false;
            dgvTags.AllowUserToResizeRows = false;
            dgvTags.BackgroundColor = SystemColors.Control;
            dgvTags.BorderStyle = BorderStyle.Fixed3D;
            dgvTags.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Tahoma", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvTags.DefaultCellStyle = dataGridViewCellStyle1;
            dgvTags.Dock = DockStyle.Fill;
            dgvTags.Location = new Point(3, 3);
            dgvTags.Name = "dgvTags";
            dgvTags.RowHeadersVisible = false;
            dgvTags.Size = new Size(338, 459);
            dgvTags.TabIndex = 1;
            dgvTags.CellBeginEdit += dgvDatas_CellBeginEdit;
            dgvTags.CellEnter += dgvDatas_CellEnter;
            dgvTags.DataBindingComplete += dgvDatas_DataBindingComplete;
            dgvTags.DataError += dgvDatas_DataError;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(dgvTags, 0, 0);
            tableLayoutPanel.Controls.Add(panel1, 0, 1);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 25);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel.Size = new Size(344, 515);
            tableLayoutPanel.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnArrayWrite);
            panel1.Controls.Add(dgvDatasArray);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 468);
            panel1.Name = "panel1";
            panel1.Size = new Size(338, 44);
            panel1.TabIndex = 2;
            // 
            // btnArrayWrite
            // 
            btnArrayWrite.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnArrayWrite.Location = new Point(274, -1);
            btnArrayWrite.Name = "btnArrayWrite";
            btnArrayWrite.Size = new Size(64, 45);
            btnArrayWrite.TabIndex = 5;
            btnArrayWrite.Text = "Apply";
            btnArrayWrite.UseVisualStyleBackColor = true;
            btnArrayWrite.Click += btnArrayWrite_Click;
            // 
            // dgvDatasArray
            // 
            dgvDatasArray.AllowUserToAddRows = false;
            dgvDatasArray.AllowUserToDeleteRows = false;
            dgvDatasArray.AllowUserToResizeColumns = false;
            dgvDatasArray.AllowUserToResizeRows = false;
            dgvDatasArray.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvDatasArray.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDatasArray.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvDatasArray.BackgroundColor = SystemColors.Control;
            dgvDatasArray.BorderStyle = BorderStyle.Fixed3D;
            dgvDatasArray.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDatasArray.ColumnHeadersVisible = false;
            dgvDatasArray.Location = new Point(0, 0);
            dgvDatasArray.Name = "dgvDatasArray";
            dgvDatasArray.RowHeadersVisible = false;
            dgvDatasArray.ScrollBars = ScrollBars.Vertical;
            dgvDatasArray.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvDatasArray.ShowCellToolTips = false;
            dgvDatasArray.Size = new Size(273, 43);
            dgvDatasArray.TabIndex = 4;
            // 
            // ViewData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 540);
            CloseButton = false;
            CloseButtonVisible = false;
            Controls.Add(tableLayoutPanel);
            Controls.Add(toolStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ViewData";
            Text = "TAG List";
            Load += ViewData_Load;
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTags).EndInit();
            tableLayoutPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatasArray).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip;
        private ToolStripLabel lbSearch;
        private DataGridView dgvTags;
        private ToolStripTextBox txtSearch;
        private TableLayoutPanel tableLayoutPanel;
        private Panel panel1;
        private DataGridView dgvDatasArray;
        private Button btnArrayWrite;
        private ToolStripButton CmdImport;
        private ToolStripButton CmdExport;
        private ToolStripButton ShowAddress;
        private ToolStripSeparator toolStripSeparator2;
    }
}