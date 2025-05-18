namespace DiscordEmbedSender
{
    // Discord Server Model
    public class Guild
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int MemberCount { get; set; }

        public override string ToString()
        {
            return $"{Name} ({MemberCount} Mitglieder)";
        }
    }

    // Discord Channel Model
    public class Channel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }

        public override string ToString()
        {
            return $"#{Name}";
        }
    }

    // Discord User Model
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Avatar { get; set; }

        public override string ToString()
        {
            return string.IsNullOrEmpty(DisplayName) ? Username : $"{DisplayName} ({Username})";
        }
    }

    // Embed Field Model
    public class EmbedField
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public bool Inline { get; set; }

        public EmbedField(string name, string value, bool inline = false)
        {
            Name = name;
            Value = value;
            Inline = inline;
        }
    }

    // Color Helper Class
    public static class EmbedColors
    {
        public static readonly string Default = "#3498db";
        public static readonly string Success = "#2ecc71";
        public static readonly string Warning = "#f39c12";
        public static readonly string Error = "#e74c3c";
        public static readonly string Info = "#3498db";
        public static readonly string Purple = "#9b59b6";
        public static readonly string Green = "#2ecc71";
        public static readonly string Blue = "#3498db";
        public static readonly string Red = "#e74c3c";
        public static readonly string Orange = "#f39c12";
        public static readonly string Yellow = "#f1c40f";
        public static readonly string Pink = "#e91e63";
        public static readonly string Cyan = "#1abc9c";
        public static readonly string DiscordBlurple = "#5865F2";
        public static readonly string DiscordGreen = "#57F287";
        public static readonly string DiscordYellow = "#FEE75C";
        public static readonly string DiscordRed = "#ED4245";

        public static string[] GetPredefinedColors()
        {
            return new[]
            {
                Default,
                Success,
                Warning,
                Error,
                Info,
                Purple,
                Green,
                Blue,
                Red,
                Orange,
                Yellow,
                Pink,
                Cyan,
                DiscordBlurple,
                DiscordGreen,
                DiscordYellow,
                DiscordRed
            };
        }

        public static string GetColorName(string hexColor)
        {
            switch (hexColor.ToUpper())
            {
                case "#3498DB": return "Blau (Standard)";
                case "#2ECC71": return "Grün (Erfolg)";
                case "#F39C12": return "Orange (Warnung)";
                case "#E74C3C": return "Rot (Fehler)";
                case "#9B59B6": return "Lila";
                case "#F1C40F": return "Gelb";
                case "#E91E63": return "Pink";
                case "#1ABC9C": return "Türkis";
                case "#5865F2": return "Discord Blurple";
                case "#57F287": return "Discord Grün";
                case "#FEE75C": return "Discord Gelb";
                case "#ED4245": return "Discord Rot";
                default: return hexColor;
            }
        }
    }
}