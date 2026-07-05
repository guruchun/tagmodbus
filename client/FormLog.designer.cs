namespace TagModbus
{
    partial class FormLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLog));
            this.txtRxTx = new System.Windows.Forms.TextBox();
            this.workerRx = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // txtRxTx
            // 
            this.txtRxTx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRxTx.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtRxTx.Location = new System.Drawing.Point(0, 2);
            this.txtRxTx.Multiline = true;
            this.txtRxTx.Name = "txtRxTx";
            this.txtRxTx.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRxTx.Size = new System.Drawing.Size(255, 116);
            this.txtRxTx.TabIndex = 1;
            this.txtRxTx.WordWrap = false;
            this.txtRxTx.Enter += new System.EventHandler(this.txtRxTx_Enter);
            this.txtRxTx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRxTx_KeyDown);
            this.txtRxTx.Leave += new System.EventHandler(this.txtRxTx_Leave);
            // 
            // workerRx
            // 
            this.workerRx.WorkerReportsProgress = true;
            // 
            // FormLog
            // 
            this.ClientSize = new System.Drawing.Size(255, 120);
            this.Controls.Add(this.txtRxTx);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLog";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockBottomAutoHide;
            this.TabText = "";
            this.Text = "log file";
            this.Load += new System.EventHandler(this.FormLog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.TextBox txtRxTx;
        private System.ComponentModel.BackgroundWorker workerRx;
    }
}
