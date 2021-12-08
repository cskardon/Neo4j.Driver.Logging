namespace Neo4j.Driver.Logging.ConsoleLogger
{
    using System;
    using Neo4j.Driver.Logging.Common;

    /// <summary>
    /// Logs messages from the <see cref="Neo4j.Driver"/> to the Console.
    /// </summary>
    public class ConsoleLogger : BaseLogger
    {
        /// <summary>
        /// Create a new instance of a the <see cref="ConsoleLogger"/>.
        /// </summary>
        /// <param name="logLevel">Set this to choose the starting level to log at. Default is <see cref="LogLevel.Warning"/>.</param>
        public ConsoleLogger(LogLevel logLevel = LogLevel.Warning)
            : base(logLevel)
        {
        }

        /// <inheritdoc cref="ILogger.Debug"/>
        public override void Debug(string message, params object[] args)
        {
            WriteToConsole($"{DebugPrefix}: {message}", args);
        }

        /// <inheritdoc cref="ILogger.Error"/>
        public override void Error(Exception cause, string message, params object[] args)
        {
            WriteToConsole($"{ErrorPrefix}: {message}{Environment.NewLine}{cause}", args);
        }

        /// <inheritdoc cref="ILogger.Info"/>
        public override void Info(string message, params object[] args)
        {
            WriteToConsole($"{InfoPrefix}: {message}", args);
        }

        /// <inheritdoc cref="ILogger.Trace"/>
        public override void Trace(string message, params object[] args)
        {
            WriteToConsole($"{TracePrefix}: {message}", args);
        }

        /// <inheritdoc cref="ILogger.Warn"/>
        public override void Warn(Exception cause, string message, params object[] args)
        {
            WriteToConsole($"{WarningPrefix}: {message}{Environment.NewLine}{cause}", args);
        }

        private static void WriteToConsole(string message, params object[] args)
        {
            Console.WriteLine(Format(message, args));
        }
    }
}