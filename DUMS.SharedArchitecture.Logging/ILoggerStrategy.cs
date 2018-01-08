using System;
using DUMS.SharedArchitecture.Logging.Enums;

namespace DUMS.SharedArchitecture.Logging
{
    /// <summary>
    /// Interface implementation for a logger strategy.
    /// </summary>
    public interface ILoggerStrategy
    {
        /// <summary>
        /// Logs a log entry.
        /// </summary>
        /// <param name="message">Message of log entry.</param>
        /// <param name="logType">Log Type of the log entry.</param>
        void Log(string message, LogType logType);

        /// <summary>
        /// Logs an exception.
        /// </summary>
        /// <param name="ex">Exception to Log.</param>
        /// <param name="logType">Log Type of the log entry.</param>
        void Log(Exception ex, LogType logType);
    }
}