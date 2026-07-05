using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TagModbus
{
    //public delegate void delegateConsole(string Format, params object[] args);

    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 150;
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 50, Top = 20, Width = 400, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 45, Width = 400, Text = text };
            textBox.SelectAll();
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.ShowDialog();
            return textBox.Text;
        }
    }

  [StructLayout(LayoutKind.Explicit)]
  struct Int32Converter
  {
    [FieldOffset(0)] public int Value;
    [FieldOffset(0)] public byte Byte1;
    [FieldOffset(1)] public byte Byte2;
    [FieldOffset(2)] public byte Byte3;
    [FieldOffset(3)] public byte Byte4;

    public Int32Converter(int value)
    {
      Byte1 = Byte2 = Byte3 = Byte4 = 0;
      Value = value;
    }

    public static implicit operator Int32(Int32Converter value)
    {
      return value.Value;
    }

    public static implicit operator Int32Converter(int value)
    {
      return new Int32Converter(value);
    }
  }
}
