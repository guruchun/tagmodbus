using System;
using WeifenLuo.WinFormsUI.Docking;
using TagModbusLib;

namespace TagModbus
{
    public partial class FormTool : DockContent
    {
        public FormTool()
        {
            InitializeComponent();
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            char[] delimiterChars = { ' ', ',', ':'};
            string mesg = txtInput.Text.Trim();
            string[] hexMesgs = mesg.Split(delimiterChars);

            byte[] rawBytes = new byte[hexMesgs.Length];
            for (int i=0; i<hexMesgs.Length; i++)
            {
                rawBytes[i] = Convert.ToByte(hexMesgs[i], 16);
            }

            if (rawBytes.Length < 9)
            {
                txtResult.Text = "invlaid message Format";
                return;
            }

            // transaction id
            string result;
            result = "[" + rawBytes[0].ToString("X2") + " " + rawBytes[1].ToString("X2") + "]";
            result += " --> Txn ID: " + (rawBytes[0] << 8 | rawBytes[1]).ToString() + Environment.NewLine;

            // protocol id
            result += "[" + rawBytes[2].ToString("X2") + " " + rawBytes[3].ToString("X2") + "]";
            int protocolId = rawBytes[2] << 8 | rawBytes[3];
            result += " --> Protocol ID: " + protocolId.ToString() + " --> ";
            result += protocolId == 0 ? "Modbus/TCP" : "Unknown";
            result += Environment.NewLine;

            // length
            result += "[" + rawBytes[4].ToString("X2") + " " + rawBytes[5].ToString("X2") + "]";
            int length = rawBytes[4] << 8 | rawBytes[5];
            result += " --> Length(Unit ID ~Data): " + length.ToString() + Environment.NewLine;
            // Unit id
            result += "[" + rawBytes[6].ToString("X2") + "]";
            result += " --> Unit(Slave) ID: " + rawBytes[6].ToString() + Environment.NewLine;

            // function code
            result += "[" + rawBytes[7].ToString("X2") + "]";
            int funcCode = rawBytes[7];
            if (ModbusType.FuncDesc.ContainsKey(funcCode))
            {
                result += " --> Function: ";
                result += ModbusType.FuncDesc[funcCode] + Environment.NewLine;
            }
            else
            {
                if (funcCode >= 0x80)
                {
                    result += " --> Error: " + ModbusType.FuncDesc[funcCode - 0x80] + Environment.NewLine;
                    result += "   Exception: " + ModbusType.ExCodeDesc[rawBytes[8]] + Environment.NewLine;
                }
                else
                {
                    result += " --> Function: Unkonwn Code" + Environment.NewLine;
                }

                txtResult.Text = result;
                return;
            }

            // data parsing by function code
            if ((Function)funcCode == Function.READ_COIL || (Function)funcCode == Function.READ_DISC)
            {
                // read
                if (length == 6)
                {
                    result += " ==== request ==== " + Environment.NewLine;
                    result += "[" + rawBytes[8].ToString("X2") + " " + rawBytes[9].ToString("X2") + "]";
                    int addr = rawBytes[8] << 8 | rawBytes[9];
                    result += " --> Start Address: " + addr.ToString() + Environment.NewLine;

                    result += "[" + rawBytes[10].ToString("X2") + " " + rawBytes[11].ToString("X2") + "]";
                    int qty = rawBytes[10] << 8 | rawBytes[11];
                    result += " --> Quantity: " + qty.ToString() + Environment.NewLine;
                }
                else
                {
                    result += " ==== response ==== " + Environment.NewLine;
                    result += "[" + rawBytes[8].ToString("X2") + "]";
                    int count = rawBytes[8];
                    result += " --> Data Bytes: " + count.ToString() + Environment.NewLine;

                    result += "Bit Status --> " + Environment.NewLine + "   ";
                    bool[] bitStates = ModbusUtils.ParseBitMessage(rawBytes, count * 8);
                    for (int i=0; i< bitStates.Length; i++)
                    {
                        result += i + ":" + (bitStates[i] ? "1, " : "0, ");
                        if ((i+1) % 8 == 0)
                            result += Environment.NewLine + "   ";
                    }
                }
            }
            else if ((Function)funcCode == Function.READ_HOREG || (Function)funcCode == Function.READ_INREG)
            {
                // read
                if (length == 6)
                {
                    result += Environment.NewLine + " ==== request ==== " + Environment.NewLine;
                    result += "[" + rawBytes[8].ToString("X2") + " " + rawBytes[9].ToString("X2") + "]";
                    int addr = rawBytes[8] << 8 | rawBytes[9];
                    result += " --> Start Address: " + addr.ToString() + Environment.NewLine;

                    result += "[" + rawBytes[10].ToString("X2") + " " + rawBytes[11].ToString("X2") + "]";
                    int qty = rawBytes[10] << 8 | rawBytes[11];
                    result += " --> Quantity: " + qty.ToString() + Environment.NewLine;
                }
                else
                {
                    result += Environment.NewLine + " ==== response ==== " + Environment.NewLine;
                    result += "[" + rawBytes[8].ToString("X2") + "]";
                    int count = rawBytes[8];
                    result += " --> Data Bytes: " + count.ToString() + Environment.NewLine;

                    result += "Analog Data --> " + Environment.NewLine;
                    ushort[] values = ModbusUtils.ParseRegMessage(rawBytes, count/2);
                    for (int i = 0; i < values.Length; i++)
                    {
                        int value = rawBytes[9+i*2] << 8 | rawBytes[10+i*2];
                        result += "   [" + rawBytes[9 + i * 2].ToString("X2") + " " + rawBytes[10 + i * 2].ToString("X2") + "]";
                        result += " -->" + value.ToString() + Environment.NewLine;
                    }
                }
            }
            else if ((Function)funcCode == Function.WRITE_REG)
            {
                // write - response
                if (length == 6)
                {
                    result += Environment.NewLine + " ==== response ==== " + Environment.NewLine;
                    result += "[" + rawBytes[8].ToString("X2") + " " + rawBytes[9].ToString("X2") + "]";
                    int addr = rawBytes[8] << 8 | rawBytes[9];
                    result += " --> Start Address: " + addr.ToString() + Environment.NewLine;

                    result += "[" + rawBytes[10].ToString("X2") + " " + rawBytes[11].ToString("X2") + "]";
                    int qty = rawBytes[10] << 8 | rawBytes[11];
                    result += " --> Quantity: " + qty.ToString() + Environment.NewLine;
                }
                else
                {
                    result += Environment.NewLine + " ==== request ==== " + Environment.NewLine;
                    result += "[" + rawBytes[8].ToString("X2") + " " + rawBytes[9].ToString("X2") + "]";
                    int addr = rawBytes[8] << 8 | rawBytes[9];
                    result += " --> Start Address: " + addr.ToString() + Environment.NewLine;

                    result += "Writing Analog Data: ";
                    int value = rawBytes[9] << 8 | rawBytes[10];
                    result += "   [" + rawBytes[9].ToString("X2") + " " + rawBytes[10].ToString("X2") + "]";
                    result += " -->" + value.ToString() + Environment.NewLine;
                }
            }
            else if ((Function)funcCode == Function.WRITE_MREG)
            {
                // write - response
                if (length == 6)
                {
                    result += Environment.NewLine + " ==== response ==== " + Environment.NewLine;
                    result += "[" + rawBytes[8].ToString("X2") + " " + rawBytes[9].ToString("X2") + "]";
                    int addr = rawBytes[8] << 8 | rawBytes[9];
                    result += " --> Start Address: " + addr.ToString() + Environment.NewLine;

                    result += "[" + rawBytes[10].ToString("X2") + " " + rawBytes[11].ToString("X2") + "]";
                    int qty = rawBytes[10] << 8 | rawBytes[11];
                    result += " --> Quantity: " + qty.ToString() + Environment.NewLine;
                }
                else
                {
                    result += Environment.NewLine + " ==== request ==== " + Environment.NewLine;
                    result += "[" + rawBytes[8].ToString("X2") + " " + rawBytes[9].ToString("X2") + "]";
                    int addr = rawBytes[8] << 8 | rawBytes[9];
                    result += " --> Start Address: " + addr.ToString() + Environment.NewLine;

                    result += "[" + rawBytes[10].ToString("X2") + " " + rawBytes[11].ToString("X2") + "]";
                    int qty = rawBytes[10] << 8 | rawBytes[11];
                    result += " --> Quantity: " + qty.ToString() + Environment.NewLine;

                    result += "[" + rawBytes[12].ToString("X2") + "]";
                    int count = rawBytes[12];
                    result += " --> Data Bytes: " + count.ToString() + Environment.NewLine;

                    result += "Writing Analog Data: " + Environment.NewLine;
                    for (int i = 0; i < qty; i++)
                    {
                        int value = rawBytes[13 + i * 2] << 8 | rawBytes[14 + i * 2];
                        result += "   [" + rawBytes[13 + i * 2].ToString("X2") + " " + rawBytes[14 + i * 2].ToString("X2") + "]";
                        result += " --> " + value.ToString() + Environment.NewLine;
                    }
                }
            }

            // TODO WRITE COIL, REGISTER
            txtResult.Text = result;
        }
    }
}
