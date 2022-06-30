using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
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


        // dotnet <=> js
        private async void SendMessage(object sender, EventArgs e)
        {
            if (webView != null && webView.CoreWebView2 != null)
            {
                webView.CoreWebView2.PostWebMessageAsString("Message from Dotnet buttton");
            }
        }

        private async void SendSerializedObject(object sender, EventArgs e)
        {
            if (webView != null && webView.CoreWebView2 != null)
            {
                webView.CoreWebView2.PostWebMessageAsString("Message from Dotnet buttton");
            }
        }

        void MessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs args)
        {
            try
            {
                MapMessage mapMessage = JsonSerializer.Deserialize<MapMessage>(args.WebMessageAsJson);

                if (mapMessage.action == "map-click")
                {
                    var mapClick = mapMessage.data;
                    addressbar.Text = $"map clicked @ lat:{mapClick.latlng.lat}, lng:{mapClick.latlng.lng}";
                }
                if (mapMessage.action == "js-button-clicked")
                {
                    addressbar.Text = $"js button clicked {mapMessage.data}";
                }

            }
            // if it's not a valid JSON, it's probably a string
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("{0} deserialize exception thrown", e);
                var message = args.TryGetWebMessageAsString();
                if (string.IsNullOrEmpty(message))
                    return;
                addressbar.Text = message;
            }
        }
    }

    public class MapMessage
    {
        public string action { get; set; }
        public MapEvent data { get; set; }

    }

    public class MapEvent
    {
        public string type { get; set; }
        public LatLng latlng { get; set; }
        public LayerPos layerPoint { get; set; }
        public LayerPos containerPoint { get; set; }
    }

    public class LatLng
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

    public class LayerPos
    {
        public float x { get; set; }
        public float y { get; set; }
    }
}
