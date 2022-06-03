namespace WindowsFormsApp_WebView2_test
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.addressbar = new System.Windows.Forms.TextBox();
            this.goButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            this.SuspendLayout();
            // 
            // webView
            // 
            this.webView.CreationProperties = null;
            this.webView.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView.Location = new System.Drawing.Point(0, 40);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(800, 410);
            this.webView.Source = new System.Uri("http://www.bitbytebytes.io", System.UriKind.Absolute);
            this.webView.TabIndex = 0;
            this.webView.ZoomFactor = 1D;
            // 
            // addressbar
            // 
            this.addressbar.Location = new System.Drawing.Point(0, 14);
            this.addressbar.Name = "addressbar";
            this.addressbar.Size = new System.Drawing.Size(707, 20);
            this.addressbar.TabIndex = 1;
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(707, 12);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(93, 23);
            this.goButton.TabIndex = 2;
            this.goButton.Text = "Go!";
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            this.goButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.addressbar);
            this.Controls.Add(this.webView);
            this.Name = "Form1";
            this.Text = "Frame Title";
            ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private System.Windows.Forms.TextBox addressbar;
        private System.Windows.Forms.Button goButton;
    }
}