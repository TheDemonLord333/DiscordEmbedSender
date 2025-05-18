using System;
using System.Configuration;

namespace DiscordEmbedSender
{
    public static class AppSettings
    {
        // Discord Bot API Configuration
        public static string BotApiBaseUrl => GetSetting("BotApiBaseUrl", "http://localhost:3000");
        public static int ConnectionTimeout => int.Parse(GetSetting("ConnectionTimeout", "30"));
        public static int MaxRetryAttempts => int.Parse(GetSetting("MaxRetryAttempts", "3"));

        // UI Configuration
        public static string DefaultEmbedColor => GetSetting("DefaultEmbedColor", "#3498db");
        public static bool AutoSavePreferences => bool.Parse(GetSetting("AutoSavePreferences", "true"));
        public static bool ShowPreviewByDefault => bool.Parse(GetSetting("ShowPreviewByDefault", "false"));

        // Validation Settings
        public static int MaxEmbedTitleLength => int.Parse(GetSetting("MaxEmbedTitleLength", "256"));
        public static int MaxEmbedDescriptionLength => int.Parse(GetSetting("MaxEmbedDescriptionLength", "4096"));
        public static int MaxEmbedFooterLength => int.Parse(GetSetting("MaxEmbedFooterLength", "2048"));
        public static int MaxEmbedAuthorLength => int.Parse(GetSetting("MaxEmbedAuthorLength", "256"));
        public static int MaxEmbedFieldNameLength => int.Parse(GetSetting("MaxEmbedFieldNameLength", "256"));
        public static int MaxEmbedFieldValueLength => int.Parse(GetSetting("MaxEmbedFieldValueLength", "1024"));
        public static int MaxEmbedFields => int.Parse(GetSetting("MaxEmbedFields", "25"));
        public static int MaxEmbedTotalLength => int.Parse(GetSetting("MaxEmbedTotalLength", "6000"));

        // Feature Flags
        public static bool EnableAdvancedFeatures => bool.Parse(GetSetting("EnableAdvancedFeatures", "true"));
        public static bool EnableLogging => bool.Parse(GetSetting("EnableLogging", "true"));
        public static string LogLevel => GetSetting("LogLevel", "Information");

        private static string GetSetting(string key, string defaultValue = "")
        {
            try
            {
                return ConfigurationManager.AppSettings[key] ?? defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Updates a setting value in the configuration
        /// </summary>
        public static void UpdateSetting(string key, string value)
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config.AppSettings.Settings[key] != null)
                {
                    config.AppSettings.Settings[key].Value = value;
                }
                else
                {
                    config.AppSettings.Settings.Add(key, value);
                }
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Fehler beim Aktualisieren der Einstellung '{key}': {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Saves the current bot API URL to configuration
        /// </summary>
        public static void SaveBotApiUrl(string url)
        {
            UpdateSetting("BotApiBaseUrl", url);
        }

        /// <summary>
        /// Validates all settings and returns any errors
        /// </summary>
        public static string ValidateSettings()
        {
            try
            {
                // Validate URL format
                if (!Uri.TryCreate(BotApiBaseUrl, UriKind.Absolute, out _))
                {
                    return "Ungültige Bot API URL in den Einstellungen.";
                }

                // Validate positive integers
                if (ConnectionTimeout <= 0)
                    return "Connection Timeout muss größer als 0 sein.";

                if (MaxRetryAttempts < 0)
                    return "Max Retry Attempts darf nicht negativ sein.";

                // Validate Discord limits
                if (MaxEmbedTitleLength > 256)
                    return "Max Embed Title Length darf 256 nicht überschreiten.";

                if (MaxEmbedDescriptionLength > 4096)
                    return "Max Embed Description Length darf 4096 nicht überschreiten.";

                if (MaxEmbedFields > 25)
                    return "Max Embed Fields darf 25 nicht überschreiten.";

                if (MaxEmbedTotalLength > 6000)
                    return "Max Embed Total Length darf 6000 nicht überschreiten.";

                // Validate color format
                var color = DefaultEmbedColor.Replace("#", "");
                if (color.Length != 6 || !int.TryParse(color, System.Globalization.NumberStyles.HexNumber, null, out _))
                {
                    return "Default Embed Color muss ein gültiges Hex-Format haben (#RRGGBB).";
                }

                return null; // All settings are valid
            }
            catch (Exception ex)
            {
                return $"Fehler bei der Validierung der Einstellungen: {ex.Message}";
            }
        }
    }
}