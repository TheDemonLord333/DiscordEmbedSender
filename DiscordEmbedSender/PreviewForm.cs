using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DiscordEmbedSender
{
    public partial class PreviewForm : Form
    {
        private readonly Dictionary<string, object> embedData;

        public PreviewForm(Dictionary<string, object> embedData)
        {
            this.embedData = embedData;
            InitializeComponent();
            LoadPreview();
        }

        private void InitializeComponent()
        {
            this.Text = "Embed Vorschau";
            this.Size = new Size(700, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MinimumSize = new Size(600, 400);

            // Tab Control for different preview types
            TabControl tabControl = new TabControl();
            tabControl.Dock = DockStyle.Fill;

            // JSON Tab
            TabPage jsonTab = new TabPage("JSON");
            TextBox jsonTextBox = new TextBox();
            jsonTextBox.Multiline = true;
            jsonTextBox.ScrollBars = ScrollBars.Both;
            jsonTextBox.Dock = DockStyle.Fill;
            jsonTextBox.ReadOnly = true;
            jsonTextBox.Font = new Font("Consolas", 10);
            jsonTextBox.Text = JsonConvert.SerializeObject(embedData, Newtonsoft.Json.Formatting.Indented);
            jsonTab.Controls.Add(jsonTextBox);

            // Visual Preview Tab
            TabPage visualTab = new TabPage("Visuelle Vorschau");
            Panel visualPanel = CreateVisualPreview();
            visualTab.Controls.Add(visualPanel);

            // Info Tab
            TabPage infoTab = new TabPage("Information");
            Panel infoPanel = CreateInfoPanel();
            infoTab.Controls.Add(infoPanel);

            tabControl.TabPages.Add(visualTab);
            tabControl.TabPages.Add(jsonTab);
            tabControl.TabPages.Add(infoTab);

            // Close button
            Panel buttonPanel = new Panel();
            buttonPanel.Height = 50;
            buttonPanel.Dock = DockStyle.Bottom;

            Button closeButton = new Button();
            closeButton.Text = "Schließen";
            closeButton.Size = new Size(100, 30);
            closeButton.Anchor = AnchorStyles.Right;
            closeButton.Location = new Point(buttonPanel.Width - 110, 10);
            closeButton.Click += (s, e) => this.Close();

            Button copyJsonButton = new Button();
            copyJsonButton.Text = "JSON kopieren";
            copyJsonButton.Size = new Size(120, 30);
            copyJsonButton.Anchor = AnchorStyles.Right;
            copyJsonButton.Location = new Point(buttonPanel.Width - 240, 10);
            copyJsonButton.Click += (s, e) =>
            {
                Clipboard.SetText(JsonConvert.SerializeObject(embedData, Newtonsoft.Json.Formatting.Indented));
                MessageBox.Show("JSON in Zwischenablage kopiert!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            buttonPanel.Controls.Add(closeButton);
            buttonPanel.Controls.Add(copyJsonButton);

            this.Controls.Add(tabControl);
            this.Controls.Add(buttonPanel);
        }

        private Panel CreateVisualPreview()
        {
            Panel mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.BackColor = Color.FromArgb(54, 57, 63); // Discord dark theme background
            mainPanel.Padding = new Padding(20);

            // Embed container
            Panel embedPanel = new Panel();
            embedPanel.BackColor = Color.FromArgb(47, 49, 54); // Discord embed background
            embedPanel.Size = new Size(500, 400);
            embedPanel.Location = new Point(20, 20);
            embedPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Color bar (left side of embed)
            Panel colorBar = new Panel();
            colorBar.Width = 4;
            colorBar.Height = embedPanel.Height;
            colorBar.Location = new Point(0, 0);
            colorBar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;

            // Set color from embed
            if (embedData.ContainsKey("color") && int.TryParse(embedData["color"].ToString(), out int colorValue))
            {
                colorBar.BackColor = Color.FromArgb(colorValue);
            }
            else
            {
                colorBar.BackColor = Color.FromArgb(32, 34, 37); // Default dark color
            }

            embedPanel.Controls.Add(colorBar);

            // Content panel
            Panel contentPanel = new Panel();
            contentPanel.Location = new Point(15, 10);
            contentPanel.Size = new Size(embedPanel.Width - 25, embedPanel.Height - 20);
            contentPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            int yPosition = 10;

            // Author
            if (embedData.ContainsKey("author"))
            {
                Label authorLabel = new Label();
                var author = JsonConvert.DeserializeObject<Dictionary<string, object>>(embedData["author"].ToString());
                authorLabel.Text = author["name"].ToString();
                authorLabel.ForeColor = Color.White;
                authorLabel.Font = new Font("Arial", 9, FontStyle.Bold);
                authorLabel.Location = new Point(0, yPosition);
                authorLabel.AutoSize = true;
                contentPanel.Controls.Add(authorLabel);
                yPosition += 25;
            }

            // Title
            if (embedData.ContainsKey("title"))
            {
                Label titleLabel = new Label();
                titleLabel.Text = embedData["title"].ToString();
                titleLabel.ForeColor = Color.FromArgb(0, 176, 244); // Discord link color
                titleLabel.Font = new Font("Arial", 12, FontStyle.Bold);
                titleLabel.Location = new Point(0, yPosition);
                titleLabel.MaximumSize = new Size(contentPanel.Width - 20, 0);
                titleLabel.AutoSize = true;
                contentPanel.Controls.Add(titleLabel);
                yPosition += titleLabel.Height + 10;
            }

            // Description
            if (embedData.ContainsKey("description"))
            {
                Label descLabel = new Label();
                descLabel.Text = embedData["description"].ToString();
                descLabel.ForeColor = Color.FromArgb(220, 221, 222);
                descLabel.Font = new Font("Arial", 10);
                descLabel.Location = new Point(0, yPosition);
                descLabel.MaximumSize = new Size(contentPanel.Width - 20, 0);
                descLabel.AutoSize = true;
                contentPanel.Controls.Add(descLabel);
                yPosition += descLabel.Height + 15;
            }

            // Fields
            if (embedData.ContainsKey("fields"))
            {
                var fields = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(embedData["fields"].ToString());

                int fieldX = 0;
                int fieldY = yPosition;
                int maxFieldWidth = (contentPanel.Width - 40) / 3; // For inline fields

                foreach (var field in fields)
                {
                    bool isInline = false;
                    if (field.ContainsKey("inline"))
                    {
                        bool.TryParse(field["inline"].ToString(), out isInline);
                    }

                    // Field name
                    Label fieldNameLabel = new Label();
                    fieldNameLabel.Text = field["name"].ToString();
                    fieldNameLabel.ForeColor = Color.White;
                    fieldNameLabel.Font = new Font("Arial", 9, FontStyle.Bold);
                    fieldNameLabel.Location = new Point(fieldX, fieldY);
                    fieldNameLabel.MaximumSize = new Size(isInline ? maxFieldWidth : contentPanel.Width - 20, 0);
                    fieldNameLabel.AutoSize = true;
                    contentPanel.Controls.Add(fieldNameLabel);

                    // Field value
                    Label fieldValueLabel = new Label();
                    fieldValueLabel.Text = field["value"].ToString();
                    fieldValueLabel.ForeColor = Color.FromArgb(220, 221, 222);
                    fieldValueLabel.Font = new Font("Arial", 9);
                    fieldValueLabel.Location = new Point(fieldX, fieldY + fieldNameLabel.Height + 5);
                    fieldValueLabel.MaximumSize = new Size(isInline ? maxFieldWidth : contentPanel.Width - 20, 0);
                    fieldValueLabel.AutoSize = true;
                    contentPanel.Controls.Add(fieldValueLabel);

                    if (isInline)
                    {
                        fieldX += maxFieldWidth + 10;
                        if (fieldX + maxFieldWidth > contentPanel.Width - 20)
                        {
                            fieldX = 0;
                            fieldY += Math.Max(fieldNameLabel.Height + fieldValueLabel.Height + 20, 60);
                        }
                    }
                    else
                    {
                        fieldX = 0;
                        fieldY += fieldNameLabel.Height + fieldValueLabel.Height + 20;
                    }
                }

                yPosition = fieldY + 20;
            }

            // Footer
            if (embedData.ContainsKey("footer"))
            {
                var footer = JsonConvert.DeserializeObject<Dictionary<string, object>>(embedData["footer"].ToString());
                Label footerLabel = new Label();
                footerLabel.Text = footer["text"].ToString();
                footerLabel.ForeColor = Color.FromArgb(114, 118, 125);
                footerLabel.Font = new Font("Arial", 8);
                footerLabel.Location = new Point(0, contentPanel.Height - 30);
                footerLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
                footerLabel.AutoSize = true;
                contentPanel.Controls.Add(footerLabel);
            }

            // Timestamp
            if (embedData.ContainsKey("timestamp"))
            {
                Label timestampLabel = new Label();
                timestampLabel.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
                timestampLabel.ForeColor = Color.FromArgb(114, 118, 125);
                timestampLabel.Font = new Font("Arial", 8);
                timestampLabel.Location = new Point(contentPanel.Width - 120, contentPanel.Height - 30);
                timestampLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                timestampLabel.AutoSize = true;
                contentPanel.Controls.Add(timestampLabel);
            }

            embedPanel.Controls.Add(contentPanel);
            mainPanel.Controls.Add(embedPanel);

            return mainPanel;
        }

        private Panel CreateInfoPanel()
        {
            Panel infoPanel = new Panel();
            infoPanel.Dock = DockStyle.Fill;
            infoPanel.BackColor = Color.White;
            infoPanel.Padding = new Padding(20);

            int yPos = 20;

            // Title
            Label titleLabel = new Label();
            titleLabel.Text = "Embed Statistiken";
            titleLabel.Font = new Font("Arial", 14, FontStyle.Bold);
            titleLabel.Location = new Point(20, yPos);
            titleLabel.AutoSize = true;
            infoPanel.Controls.Add(titleLabel);
            yPos += 40;

            // Character counts
            int totalChars = CalculateCharacterCount();

            AddInfoRow(infoPanel, "Gesamtzeichen:", $"{totalChars}/6000", ref yPos);

            if (embedData.ContainsKey("title"))
                AddInfoRow(infoPanel, "Titel:", $"{embedData["title"].ToString().Length}/256 Zeichen", ref yPos);

            if (embedData.ContainsKey("description"))
                AddInfoRow(infoPanel, "Beschreibung:", $"{embedData["description"].ToString().Length}/4096 Zeichen", ref yPos);

            if (embedData.ContainsKey("fields"))
            {
                var fields = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(embedData["fields"].ToString());
                AddInfoRow(infoPanel, "Fields:", $"{fields.Count}/25", ref yPos);
            }

            yPos += 20;

            // Validation
            Label validationLabel = new Label();
            validationLabel.Text = "Validierung";
            validationLabel.Font = new Font("Arial", 12, FontStyle.Bold);
            validationLabel.Location = new Point(20, yPos);
            validationLabel.AutoSize = true;
            infoPanel.Controls.Add(validationLabel);
            yPos += 30;

            try
            {
                var builder = new EmbedBuilder();
                // Simple validation - check if embed has content
                if (!embedData.ContainsKey("title") && !embedData.ContainsKey("description"))
                {
                    AddInfoRow(infoPanel, "❌", "Embed benötigt mindestens Titel oder Beschreibung", ref yPos);
                }
                else
                {
                    AddInfoRow(infoPanel, "✅", "Embed ist gültig", ref yPos);
                }

                if (totalChars > 6000)
                {
                    AddInfoRow(infoPanel, "❌", "Embed überschreitet Zeichenlimit", ref yPos, Color.Red);
                }
                else
                {
                    AddInfoRow(infoPanel, "✅", "Zeichenlimit eingehalten", ref yPos, Color.Green);
                }
            }
            catch (Exception ex)
            {
                AddInfoRow(infoPanel, "❌", $"Validierungsfehler: {ex.Message}", ref yPos, Color.Red);
            }

            return infoPanel;
        }

        private void AddInfoRow(Panel parent, string label, string value, ref int yPosition, Color? textColor = null)
        {
            Label lblLabel = new Label();
            lblLabel.Text = label;
            lblLabel.Font = new Font("Arial", 10, FontStyle.Bold);
            lblLabel.Location = new Point(20, yPosition);
            lblLabel.Size = new Size(150, 20);
            parent.Controls.Add(lblLabel);

            Label lblValue = new Label();
            lblValue.Text = value;
            lblValue.Font = new Font("Arial", 10);
            lblValue.ForeColor = textColor ?? Color.Black;
            lblValue.Location = new Point(180, yPosition);
            lblValue.AutoSize = true;
            parent.Controls.Add(lblValue);

            yPosition += 25;
        }

        private int CalculateCharacterCount()
        {
            int total = 0;

            if (embedData.ContainsKey("title"))
                total += embedData["title"].ToString().Length;

            if (embedData.ContainsKey("description"))
                total += embedData["description"].ToString().Length;

            if (embedData.ContainsKey("footer"))
            {
                var footer = JsonConvert.DeserializeObject<Dictionary<string, object>>(embedData["footer"].ToString());
                total += footer["text"].ToString().Length;
            }

            if (embedData.ContainsKey("author"))
            {
                var author = JsonConvert.DeserializeObject<Dictionary<string, object>>(embedData["author"].ToString());
                total += author["name"].ToString().Length;
            }

            if (embedData.ContainsKey("fields"))
            {
                var fields = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(embedData["fields"].ToString());
                foreach (var field in fields)
                {
                    total += field["name"].ToString().Length + field["value"].ToString().Length;
                }
            }

            return total;
        }

        private void LoadPreview()
        {
            // This method can be used for additional initialization if needed
        }
    }
}