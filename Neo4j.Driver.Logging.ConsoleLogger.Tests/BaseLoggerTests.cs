namespace Neo4j.Driver.Logging.ConsoleLogger.Tests
{
    using FluentAssertions;
    using Neo4j.Driver.Logging.Common;
    using Xunit;

    public class BaseLoggerTests
    {
        public class IsDebugEnabledMethod
        {
            [Fact]
            public void ReturnsTrue_WhenLogLevelIsDebug()
            {
                var logger = new ConsoleLogger(LogLevel.Debug);
                logger.IsDebugEnabled().Should().BeTrue();
            }

            [Fact]
            public void ReturnsTrue_WhenLogLevelIsTrace()
            {
                var logger = new ConsoleLogger(LogLevel.Trace);
                logger.IsDebugEnabled().Should().BeTrue();
            }

            [Fact]
            public void ReturnsFalse_WhenLogLevelIsInformation()
            {
                var logger = new ConsoleLogger(LogLevel.Information);
                logger.IsDebugEnabled().Should().BeFalse();
            }

            [Fact]
            public void ReturnsFalse_WhenLogLevelIsWarning()
            {
                var logger = new ConsoleLogger();
                logger.IsDebugEnabled().Should().BeFalse();
            }

            [Fact]
            public void ReturnsFalse_WhenLogLevelIsError()
            {
                var logger = new ConsoleLogger(LogLevel.Error);
                logger.IsDebugEnabled().Should().BeFalse();
            }
        }

        public class IsTraceEnabledMethod
        {
            [Fact]
            public void ReturnsTrue_WhenLogLevelIsDebug()
            {
                var logger = new ConsoleLogger(LogLevel.Debug);
                logger.IsTraceEnabled().Should().BeFalse();
            }

            [Fact]
            public void ReturnsTrue_WhenLogLevelIsTrace()
            {
                var logger = new ConsoleLogger(LogLevel.Trace);
                logger.IsTraceEnabled().Should().BeTrue();
            }

            [Fact]
            public void ReturnsFalse_WhenLogLevelIsInformation()
            {
                var logger = new ConsoleLogger(LogLevel.Information);
                logger.IsTraceEnabled().Should().BeFalse();
            }

            [Fact]
            public void ReturnsFalse_WhenLogLevelIsWarning()
            {
                var logger = new ConsoleLogger();
                logger.IsTraceEnabled().Should().BeFalse();
            }

            [Fact]
            public void ReturnsFalse_WhenLogLevelIsError()
            {
                var logger = new ConsoleLogger(LogLevel.Error);
                logger.IsTraceEnabled().Should().BeFalse();
            }
        }


    }
}