using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using CefSharp;

namespace WinFormsCefSharpSample.ChangePopupIconSample
{
    class LifespanHandler : ILifeSpanHandler
    {
        public bool OnBeforePopup(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl,
            string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures,
            IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            newBrowser = null;
            return false;
        }

        /// <summary>
        /// Win32APIのSendMessage(Formのアイコンを変更するために使用する)
        /// </summary>
        /// <param name="hwnd">送信先ウィンドウのハンドル</param>
        /// <param name="message">メッセージ</param>
        /// <param name="wParam">メッセージの最初のパラメータ</param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hwnd, int message, int wParam, IntPtr lParam);
        /// <summary>
        /// Win32APIのShowWindowAsync(画面サイズを最大化させるために使用)
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int ShowWindowAsync(IntPtr hwnd, int nCmdShow);

        private const int WM_SETICON = 0x80;
        private const int ICON_BIG = 1;
        private const int SIZE_MAXIMIZED = 3;


        public void OnAfterCreated(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            try
            {
                var windHandler = browser.GetHost().GetWindowHandle();
                // winformのアイコンを変更する
                using (var icon = new Icon(Directory.GetCurrentDirectory() + @"\ChangePopupIconSample\myIcon.ico"))
                {
                    SendMessage(windHandler, WM_SETICON, ICON_BIG, icon.Handle);
                }
                // 画面サイズを最大化する
                ShowWindowAsync(windHandler, SIZE_MAXIMIZED);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public bool DoClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            return false;
        }

        public void OnBeforeClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
        }
    }
}
