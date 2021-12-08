namespace Neo4j.Driver.Logging.Common
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using Neo4j.Driver;

    /// <summary>
    /// A base class implementing some common useful methods but agnostic in <em>where</em> it logs.
    /// </summary>
    public abstract class BaseLogger : ILogger
    {
        /// <summary>
        /// Create a new instance of a the <see cref="BaseLogger"/>.
        /// </summary>
        /// <param name="logLevel">Set this to choose the starting level to log at. Default is <see cref="LogLevel.Warning"/>.</param>
        protected BaseLogger(LogLevel logLevel = LogLevel.Warning)
        {
            LogLevel = logLevel;
        }

        /// <summary>
        /// Gets or sets the text that will be put before a 'Debug' level message. The default is <c>DEBUG</c>.
        /// </summary>
        public static string DebugPrefix { get; set; } = "DEBUG";

        /// <summary>
        /// Gets or sets the text that will be put before an 'Error' level message. The default is <c>ERROR</c>.
        /// </summary>
        public static string ErrorPrefix { get; set; } = "ERROR";

        /// <summary>
        /// Gets or sets the text that will be put before an 'Information' level message. The default is <c>INFO</c>.
        /// </summary>
        public static string InfoPrefix { get; set; } = "INFO";

        /// <summary>
        /// Gets or sets the text that will be put before a 'Warning' level message. The default is <c>WARNING</c>.
        /// </summary>
        public static string WarningPrefix { get; set; } = "WARNING";

        /// <summary>
        /// Gets or sets the text that will be put before a 'Trace' level message. The default is <c>TRACE</c>.
        /// </summary>
        public static string TracePrefix { get; set; } = "TRACE";

        /// <summary>
        /// Gets or sets the <see cref="LogLevel"/> the logger will log at.
        /// </summary>
        public LogLevel LogLevel { get; set; }

        /// <inheritdoc cref="ILogger.Error"/>
        public abstract void Error(Exception cause, string message, params object[] args);

        /// <inheritdoc cref="ILogger.Warn"/>
        public abstract void Warn(Exception cause, string message, params object[] args);

        /// <inheritdoc cref="ILogger.Info"/>
        public abstract void Info(string message, params object[] args);

        /// <inheritdoc cref="ILogger.Debug"/>
        public abstract void Debug(string message, params object[] args);

        /// <inheritdoc cref="ILogger.Trace"/>
        public abstract void Trace(string message, params object[] args);

        /// <inheritdoc cref="ILogger.IsDebugEnabled"/>
        public bool IsDebugEnabled()
        {
            return LogLevel >= LogLevel.Debug;
        }

        /// <inheritdoc cref="ILogger.IsTraceEnabled"/>
        public bool IsTraceEnabled()
        {
            return LogLevel >= LogLevel.Trace;
        }

        /// <summary>
        /// Attempts to format a message into human readable text (in the case of a BOLT message)
        /// </summary>
        /// <param name="message">The message to format</param>
        /// <param name="others">Other parts to the message, this could be parameters etc.</param>
        /// <returns>A <see cref="string"/> formatted in a human readable way.</returns>
        protected static string Format(string message, params object[] others)
        {
            if (message == null || !message.Any()) return string.Empty;
            var othersList = others.ToList();
            othersList.Insert(0, message);

            return string.Join(Environment.NewLine, othersList.Select(Format));
        }

        private static string Format(object obj)
        {
            if (obj == null) return string.Empty;
            if (obj is string)
            {
                var output = obj.ToString();
                if (output != null && (output.EndsWith("00 00") || output.EndsWith("00 03")))
                    return FormatByteArray(output);
                
                return output;
            }

            if (obj is IEnumerable enumerable)
                return string.Join(",", enumerable.Cast<object>().Select(o => o == null ? string.Empty : o.ToString()));

            return obj.ToString();
        }

        private static string FormatByteArray(string input)
        {
            var hex = string.Join("", input.Split(' ', StringSplitOptions.RemoveEmptyEntries));
            var bytes = StringToByteArray(hex);
            return Encoding.UTF8.GetString(bytes);
        }

        private static byte[] StringToByteArray(string hex)
        {
            var NumberChars = hex.Length;
            var bytes = new byte[NumberChars / 2];
            for (var i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
    }
}