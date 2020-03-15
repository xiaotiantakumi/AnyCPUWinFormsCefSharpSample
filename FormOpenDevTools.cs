using System;
using System.Configuration;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace WinFormsCefSharpSample
{
    public partial class FormOpenDevTools : Form
    {
        public FormOpenDevTools()
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



            // DeveloperToolを立ち上げる。Initializeが終わった後に呼ぶ必要があるのでイベントにアタッチ
            bool parseRet = bool.TryParse(ConfigurationManager.AppSettings["isShowDevTool"], out bool isShowDevTool);
            if (parseRet && isShowDevTool)
            {
                chromeBrowser.IsBrowserInitializedChanged += ChromeBrowserOnIsBrowserInitializedChanged;
            }
        }

        private void ChromeBrowserOnIsBrowserInitializedChanged(object sender, EventArgs e)
        {
            var chromiumBrowser = sender as ChromiumWebBrowser;
            chromiumBrowser?.ShowDevTools();
        }
    }
}
