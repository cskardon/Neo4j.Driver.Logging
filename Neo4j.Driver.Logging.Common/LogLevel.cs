namespace Neo4j.Driver.Logging.Common
{
    /// <summary>
    /// The level to log at. 
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Log all Error messages.
        /// </summary>
        Error,

        /// <summary>
        /// Log all Warning and Error messages.
        /// </summary>
        Warning,

        /// <summary>
        /// Log all Information, Warning and Error messages.
        /// </summary>
        Information,

        /// <summary>
        /// Log all Debug, Information, Warning and Error messages.
        /// </summary>
        Debug,

        /// <summary>
        /// Log all Trace, Debug, Information, Warning and Error messages.
        /// </summary>
        Trace
    }
}