namespace TagModbusSvr
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            vS2015BlueTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2015BlueTheme();
            vS2015LightTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2015LightTheme();
            vS2015DarkTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2015DarkTheme();
            SuspendLayout();
            // 
            // dockPanel
            // 
            dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            dockPanel.DockBackColor = System.Drawing.Color.FromArgb(41, 57, 85);
            dockPanel.Location = new System.Drawing.Point(0, 0);
            dockPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            dockPanel.Name = "dockPanel";
            dockPanel.Padding = new System.Windows.Forms.Padding(6);
            dockPanel.ShowAutoHideContentOnHover = false;
            dockPanel.ShowDocumentIcon = true;
            dockPanel.Size = new System.Drawing.Size(584, 761);
            dockPanel.TabIndex = 3;
            dockPanel.Theme = vS2015BlueTheme1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(584, 761);
            Controls.Add(dockPanel);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "TagModbus Server";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            HelpRequested += MainForm_HelpRequested;
            ResumeLayout(false);
        }

        #endregion

        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private WeifenLuo.WinFormsUI.Docking.VS2015BlueTheme vS2015BlueTheme1;
        private WeifenLuo.WinFormsUI.Docking.VS2015LightTheme vS2015LightTheme1;
        private WeifenLuo.WinFormsUI.Docking.VS2015DarkTheme vS2015DarkTheme1;
    }
}

