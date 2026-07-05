using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using log4net;
using System.Reflection;
using System.Collections.Generic;

namespace TagModbus
{
    public partial class MainForm : Form
    {
        //private bool m_bSaveLayout = true;
        private FormHelp m_help;
        private FormClient m_client;
        private FormTags m_tags;

        private List<FormLog> m_viewLogs;
        private static readonly ILog log = LogManager.GetLogger(typeof(MainForm));
        //private DeserializeDockContent deserializeDockContent;

        public MainForm()
        {
            log.Debug("initialize main form");
            InitializeComponent();
            dockPanel.Theme = new WeifenLuo.WinFormsUI.Docking.VS2015BlueTheme();
            m_viewLogs = new List<FormLog>();

            log.Debug("create form documents");
            InitializeDockings();
            //deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
            log.Debug("initialize main form -> OK");
        }

        #region Methods
        public DockPanel GetDockingPanel()
        {
            return dockPanel;
        }

        public void ShowHelp(string url)
        {
            if (m_help == null || m_help.IsDisposed) {
                m_help = new FormHelp();
                m_help.Show(dockPanel, new Rectangle(200, 200, 800, 600));
            }
            m_help.showHelp(url);
        }

        private void InitializeDockings()
        {
            m_client = new FormClient();
            m_tags = new FormTags(
                () => m_client.ModbusMaster,
                () => m_client.UnitId);

            List<string> logs = AppConfig.LogView;
            if (logs != null)
            {
                for (int i = 0; i < logs.Count; i++)
                    m_viewLogs.Add(new FormLog(logs[i]));
            }
        }

        // TODO create more LRUs
        private void createDocuments()
        {
            DockContent leftDoc;
            leftDoc = CreateNewDocument("CLI");
            leftDoc.Show(dockPanel, DockState.Document);

            // Tags view (docked right)
            m_tags.Show(dockPanel, DockState.DockRight);

            // log view (minimized by default)
            foreach (var f in m_viewLogs)
            {
                f.Show(dockPanel, DockState.DockBottomAutoHide);
            }

            // tool
            // if (m_viewLogs.Count > 0)
            //     m_tool.Show(m_viewLogs[0].Pane, DockAlignment.Right, 0.3);
            // else
            //     m_tool.Show(dockPanel, DockState.DockBottom);
        }

        private DockContent CreateNewDocument(String docName)
        {
            DockContent tempDoc;
            tempDoc = (DockContent)FindDocument(docName);
            if (tempDoc != null)
            {
                // already existed
                // TODO activated
                return (DockContent)tempDoc;
            }

            // create new doucment
            switch (docName)
            {
                case "CLI":
                    tempDoc = new FormClient();
                    break;
            }
            //if (tempDoc != null)
            //    tempDoc.Text = docName;

            return tempDoc;
        }

        private IDockContent FindDocument(string text)
        {
            foreach (IDockContent content in dockPanel.Documents)
                if (content.DockHandler.TabText == text)
                    return content;

            return null;
        }

        private IDockContent GetContentFromPersistString(string persistString)
        {
            log.Debug("GetContentFromPersistString, " + persistString);

            if (persistString == typeof(FormHelp).ToString())
                return m_help;
            else if (persistString == typeof(FormClient).ToString())
                return m_client;
            else
                return null;
        }
        
        #endregion

        #region Event Handlers

        private void MainForm_Load(object sender, EventArgs e)
        {
            log.Debug("loading " + this.Name);
            this.Text += " - Version " + Assembly.GetEntryAssembly().GetName().Version.Major;
            this.Text += "." + Assembly.GetEntryAssembly().GetName().Version.Minor;
            this.Text += "." + Assembly.GetEntryAssembly().GetName().Version.Build;

            // load window size from config
            this.Size = new Size(AppConfig.Window.Width, AppConfig.Window.Height);

            //string configFile = Path.Combine(Application.StartupPath, "config\\client.layout");
            //if (File.Exists(configFile))
            //    dockPanel.LoadFromXml(configFile, deserializeDockContent);
            //else
            createDocuments();

            // create logfile directory
            string logPath = Application.StartupPath + "\\log";
            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);
        }

        private void MainForm_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            //DockContent content = (DockContent)this.dockPanel.ActivePane.ActiveContent;
            //if (content != null)
            //    content.HelpRequested;

            ShowHelp("GuideOverview");
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppConfig.Window.Width = this.Size.Width;
            AppConfig.Window.Height = this.Size.Height;
            AppConfig.Save();

            //string configFile = Path.Combine(Application.StartupPath, "config\\client.layout");
            //dockPanel.SaveAsXml(configFile);
        }

        #endregion

    }
}
