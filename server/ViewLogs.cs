using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace TagModbusSvr
{
    public partial class ViewLogs : DockContent
    {
        private string _watchingFile;
        //private FileSystemWatcher _watcher = new FileSystemWatcher();
        private long _fileOffset = 0;

        // replace fileWatcher
        private Timer _timer = new Timer();

        public ViewLogs(string fileName)
        {
            _watchingFile = fileName;

            InitializeComponent();
        }

        private void ViewLogs_Load(object sender, EventArgs e)
        {
            this.Text = _watchingFile;
            //_watcher.Path = Application.StartupPath + "\\log"; ;
            //_watcher.NotifyFilter = NotifyFilters.LastWrite;
            //_watcher.Filter = _watchingFile;
            //_watcher.Changed += new FileSystemEventHandler(watcher_Changed);
            //_watcher.EnableRaisingEvents = true;

            // load log file
            //FileSystemEventArgs args = new FileSystemEventArgs(WatcherChangeTypes.Changed, _watcher.Path, _watcher.Filter);
            //watcher_Changed(null, null);

            // use timer
            _timer.Tick += new EventHandler(this.timer_Tick);
            _timer.Interval = 1000;
            _timer.Start();
        }

        private void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            //string fullPath = (e == null) ? _watcher.Path + "\\" + _watchingFile : e.FullPath;
            //if (e.ChangeType == WatcherChangeTypes.Changed)
            string fullPath = Application.StartupPath + "\\log\\" + _watchingFile;
            try
            {
                StreamReader reader = new StreamReader(new FileStream(fullPath,
                    FileMode.Open, FileAccess.Read, FileShare.ReadWrite), Encoding.Default);

                // check invalid file offset
                if (reader.BaseStream.Length < _fileOffset)
                {
                    _fileOffset = reader.BaseStream.Length;
                }

                // check EOF
                if (_fileOffset == reader.BaseStream.Length)
                    return;

                StringBuilder sb = new StringBuilder();
                reader.BaseStream.Seek(_fileOffset, SeekOrigin.Begin);
                sb.Append(reader.ReadToEnd());
                _fileOffset = reader.BaseStream.Position;

                reader.Close();
                AppendText(sb.ToString());  // + Environment.NewLine
            }
            catch (Exception ex)
            {
                Console.WriteLine("logview update error, " + this.Text + ", " + ex.Message);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                watcher_Changed(null, null);
            }
            catch (Exception e1)
            {
                Console.WriteLine("logview timerScan_Tick, " + e1.Message);
            }
        }

        public void AppendText(string message)
        {
            try
            {
                if (txtRxTx.InvokeRequired)
                {
                    txtRxTx.Invoke(new MethodInvoker(delegate { txtRxTx.AppendText(message + Environment.NewLine); }));
                    return;
                }
                else
                {
                    if (txtRxTx.Lines.Length > 500)
                    {
                        txtRxTx.Text = "";
                    }
                    txtRxTx.AppendText(message + Environment.NewLine);
                }
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.Message);
            }
        }
    }
}