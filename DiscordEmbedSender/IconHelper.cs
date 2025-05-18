using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace DiscordEmbedSender
{
    public static class IconHelper
    {
        /// <summary>
        /// Creates an icon from SVG content (simplified approach)
        /// For production use, consider using a proper SVG rendering library
        /// </summary>
        public static Icon CreateIconFromSvg(string svgContent, int size = 32)
        {
            // This is a simplified approach. In a real application, you might want to:
            // 1. Use a proper SVG rendering library like SVG.NET
            // 2. Convert SVG to bitmap properly
            // 3. Handle different DPI settings

            // For now, we'll create a simple colored icon as a fallback
            using (var bitmap = new Bitmap(size, size))
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.Transparent);

                // Draw a simple Discord-style icon
                using (var brush = new SolidBrush(ColorTranslator.FromHtml("#5865F2")))
                {
                    graphics.FillEllipse(brush, 2, 2, size - 4, size - 4);
                }

                // Add a white center shape (simplified message icon)
                using (var whiteBrush = new SolidBrush(Color.White))
                {
                    var rectWidth = size / 2;
                    var rectHeight = size / 3;
                    var rectX = (size - rectWidth) / 2;
                    var rectY = (size - rectHeight) / 2;
                    graphics.FillRectangle(whiteBrush, rectX, rectY, rectWidth, rectHeight);
                }

                return Icon.FromHandle(bitmap.GetHicon());
            }
        }

        /// <summary>
        /// Loads an icon from embedded resources
        /// </summary>
        public static Icon LoadIconFromResources(string resourceName)
        {
            try
            {
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                using (var stream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (stream != null)
                    {
                        return new Icon(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Warning($"Failed to load icon from resources: {resourceName}", ex);
            }

            // Return default icon if loading fails
            return CreateDefaultIcon();
        }

        /// <summary>
        /// Creates a default application icon
        /// </summary>
        public static Icon CreateDefaultIcon()
        {
            const int size = 32;
            using (var bitmap = new Bitmap(size, size))
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.Transparent);

                // Gradient background
                using (var brush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(size, size),
                    ColorTranslator.FromHtml("#5865F2"),
                    ColorTranslator.FromHtml("#3B44B8")))
                {
                    graphics.FillEllipse(brush, 0, 0, size, size);
                }

                // White message icon
                using (var whiteBrush = new SolidBrush(Color.White))
                {
                    // Message body
                    graphics.FillRectangle(whiteBrush, 6, 8, 20, 12);

                    // Message lines
                    using (var pen = new Pen(ColorTranslator.FromHtml("#5865F2"), 1))
                    {
                        graphics.DrawLine(pen, 8, 11, 18, 11);
                        graphics.DrawLine(pen, 8, 14, 16, 14);
                        graphics.DrawLine(pen, 8, 17, 20, 17);
                    }
                }

                return Icon.FromHandle(bitmap.GetHicon());
            }
        }

        /// <summary>
        /// Saves SVG content to a file
        /// </summary>
        public static void SaveSvgToFile(string svgContent, string filePath)
        {
            try
            {
                File.WriteAllText(filePath, svgContent);
                Logger.Info($"SVG saved to: {filePath}");
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to save SVG to {filePath}", ex);
            }
        }

        /// <summary>
        /// Extracts all SVG icons to the Icons folder
        /// </summary>
        public static void ExtractAllIcons()
        {
            var iconsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Icons");

            try
            {
                if (!Directory.Exists(iconsDir))
                {
                    Directory.CreateDirectory(iconsDir);
                }

                // You would normally extract SVG content from resources here
                // For now, we'll create placeholder files
                var icons = new[]
                {
                    "app-icon.svg",
                    "send-icon.svg",
                    "preview-icon.svg",
                    "search-user-icon.svg",
                    "add-field-icon.svg",
                    "remove-field-icon.svg"
                };

                foreach (var iconName in icons)
                {
                    var iconPath = Path.Combine(iconsDir, iconName);
                    if (!File.Exists(iconPath))
                    {
                        // Create a placeholder SVG
                        var placeholderSvg = $@"<svg viewBox=""0 0 24 24"" xmlns=""http://www.w3.org/2000/svg"">
                            <circle cx=""12"" cy=""12"" r=""10"" fill=""#5865F2""/>
                            <text x=""12"" y=""16"" text-anchor=""middle"" fill=""white"" font-size=""8"">{iconName.Split('-')[0]}</text>
                        </svg>";

                        File.WriteAllText(iconPath, placeholderSvg);
                    }
                }

                Logger.Info($"Icons extracted to: {iconsDir}");
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to extract icons", ex);
            }
        }

        /// <summary>
        /// Applies the application icon to a form
        /// </summary>
        public static void SetFormIcon(Form form)
        {
            try
            {
                form.Icon = CreateDefaultIcon();
            }
            catch (Exception ex)
            {
                Logger.Warning("Failed to set form icon", ex);
            }
        }

        /// <summary>
        /// Applies themed colors to a control
        /// </summary>
        public static void ApplyDiscordTheme(Control control)
        {
            try
            {
                // Apply Discord-like theming
                if (control is Form form)
                {
                    form.BackColor = ColorTranslator.FromHtml("#36393F");
                    form.ForeColor = Color.White;
                }
                else if (control is Button button)
                {
                    button.BackColor = ColorTranslator.FromHtml("#5865F2");
                    button.ForeColor = Color.White;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                }
                else if (control is TextBox textBox)
                {
                    textBox.BackColor = ColorTranslator.FromHtml("#40444B");
                    textBox.ForeColor = Color.White;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.BackColor = ColorTranslator.FromHtml("#40444B");
                    comboBox.ForeColor = Color.White;
                }
                else if (control is GroupBox groupBox)
                {
                    groupBox.ForeColor = Color.White;
                }
                else if (control is Label label)
                {
                    label.ForeColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                Logger.Warning($"Failed to apply theme to control: {control.GetType().Name}", ex);
            }
        }
    }
}