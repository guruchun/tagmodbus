using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace TagModbusSvr
{
    public partial class FormHelp : DockContent
    {
        public FormHelp()
        {
            InitializeComponent();
        }

        public void showHelp(string url)
        {
            //if (!url.StartsWith("http"))
            //    url = "http://10.62.27.35/redmine/projects/mcp/wiki/" +url;
            //this.web.Navigate(new Uri(url));
        }

        private void web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //// only diplay 'main' <div>
            //HtmlElement elm = web.Document.GetElementById("content");
            //if (elm != null)
            //{
            //    web.Document.Body.InnerHtml = elm.InnerHtml;
            //}

            //if (this.IsHidden)
            //    this.Show();
        }
    }
}
