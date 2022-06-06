﻿using System;
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
            this.Resize += new System.EventHandler(this.FormResize);
            webView.Size = this.ClientSize - new System.Drawing.Size(webView.Location);
            goButton.Left = webView.Size.Width - goButton.Width - 8;
            addressbar.Width = goButton.Left - 16;
            addressbar.Left = 8;
            webView.Source = new Uri(Path.Combine(Environment.CurrentDirectory, @"html\leafletTest.html"));
            InitializeAsync();
        }

        async void InitializeAsync()
        {
            await webView.EnsureCoreWebView2Async(null);
            webView.CoreWebView2.WebMessageReceived += MessageReceived;
        }

        private void FormResize(object sender, EventArgs e)
        {
            webView.Size = this.ClientSize - new System.Drawing.Size(webView.Location);
            goButton.Left = webView.Size.Width - goButton.Width;
            addressbar.Width = goButton.Left;
            addressbar.Left = 0;

            webView.Reload(); 
        }

        private async void SendMessage(object sender, EventArgs e)
        {
            if (webView != null && webView.CoreWebView2 != null)
            {
                webView.CoreWebView2.PostWebMessageAsString("Message from Dotnet buttton");
            }
        }

        void MessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs args)
        {
            String content = args.TryGetWebMessageAsString();
            addressbar.Text = content;
        }
    }
}
