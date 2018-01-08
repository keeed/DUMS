using System;
using DUMS.SharedArchitecture.Logging.Enums;
using DUMS.SharedArchitecture.Logging.Strategies;

namespace DUMS.SharedArchitecture.Logging
{
    /// <summary>
    /// Implements a Logger functionality that can be configured
    /// by changing the ILoggerStrategy used.
    /// </summary>
    public class Logger
    {
        #region Fields

        private static ILoggerStrategy _loggerStrategy = new TextFileLogStrategy();

        #endregion Fields

        #region Properties

        public static ILoggerStrategy LoggerStrategy
        {
            get
            {
                return _loggerStrategy;
            }
            set
            {
                _loggerStrategy = value;
            }
        }

        #endregion Properties

        #region Constructor

        private Logger()
        {
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Logs a message.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="logType">LogType to be used.</param>
        public static void Log(string message, LogType logType)
        {
            _loggerStrategy.Log(message, logType);
        }

        /// <summary>
        /// Logs an exception.
        /// </summary>
        /// <param name="ex">Exception to be logged.</param>
        /// <param name="logType">LogType to be used.</param>
        public static void Log(Exception ex, LogType logType)
        {
            _loggerStrategy.Log(ex, logType);
        }

        #endregion Methods
    }
}