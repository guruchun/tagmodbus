namespace TagModbusSvr
{
    partial class ViewLogs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewLogs));
            txtRxTx = new System.Windows.Forms.TextBox();
            workerRx = new System.ComponentModel.BackgroundWorker();
            SuspendLayout();
            // 
            // txtRxTx
            // 
            txtRxTx.Dock = System.Windows.Forms.DockStyle.Fill;
            txtRxTx.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            txtRxTx.Location = new System.Drawing.Point(0, 2);
            txtRxTx.Multiline = true;
            txtRxTx.Name = "txtRxTx";
            txtRxTx.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            txtRxTx.Size = new System.Drawing.Size(518, 179);
            txtRxTx.TabIndex = 1;
            txtRxTx.WordWrap = false;
            // 
            // workerRx
            // 
            workerRx.WorkerReportsProgress = true;
            // 
            // ViewLogs
            // 
            ClientSize = new System.Drawing.Size(518, 183);
            Controls.Add(txtRxTx);
            DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom;
            Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 129);
            HideOnClose = true;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "ViewLogs";
            Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockBottomAutoHide;
            TabText = "";
            Text = "MODBUS Messsages";
            Load += ViewLogs_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private System.Windows.Forms.TextBox txtRxTx;
        private System.ComponentModel.BackgroundWorker workerRx;
    }
}