using System;
using System.Windows.Forms;

namespace TagModbusSvr
{
    static class Program
    {
        public static MainForm mainForm;

        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // configure log4net
                log4net.Config.XmlConfigurator.Configure(
                    new System.IO.FileInfo(
                        System.IO.Path.Combine(Application.StartupPath, "config", "log4net.xml")));

                mainForm = new MainForm();
                Application.Run(mainForm);
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.Message);
            }
        }
    }
}
