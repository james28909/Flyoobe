using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Flyby11
{
    public class FAQHandler
    {
        private readonly Panel _faqPanel;
        private readonly Action<string> _updateStatus;

        public FAQHandler(Panel faqPanel, Action<string> updateStatus)
        {
            _faqPanel = faqPanel;
            _updateStatus = updateStatus;
        }

        public void InitializeFAQ()
        {
            _faqPanel.AutoScroll = true;
            _faqPanel.Controls.Clear();

            var faqContentPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(10),
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false
            };

            AddTitle(faqContentPanel);
            AddISOFAQ(faqContentPanel);
            AddOtherFAQs(faqContentPanel);

            _faqPanel.Controls.Add(faqContentPanel);
        }

        private void AddTitle(FlowLayoutPanel parent)
        {
            AddLabel(parent, "Frequently Asked Questions (FAQ)", new Font("Arial", 10, FontStyle.Bold), DockStyle.Top, ContentAlignment.MiddleCenter, 10);
        }

        private void AddISOFAQ(FlowLayoutPanel parent)
        {
            // Q: Where can I get the latest Windows 11 ISO?
            AddLabel(parent, "Q: Where can I get the latest Windows 11 ISO?", new Font("Arial", 10, FontStyle.Bold), ContentAlignment.TopLeft, 10);
            AddLabel(parent, "A: You can download the latest ISO from the official Microsoft website or use the Fido Downloader.", new Font("Arial", 10), ContentAlignment.TopLeft, 10);

            // Create a FlowLayoutPanel to place the links next to each other
            var linkPanel = new FlowLayoutPanel
            {
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true
            };

            // Microsoft link 
            AddFAQItem(linkPanel, "Microsoft Site", "https://www.microsoft.com/software-download/windows11");

            // Fido Downloader link (with text and URL, using AddFAQItemWithScript)
            AddFAQItemWithScript(linkPanel, "Download via Fido (Recommended)", "or", "https://raw.githubusercontent.com/pbatard/Fido/refs/heads/master/Fido.ps1");

            // Add the FlowLayoutPanel to the parent (FAQ panel)
            parent.Controls.Add(linkPanel);
        }

        private void AddFAQItem(FlowLayoutPanel parent, string linkText, string linkUrl)
        {
            // Create and add the link label with the provided text and URL
            var linkLabel = new LinkLabel
            {
                Text = linkText,
                Font = new Font("Arial", 10, FontStyle.Underline),
                LinkColor = Color.Blue,
                AutoSize = true,
                Padding = new Padding(10),
                TextAlign = ContentAlignment.TopLeft
            };

            linkLabel.LinkClicked += (sender, e) => System.Diagnostics.Process.Start(linkUrl);
            parent.Controls.Add(linkLabel);
        }

        private void AddFAQItemWithScript(FlowLayoutPanel parent, string linkText, string description, string scriptUrl)
        {
            // Create and add the description label
            AddLabel(parent, description, new Font("Arial",9), ContentAlignment.TopLeft, 10);

            // Create and add the link label
            var linkLabel = new LinkLabel
            {
                Text = linkText,
                Font = new Font("Arial", 10, FontStyle.Underline),
                LinkColor = Color.Blue,
                AutoSize = true,
                Padding = new Padding(10),
                TextAlign = ContentAlignment.TopLeft
            };

            linkLabel.LinkClicked += async (sender, e) =>
            {
                string tempScriptPath = Path.Combine(Path.GetTempPath(), "Fido.ps1");

                try
                {
                    using (var client = new WebClient())
                    {
                        await client.DownloadFileTaskAsync(new Uri(scriptUrl), tempScriptPath);
                        _updateStatus("Fido downloaded successfully! Now running the script...");

                        System.Diagnostics.Process.Start(new ProcessStartInfo
                        {
                            FileName = "powershell.exe",
                            Arguments = $"-ExecutionPolicy Bypass -File \"{tempScriptPath}\"",
                            Verb = "runas",
                            CreateNoWindow = true,
                            UseShellExecute = true
                        });
                    }
                }
                catch (Exception ex)
                {
                    _updateStatus("Error downloading or running the script: " + ex.Message);
                }
            };

            parent.Controls.Add(linkLabel);
        }

        private void AddLabel(FlowLayoutPanel parent, string text, Font font, ContentAlignment alignment, int padding = 0)
        {
            var label = new Label
            {
                Text = text,
                Font = font,
                Padding = new Padding(padding),
                TextAlign = alignment,
                AutoSize = true
            };
            parent.Controls.Add(label);
        }

        private void AddLabel(FlowLayoutPanel parent, string text, Font font, DockStyle dock, ContentAlignment alignment, int padding = 0)
        {
            var label = new Label
            {
                Text = text,
                Font = font,
                Padding = new Padding(padding),
                Dock = dock,
                TextAlign = alignment,
                AutoSize = true
            };
            parent.Controls.Add(label);
        }

        private void AddFAQItem(FlowLayoutPanel parent, string question, string answer, string linkText, string linkUrl)
        {
            AddLabel(parent, question, new Font("Arial", 10, FontStyle.Bold), ContentAlignment.TopLeft, 10);
            AddLabel(parent, answer, new Font("Arial", 10), ContentAlignment.TopLeft, 10);

            var linkLabel = new LinkLabel
            {
                Text = linkText,
                Font = new Font("Arial", 10, FontStyle.Underline),
                LinkColor = Color.Blue,
                AutoSize = true,
                Padding = new Padding(10),
                TextAlign = ContentAlignment.TopLeft
            };

            linkLabel.LinkClicked += (sender, e) => System.Diagnostics.Process.Start(linkUrl);
            parent.Controls.Add(linkLabel);
        }

        private void AddOtherFAQs(FlowLayoutPanel parent)
        {
       
            // Q: How can I support the developer?
            AddFAQItem(parent, "Q: How can I support the developer?", "A: If you've successfully installed Windows 11 and saved some money, feel free to leave a little something as a thank-you here.", "Click here to donate and show your support.", "https://www.paypal.com/donate?hosted_button_id=MY7HX4QLYR4KG");

            // Q: How does the setup process work once the ISO is mounted?
            AddLabel(parent, "Q: How does the setup process work once the ISO is mounted?", new Font("Arial", 10, FontStyle.Bold), ContentAlignment.TopLeft, 10);
            AddLabel(parent, "A: Once the ISO is mounted, the setup process runs in the background. The Windows installer starts, guiding you through the steps required to install Windows 11 on your machine.", new Font("Arial", 10), ContentAlignment.TopLeft, 10);

            // Q: What if I encounter issues during installation?
            AddLabel(parent, "Q: What if I encounter issues during installation?", new Font("Arial", 10, FontStyle.Bold), ContentAlignment.TopLeft, 10);
            AddLabel(parent, "A: Please check the error messages and report it on GitHub.", new Font("Arial", 10), ContentAlignment.TopLeft, 10);

            // Q: What is the setup path for Windows 11?
            AddLabel(parent, "Q: What is the setup path for Windows 11?", new Font("Arial", 10, FontStyle.Bold), ContentAlignment.TopLeft, 10);
            AddLabel(parent, "A: The setup path is typically found under the 'sources' folder on the mounted ISO drive.", new Font("Arial", 10), ContentAlignment.TopLeft, 10);

            // Q: Is it legal to use this method?
            AddLabel(parent, "Q: Is it legal to use this method?", new Font("Arial", 10, FontStyle.Bold), ContentAlignment.TopLeft, 10);
            AddLabel(parent, "A: Yes, Microsoft has left a backdoor open. This method leverages a feature of the Windows 11 setup process that uses the Windows Server variant of the installation. Unlike the regular Windows 11 setup, this variant skips most hardware compatibility checks.", new Font("Arial", 10), ContentAlignment.TopLeft, 10);

            // Q: What are my alternatives if my PC is not supported?
            AddLabel(parent, "Q: What are my alternatives if my PC is not supported?", new Font("Arial", 10, FontStyle.Bold), ContentAlignment.TopLeft, 10);
            AddLabel(parent, "A: According to Microsoft, you should throw your PC away. I would suggest installing Linux on it and moving away from Windows.", new Font("Arial", 10), ContentAlignment.TopLeft, 10);

            // Q: Who is the developer?
            AddFAQItem(parent, "Q: Who is the developer?", "A: The developer is Belim, also known as Builtbybel, who has contributed a lot of code to the Windows community.", "Click here to learn more about the developer's work.", "https://github.com/BuiltByBel");
        }
    }
}