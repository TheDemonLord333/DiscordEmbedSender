using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace DiscordEmbedSender
{
    public class EmbedBuilder
    {
        private readonly Dictionary<string, object> embed;
        private readonly List<EmbedField> fields;

        public EmbedBuilder()
        {
            embed = new Dictionary<string, object>();
            fields = new List<EmbedField>();
        }

        /// <summary>
        /// Setzt den Titel des Embeds (max. 256 Zeichen)
        /// </summary>
        public EmbedBuilder SetTitle(string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                if (title.Length > 256)
                    title = title.Substring(0, 256);
                embed["title"] = title;
            }
            return this;
        }

        /// <summary>
        /// Setzt die Beschreibung des Embeds (max. 4096 Zeichen)
        /// </summary>
        public EmbedBuilder SetDescription(string description)
        {
            if (!string.IsNullOrWhiteSpace(description))
            {
                if (description.Length > 4096)
                    description = description.Substring(0, 4096);
                embed["description"] = description;
            }
            return this;
        }

        /// <summary>
        /// Setzt die Farbe des Embeds (Hex-Format: #RRGGBB)
        /// </summary>
        public EmbedBuilder SetColor(string hexColor)
        {
            if (!string.IsNullOrWhiteSpace(hexColor))
            {
                try
                {
                    // Remove # if present
                    string cleanHex = hexColor.Replace("#", "");

                    // Validate hex format
                    if (cleanHex.Length == 6 && int.TryParse(cleanHex, NumberStyles.HexNumber, null, out int colorInt))
                    {
                        embed["color"] = colorInt;
                    }
                    else
                    {
                        throw new ArgumentException($"Ungültiges Hex-Farbformat: {hexColor}");
                    }
                }
                catch (Exception ex)
                {
                    throw new ArgumentException($"Fehler beim Parsen der Farbe '{hexColor}': {ex.Message}");
                }
            }
            return this;
        }

        /// <summary>
        /// Setzt die Farbe des Embeds (Integer-Wert)
        /// </summary>
        public EmbedBuilder SetColor(int color)
        {
            embed["color"] = color;
            return this;
        }

        /// <summary>
        /// Setzt das Thumbnail des Embeds
        /// </summary>
        public EmbedBuilder SetThumbnail(string url)
        {
            if (!string.IsNullOrWhiteSpace(url) && IsValidUrl(url))
            {
                embed["thumbnail"] = url;
            }
            return this;
        }

        /// <summary>
        /// Setzt das Hauptbild des Embeds
        /// </summary>
        public EmbedBuilder SetImage(string url)
        {
            if (!string.IsNullOrWhiteSpace(url) && IsValidUrl(url))
            {
                embed["image"] = url;
            }
            return this;
        }

        /// <summary>
        /// Setzt den Footer des Embeds (max. 2048 Zeichen)
        /// </summary>
        public EmbedBuilder SetFooter(string text, string iconUrl = null)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                if (text.Length > 2048)
                    text = text.Substring(0, 2048);

                var footer = new Dictionary<string, object> { ["text"] = text };

                if (!string.IsNullOrWhiteSpace(iconUrl) && IsValidUrl(iconUrl))
                    footer["icon_url"] = iconUrl;

                embed["footer"] = footer;
            }
            return this;
        }

        /// <summary>
        /// Setzt den Autor des Embeds (max. 256 Zeichen)
        /// </summary>
        public EmbedBuilder SetAuthor(string name, string url = null, string iconUrl = null)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                if (name.Length > 256)
                    name = name.Substring(0, 256);

                var author = new Dictionary<string, object> { ["name"] = name };

                if (!string.IsNullOrWhiteSpace(url) && IsValidUrl(url))
                    author["url"] = url;

                if (!string.IsNullOrWhiteSpace(iconUrl) && IsValidUrl(iconUrl))
                    author["icon_url"] = iconUrl;

                embed["author"] = author;
            }
            return this;
        }

        /// <summary>
        /// Setzt die URL des Embeds
        /// </summary>
        public EmbedBuilder SetUrl(string url)
        {
            if (!string.IsNullOrWhiteSpace(url) && IsValidUrl(url))
            {
                embed["url"] = url;
            }
            return this;
        }

        /// <summary>
        /// Setzt den Zeitstempel des Embeds
        /// </summary>
        public EmbedBuilder SetTimestamp(bool useCurrentTime = true)
        {
            if (useCurrentTime)
            {
                embed["timestamp"] = true;
            }
            return this;
        }

        /// <summary>
        /// Setzt einen spezifischen Zeitstempel
        /// </summary>
        public EmbedBuilder SetTimestamp(DateTime timestamp)
        {
            embed["timestamp"] = timestamp.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            return this;
        }

        /// <summary>
        /// Fügt ein Field zum Embed hinzu (max. 25 Fields)
        /// </summary>
        public EmbedBuilder AddField(string name, string value, bool inline = false)
        {
            if (fields.Count >= 25)
                throw new InvalidOperationException("Ein Embed kann maximal 25 Fields haben.");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Field Name darf nicht leer sein.");

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Field Value darf nicht leer sein.");

            // Limit field lengths
            if (name.Length > 256)
                name = name.Substring(0, 256);

            if (value.Length > 1024)
                value = value.Substring(0, 1024);

            fields.Add(new EmbedField(name, value, inline));
            return this;
        }

        /// <summary>
        /// Entfernt ein Field an der angegebenen Position
        /// </summary>
        public EmbedBuilder RemoveField(int index)
        {
            if (index >= 0 && index < fields.Count)
            {
                fields.RemoveAt(index);
            }
            return this;
        }

        /// <summary>
        /// Entfernt alle Fields
        /// </summary>
        public EmbedBuilder ClearFields()
        {
            fields.Clear();
            return this;
        }

        /// <summary>
        /// Erstellt das finale Embed-Dictionary
        /// </summary>
        public Dictionary<string, object> Build()
        {
            var result = new Dictionary<string, object>(embed);

            // Add fields if any exist
            if (fields.Count > 0)
            {
                var fieldsList = new List<object>();
                foreach (var field in fields)
                {
                    fieldsList.Add(new Dictionary<string, object>
                    {
                        ["name"] = field.Name,
                        ["value"] = field.Value,
                        ["inline"] = field.Inline
                    });
                }
                result["fields"] = fieldsList;
            }

            return result;
        }

        /// <summary>
        /// Konvertiert das Embed zu JSON
        /// </summary>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(Build(), Formatting.Indented);
        }

        /// <summary>
        /// Validiert den aktuellen Zustand des Embeds
        /// </summary>
        public void Validate()
        {
            var built = Build();

            // Check if embed has at least title or description
            if (!built.ContainsKey("title") && !built.ContainsKey("description"))
            {
                throw new InvalidOperationException("Embed muss mindestens einen Titel oder eine Beschreibung haben.");
            }

            // Calculate total character count (Discord limit: 6000)
            int totalChars = 0;

            if (built.ContainsKey("title"))
                totalChars += built["title"].ToString().Length;

            if (built.ContainsKey("description"))
                totalChars += built["description"].ToString().Length;

            if (built.ContainsKey("footer") && built["footer"] is Dictionary<string, object> footer)
                totalChars += footer["text"].ToString().Length;

            if (built.ContainsKey("author") && built["author"] is Dictionary<string, object> author)
                totalChars += author["name"].ToString().Length;

            if (built.ContainsKey("fields"))
            {
                foreach (var field in fields)
                {
                    totalChars += field.Name.Length + field.Value.Length;
                }
            }

            if (totalChars > 6000)
            {
                throw new InvalidOperationException($"Embed überschreitet das Zeichenlimit von 6000 Zeichen. Aktuell: {totalChars}");
            }
        }

        /// <summary>
        /// Prüft ob eine URL gültig ist
        /// </summary>
        private bool IsValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri result)
                && (result.Scheme == Uri.UriSchemeHttp || result.Scheme == Uri.UriSchemeHttps);
        }
    }
}