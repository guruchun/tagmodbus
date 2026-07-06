using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace TagModbusSvr
{
    public partial class MainForm : Form
    {
        public List<ViewLogs> _viewLogs;
        private ViewList _viewList;
        private FormServer _formServer;
        private FormReplay _formReplay;
        private ViewData _viewData;

        private static readonly ILog log = LogManager.GetLogger(typeof(MainForm));

        public MainForm()
        {
            log.Debug("initialize main form");
            InitializeComponent();
            dockPanel.Theme = new WeifenLuo.WinFormsUI.Docking.VS2015BlueTheme();
            InitializeDockings();

            log.Debug("create form documents");
            createDocuments();
            log.Debug("initialize main form -> OK");
        }

        #region Methods
        public DockPanel GetDockingPanel()
        {
            return dockPanel;
        }

        public void ShowHelp(string url)
        {
            //if (m_help == null || m_help.IsDisposed) {
            //    m_help = new FormHelp();
            //    m_help.Show(dockPanel, new Rectangle(200, 200, 800, 600));
            //}
            //m_help.showHelp(url);
        }

        private void InitializeDockings()
        {
            dockPanel.DockLeftPortion = 270;
            dockPanel.DockRightPortion = 390;
            dockPanel.DockBottomPortion = 150;

            _viewList = new ViewList();
            _viewData = new ViewData();

            _viewData.Show(dockPanel, DockState.DockRight);

            // logView list
            _viewLogs = [];
            List<string> logs = AppConfig.LogView;
            for (int i = 0; i < logs.Count; i++)
            {
                _viewLogs.Add(new ViewLogs(logs[i]));
                if (i == 0)
                    _viewLogs[i].Show(dockPanel, DockState.DockBottom);
                else if (i == 1)
                    _viewLogs[i].Show(_viewLogs[0].Pane, DockAlignment.Right, 0.5);
                else if (i % 2 == 0)
                    _viewLogs[i].Show(_viewLogs[0].Pane);
                else
                    _viewLogs[i].Show(_viewLogs[1].Pane);
            }
        }

        // TODO create more LRUs
        private void createDocuments()
        {
            _formServer = new FormServer();
            _formServer.Show(dockPanel, DockState.Document);

            _formReplay = new FormReplay();
            _formReplay.Show(dockPanel, DockState.Document);
        }

        private IDockContent FindDocument(string text)
        {
            foreach (IDockContent content in dockPanel.Documents)
                if (content.DockHandler.TabText == text)
                    return content;

            return null;
        }

        #endregion

        #region Event Handlers

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(AppConfig.Window.Width, AppConfig.Window.Height);

            // create logfile directory
            string logPath = System.IO.Path.Combine(Application.StartupPath, "log");
            if (!System.IO.Directory.Exists(logPath))
                System.IO.Directory.CreateDirectory(logPath);
        }
        private void MainForm_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            //DockContent content = (DockContent)this.dockPanel.ActivePane.ActiveContent;
            //if (content != null)
            //    content.HelpRequested;

            ShowHelp("GuideOverview");
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save window size
            AppConfig.Window.Width = this.Size.Width;
            AppConfig.Window.Height = this.Size.Height;
            AppConfig.Save();

            // close all forms
            foreach (var f in _viewLogs)
                f.Close();
            _viewList.Close();
            _formServer.Close();
            _formReplay.Close();
            _viewData.Close();
        }
    }
}