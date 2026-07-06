using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using TagModbusLib;

namespace TagModbusSvr
{
    public partial class FormTester : DockContent
    {
        private ModbusServerWrapper _modbusServer;
        private bool _preventRefresh = false;

        public FormTester()
        {
            InitializeComponent();

            // modbus server
            _modbusServer = ModbusServerWrapper.getInstance();
        }

        private void Form_Load(object sender, EventArgs e)
        {
        }

        private void btnRawPreview_Click(object sender, EventArgs e)
        {

        }

        private void chkTxnId_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTxnId.Checked)
                txtSeq.BackColor = Color.White;
            else
                txtSeq.BackColor = SystemColors.InactiveCaption;
        }
    }
}
