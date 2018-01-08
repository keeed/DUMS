using System;
using DUMS.SharedArchitecture.Logging;
using DUMS.SharedArchitecture.Logging.Enums;

namespace DUMS.Core
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                Core.Instance.Start();
            }
            catch (Exception ex)
            {
                Logger.Log(ex, LogType.Error);
            }

            Logger.Log("[Exit] Application Exit", LogType.Informational);
        }
    }
}