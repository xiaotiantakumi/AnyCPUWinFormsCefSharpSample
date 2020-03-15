using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace WinFormsCefSharpSample
{
    public partial class FormBasic : Form
    {
        public FormBasic()
        {
            InitializeComponent();
            InitializeChromium();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        public ChromiumWebBrowser chromeBrowser;
        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            // CefのInitializeは一度だけ
            if (!Cef.IsInitialized)
            {
                // Initialize cef with the provided settings
                Cef.Initialize(settings);
                // これを入れないと黒い余白が発生していまう。
                Cef.EnableHighDPISupport();
            }

            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser("https://takumi-oda.com/blog/");
            // Add it to the form and fill it to the form window.
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
        }
    }
}
