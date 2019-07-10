using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_EdgeBrowser
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            webview.ScriptNotify += Webview_ScriptNotify;
            webview.IsJavaScriptEnabled = true;

            webview.IsScriptNotifyAllowed = true;
        }

        private void Webview_ScriptNotify(object sender, WebViewControlScriptNotifyEventArgs e)
        {
            MessageBox.Show("JavaScript调用C#成功！");
            //throw new NotImplementedException();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            webview.NavigateToLocal("report.html");


           
           //// webview.ScriptNotify += new NotifyEventHandler(MainWebview_ScriptNotify);
           // webview.Navigate(new Uri("http://www.bing.com"));


            
            //webview.NavigateToLocalStreamUri(new Uri("//report.html",UriKind.Relative),null);
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string[] args = { "January", "1", "2000" };
            string returnValue = await webview.InvokeScriptAsync("setDate", args);
        }

        private async void InjectContent2H5_Click(object sender, RoutedEventArgs e)
        {
            //private async void Button_Click(object sender, RoutedEventArgs e)
            {
                string functionString = String.Format("document.getElementById('nameDiv').innerText = 'Hello, {0}';","直接写入文字");
                await webview.InvokeScriptAsync("eval", new string[] { functionString });
            }
        }

        public string SS()
        {
            MessageBox.Show("ss()");
            return ("调用了C#代码！");
        }

        protected string CsharpVoid(string strCC)
        {
            MessageBox.Show(strCC);
            return strCC;
        }

        protected void CsharpVoid()
        {
            string strCC = "(((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((";
        }

        public void MyMessageBox(string message)
        {
            MessageBox.Show(message);
        }

        public string Getstr()
        {
            string aa = "你们好啊！";
            return aa;
        }
    }
}
