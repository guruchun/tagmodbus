using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Net.Sockets;
using System.Net;
using System.Runtime.InteropServices;
using System.IO;

namespace TagModbus
{
    public partial class FormLog : DockContent
    {
        //private bool _autoScroll = true;
        //private Point _autoScrollOffset = new Point();
        private string _watchingFile;
        private FileSystemWatcher _watcher = new FileSystemWatcher();
        private long _fileOffset = 0;

        // replace fileWatcher
        private Timer _timer = new Timer();

        public FormLog(string fileName)
        {
            _watchingFile = fileName;

            InitializeComponent();
        }

        private void FormLog_Load(object sender, EventArgs e)
        {
            this.Text = _watchingFile;
            _watcher.Path = Application.StartupPath + "\\log"; ;
            _watcher.NotifyFilter = NotifyFilters.LastWrite;
            _watcher.Filter = _watchingFile;
            _watcher.Changed += new FileSystemEventHandler(watcher_Changed);
            _watcher.EnableRaisingEvents = true;

            // load log file
            //FileSystemEventArgs args = new FileSystemEventArgs(WatcherChangeTypes.Changed, _watcher.Path, _watcher.Filter);
            //watcher_Changed(null, null);

            // use timer
            _timer.Tick += new EventHandler(this.timer_Tick);
            _timer.Interval = 1000;
            _timer.Enabled = true;
            _timer.Start();

            txtRxTx.SelectionStart = txtRxTx.TextLength;
        }

        private void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            string fullPath = (e == null) ? _watcher.Path + "\\" + _watchingFile : e.FullPath;
            //if (e.ChangeType == WatcherChangeTypes.Changed)
            try
            {
                StreamReader reader = new StreamReader(new FileStream(fullPath,
                    FileMode.Open, FileAccess.Read, FileShare.ReadWrite), Encoding.Default);
                if (reader.BaseStream.Length < _fileOffset)
                {
                    _fileOffset = reader.BaseStream.Length;
                }

                if (_fileOffset == reader.BaseStream.Length)
                    return;

                StringBuilder sb = new StringBuilder();
                reader.BaseStream.Seek(_fileOffset, SeekOrigin.Begin);
                //while ((s = reader.ReadLine()) != null)
                //{
                //    sb.Append(s);
                //}
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

        private void txtRxTx_Enter(object sender, EventArgs e)
        {
            //_autoScroll = false;
        }

        private void txtRxTx_Leave(object sender, EventArgs e)
        {
            //_autoScroll = true;
        }

        delegate void updateLogView(string message);
        public void AppendText(string message)
        {
            if (this.txtRxTx.InvokeRequired)
            {
                updateLogView d = new updateLogView(AppendText);
                this.Invoke(d, message);
                return;
            }
            try
            {
                if (txtRxTx.Lines.Length > 10000)
                {
                    txtRxTx.Text.Remove(0, 100000);
                }

                LockWindow(txtRxTx.Handle);

                // last line: ctrl + end --> auto scroll
                int selPos = txtRxTx.SelectionStart;
                bool autoScroll = txtRxTx.TextLength == selPos ? true : false;

                // save current postion and selection
                int selLen = txtRxTx.SelectionLength;
                int savedVpos = GetScrollPos(txtRxTx.Handle, SB_VERT);

                // append
                txtRxTx.AppendText(message);

                if (autoScroll)
                {
                    txtRxTx.SelectionStart = txtRxTx.TextLength;
                }
                else
                {
                    txtRxTx.SelectionStart = selPos;
                    txtRxTx.SelectionLength = selLen;
                    SetScrollPos(txtRxTx.Handle, SB_VERT, savedVpos, true);
                    PostMessageA(txtRxTx.Handle, WM_VSCROLL, SB_THUMBPOSITION + 0x10000 * savedVpos, 0);
                }

                LockWindow(IntPtr.Zero);
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.Message);
            }
        }

        [DllImport("user32.dll", EntryPoint = "LockWindowUpdate", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr LockWindow(IntPtr Handle);

        private const int SB_VERT = 0x1;
        private const int WM_VSCROLL = 0x115;
        private const int SB_THUMBPOSITION = 0x4;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetScrollPos(IntPtr hWnd, int nBar);
        [DllImport("user32.dll")]
        private static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);
        [DllImport("user32.dll")]
        private static extern bool PostMessageA(IntPtr hWnd, int nBar, int wParam, int lParam);


        private void txtRxTx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.A))
            {
                if (sender != null)
                    ((RichTextBox)sender).SelectAll();
                e.Handled = true;
            }
        }

        private void FormLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            _timer.Enabled = false;
        }
    }
}
