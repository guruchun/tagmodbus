using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TagModbus
{
    static class Program
    {
        /// define logger
        /// 
        
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        public static MainForm mainForm;

        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // define logger
                log4net.Config.XmlConfigurator.Configure(
                    new System.IO.FileInfo(
                        System.IO.Path.Combine(Application.StartupPath, "config", "client-log4net.xml")));

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
