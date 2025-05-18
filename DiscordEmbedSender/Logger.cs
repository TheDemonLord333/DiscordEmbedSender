using System;
using System.IO;
using System.Text;

namespace DiscordEmbedSender
{
    public static class Logger
    {
        private static readonly string LogDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
        private static readonly string LogFile = Path.Combine(LogDirectory, $"DiscordEmbedSender_{DateTime.Now:yyyy-MM-dd}.log");
        private static readonly object lockObject = new object();

        static Logger()
        {
            // Create logs directory if it doesn't exist
            if (!Directory.Exists(LogDirectory))
            {
                Directory.CreateDirectory(LogDirectory);
            }

            // Clean up old log files (keep only last 30 days)
            CleanUpOldLogs();
        }

        public enum LogLevel
        {
            Debug = 0,
            Information = 1,
            Warning = 2,
            Error = 3,
            Critical = 4
        }

        public static void Debug(string message, Exception exception = null)
        {
            Log(LogLevel.Debug, message, exception);
        }

        public static void Info(string message, Exception exception = null)
        {
            Log(LogLevel.Information, message, exception);
        }

        public static void Warning(string message, Exception exception = null)
        {
            Log(LogLevel.Warning, message, exception);
        }

        public static void Error(string message, Exception exception = null)
        {
            Log(LogLevel.Error, message, exception);
        }

        public static void Critical(string message, Exception exception = null)
        {
            Log(LogLevel.Critical, message, exception);
        }

        private static void Log(LogLevel level, string message, Exception exception = null)
        {
            if (!AppSettings.EnableLogging)
                return;

            // Check if log level meets minimum requirement
            if (!Enum.TryParse(AppSettings.LogLevel, out LogLevel minLevel))
                minLevel = LogLevel.Information;

            if (level < minLevel)
                return;

            lock (lockObject)
            {
                try
                {
                    var logEntry = new StringBuilder();
                    logEntry.AppendLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] [{level.ToString().ToUpper()}] {message}");

                    if (exception != null)
                    {
                        logEntry.AppendLine($"Exception: {exception.GetType().Name}: {exception.Message}");
                        logEntry.AppendLine($"StackTrace: {exception.StackTrace}");

                        // Log inner exceptions
                        var innerEx = exception.InnerException;
                        while (innerEx != null)
                        {
                            logEntry.AppendLine($"Inner Exception: {innerEx.GetType().Name}: {innerEx.Message}");
                            logEntry.AppendLine($"Inner StackTrace: {innerEx.StackTrace}");
                            innerEx = innerEx.InnerException;
                        }
                    }

                    logEntry.AppendLine(new string('-', 80));

                    File.AppendAllText(LogFile, logEntry.ToString(), Encoding.UTF8);
                }
                catch
                {
                    // Ignore logging errors to prevent infinite loops
                }
            }
        }

        private static void CleanUpOldLogs()
        {
            try
            {
                var cutoffDate = DateTime.Now.AddDays(-30);
                var logFiles = Directory.GetFiles(LogDirectory, "DiscordEmbedSender_*.log");

                foreach (var logFile in logFiles)
                {
                    var fileInfo = new FileInfo(logFile);
                    if (fileInfo.CreationTime < cutoffDate)
                    {
                        File.Delete(logFile);
                    }
                }
            }
            catch
            {
                // Ignore cleanup errors
            }
        }

        public static void LogApplicationStart()
        {
            Info("=== Discord Embed Sender Application Started ===");
            Info($"Version: {System.Reflection.Assembly.GetEntryAssembly()?.GetName().Version}");
            Info($"OS: {Environment.OSVersion}");
            Info($".NET Version: {Environment.Version}");
            Info($"Working Directory: {Environment.CurrentDirectory}");
            Info($"Bot API URL: {AppSettings.BotApiBaseUrl}");

            var validationError = AppSettings.ValidateSettings();
            if (!string.IsNullOrEmpty(validationError))
            {
                Warning($"Configuration validation warning: {validationError}");
            }
        }

        public static void LogApplicationEnd()
        {
            Info("=== Discord Embed Sender Application Ended ===");
        }

        public static void LogEmbedSent(string targetType, string targetId, bool success)
        {
            if (success)
            {
                Info($"Embed successfully sent - Type: {targetType}, Target: {targetId}");
            }
            else
            {
                Warning($"Failed to send embed - Type: {targetType}, Target: {targetId}");
            }
        }

        public static void LogApiCall(string endpoint, bool success, TimeSpan duration)
        {
            if (success)
            {
                Debug($"API call successful - Endpoint: {endpoint}, Duration: {duration.TotalMilliseconds}ms");
            }
            else
            {
                Warning($"API call failed - Endpoint: {endpoint}, Duration: {duration.TotalMilliseconds}ms");
            }
        }

        public static void LogUserAction(string action, string details = null)
        {
            var message = $"User Action: {action}";
            if (!string.IsNullOrEmpty(details))
            {
                message += $" - {details}";
            }
            Info(message);
        }

        /// <summary>
        /// Gets the path to the current log file
        /// </summary>
        public static string GetCurrentLogFile()
        {
            return LogFile;
        }

        /// <summary>
        /// Opens the log directory in Windows Explorer
        /// </summary>
        public static void OpenLogDirectory()
        {
            try
            {
                System.Diagnostics.Process.Start("explorer.exe", LogDirectory);
            }
            catch (Exception ex)
            {
                Error("Failed to open log directory", ex);
            }
        }
    }
}