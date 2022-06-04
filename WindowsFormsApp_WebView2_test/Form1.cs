using System;
using System.Windows.Forms;
using System.IO;
using Microsoft.Web.WebView2.Core;

namespace WindowsFormsApp_WebView2_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Resize += new System.EventHandler(this.Form_Resize);
            webView.Size = this.ClientSize - new System.Drawing.Size(webView.Location);
            goButton.Left = webView.Size.Width - goButton.Width;
            addressbar.Width = goButton.Left;
            addressbar.Left = 0;
            webView.Source = new Uri(Path.Combine(Environment.CurrentDirectory, @"html\leafletTest.html"));
            InitializeAsync();
        }

        async void InitializeAsync()
        {
            await webView.EnsureCoreWebView2Async(null);
            webView.CoreWebView2.WebMessageReceived += MessageReceived;
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            webView.Size = this.ClientSize - new System.Drawing.Size(webView.Location);
            goButton.Left = webView.Size.Width - goButton.Width;
            addressbar.Width = goButton.Left;
            addressbar.Left = 0;

            webView.Reload(); 
        }

        private async void goButton_Click(object sender, EventArgs e)
        {
            if (webView != null && webView.CoreWebView2 != null)
            {
                webView.CoreWebView2.PostWebMessageAsString("Message from Dotnet");
            }
        }

        void MessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs args)
        {
            String content = args.TryGetWebMessageAsString();
            addressbar.Text = content;
        }
    }
}
