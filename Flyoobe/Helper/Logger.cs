using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Flyoobe
{
    public enum LogLevel
    {
        Info,
        Warning,
        Error
    }

    public static class Logger
    {
        // Event raised when a warning or error is logged
        public static event Action<string, LogLevel> OnNotificationLogged;

        private static readonly List<string> _logBuffer = new List<string>();
        private static readonly string _logFilePath;

        // Static constructor initializes the log file path
        static Logger()
        {
            string exeDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string appDirectory = Path.Combine(exeDirectory, "app");
            _logFilePath = Path.Combine(appDirectory, "log.txt");
        }

        /// <summary>
        /// Logs a message with timestamp and log level.
        /// Also appends the message to the log file.
        /// </summary>
        public static void Log(string message, LogLevel level = LogLevel.Info)
        {
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var levelStr = level.ToString().ToUpper();
            var logLine = $"[{timestamp}] [{levelStr}] {message}";

            _logBuffer.Add(logLine);

            try
            {
                File.AppendAllText(_logFilePath, logLine + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to write to log file: {ex.Message}");
            }

            // Fire event if level is Warning or Error
            if (level == LogLevel.Warning || level == LogLevel.Error)
            {
                OnNotificationLogged?.Invoke(message, level);
            }
        }

        /// <summary>
        /// Returns the full log history stored in memory.
        /// </summary>
        public static string GetLog()
        {
            return string.Join(Environment.NewLine, _logBuffer);
        }
    }
}