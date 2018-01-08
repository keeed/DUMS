using System;
using System.IO;
using System.Text;

namespace DUMS.SharedArchitecture.Logging.Strategies
{
    /// <summary>
    /// Basic Logging Strategy that uses text files.
    /// </summary>
    public class TextFileLogStrategy : ILoggerStrategy
    {
        #region Fields

        private string _logPath;
        private string _fileName;
        private string _fullPath;

        #endregion Fields

        #region Constructor

        public TextFileLogStrategy()
        {
            _logPath = "Results\\";
            _fileName = DateTime.Now.ToString("MM-dd-yyyy") + ".txt";
            _fullPath = _logPath + _fileName;
        }

        #endregion Constructor

        #region Methods

        #region Implementation of ILoggerStrategy

        /// <summary>
        /// Logs a given message.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="logType">LogType to be used.</param>
        public void Log(string message, Enums.LogType logType)
        {
            prepareFile();
            using (StreamWriter sw = File.AppendText(_fullPath))
            {
                sw.WriteLine(
                    createLogEntry(message, logType));
            }
        }

        /// <summary>
        /// Logs a given exception.
        /// </summary>
        /// <param name="ex">Exception to be logged.</param>
        /// <param name="logType">LogType to be used.</param>
        public void Log(Exception ex, Enums.LogType logType)
        {
            prepareFile();
            using (StreamWriter sw = File.AppendText(_fullPath))
            {
                sw.WriteLine(
                    createLogEntry(ex, logType));
            }
        }

        #endregion Implementation of ILoggerStrategy

        #endregion Methods

        #region Functions

        /// <summary>
        /// Prepares the file to be used for logging.
        /// </summary>
        private void prepareFile()
        {
            if (!Directory.Exists(_logPath))
            {
                Directory.CreateDirectory(_logPath);
            }
            if (!File.Exists(_fullPath))
            {
                using (StreamWriter writer = File.CreateText(_fullPath))
                {
                }
            }
        }

        /// <summary>
        /// Creates a log entry from a string.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="logType">LogType to be used.</param>
        /// <returns>The log entry.</returns>
        private string createLogEntry(string message, Enums.LogType logType)
        {
            StringBuilder sbuilder = new StringBuilder();

            sbuilder.Append("[")
                    .Append(DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss.fff tt"))
                    .Append("]")
                    .Append("[")
                    .Append(logType.ToString("g"))
                    .Append("]")
                    .Append(" ")
                    .Append(message);

            return sbuilder.ToString();
        }

        /// <summary>
        /// Creates a log entry from an exception.
        /// </summary>
        /// <param name="ex">Exception to be logged.</param>
        /// <param name="logType">LogType to be used.</param>
        /// <returns>The log entry.</returns>
        private string createLogEntry(Exception ex, Enums.LogType logType)
        {
            StringBuilder sbuilder = new StringBuilder();

            sbuilder.Append("[")
                    .Append(DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss.fff tt"))
                    .Append("]")
                    .Append("[")
                    .Append(logType.ToString("g"))
                    .Append("]")
                    .Append(" ")
                    .Append(ex.GetType().ToString())
                    .Append(" - ")
                    .Append(ex.Message)
                    .Append(" - ")
                    .Append(ex.StackTrace);

            return sbuilder.ToString();
        }

        #endregion Functions
    }
}