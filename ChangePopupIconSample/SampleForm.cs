﻿using System;
using System.Configuration;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using WinFormsCefSharpSample.JsMessageSample;

namespace WinFormsCefSharpSample.ChangePopupIconSample
{
    public partial class SampleForm : Form
    {
        public SampleForm()
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

            // JavaScriptの実験用htmlのパス(実際にデバッグする際はこちらでいけるはず)
            // index.htmlとpopup.htmlをプロジェクトに含める。
            // その上でビルド時にファイルコピーするためように出力ディレクトリにコピーというプロパティを常にコピーに変更する
            var path = System.Environment.CurrentDirectory + @"\ChangePopupIconSample\index.html";

            chromeBrowser = new ChromiumWebBrowser(path);
            // Add it to the form and fill it to the form window.
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;

            var lifespanHandler = new LifespanHandler();
            chromeBrowser.LifeSpanHandler = lifespanHandler;
        }

        private void ChromeBrowserOnIsBrowserInitializedChanged(object sender, EventArgs e)
        {
            var chromiumBrowser = sender as ChromiumWebBrowser;
            chromiumBrowser?.ShowDevTools();
        }
    }
}
