using System;
using System.Configuration;
using DUMS.SharedArchitecture.Logging;
using DUMS.SharedArchitecture.Logging.Enums;
using DUMS.SharedArchitecture.Remoting;

namespace DUMS.Core
{
    public class Core
    {
        #region Fields

        private static Core _coreInstance = new Core();
        private static Server _server;

        #endregion Fields

        #region Properties

        public static Core Instance
        {
            get
            {
                return _coreInstance;
            }
        }

        #endregion Properties

        #region Constructor

        private Core()
        {
        }

        #endregion Constructor

        #region Methods

        public void Start()
        {
            Logger.Log("[Startup] Loading Configuration",
                            LogType.Informational);

            string serviceUri = ConfigurationManager.AppSettings["UserManagementServiceUri"];
            string serviceName = ConfigurationManager.AppSettings["UserManagementServiceName"];

            string serviceInterfaceName = ConfigurationManager.AppSettings["UserManagementServiceInterface"];
            string serviceProviderName = ConfigurationManager.AppSettings["UserManagementServiceProvider"];

            var serviceInterface = Type.GetType(serviceInterfaceName);
            var serviceProvider = Type.GetType(serviceProviderName);

            Logger.Log("[Startup] Initializing Services",
                            LogType.Informational);

            _server = new Server(serviceUri, serviceName);
            _server.Start(serviceInterface, serviceProvider);

            Logger.Log("[Startup] Server Started",
                            LogType.Informational);

            Console.WriteLine("Server Started, press [ENTER] key to exit...");
            Console.ReadLine();

            Stop();

            Logger.Log("[Terminating] Server Stopped",
                            LogType.Informational);
        }

        public void Stop()
        {
            _server.Stop();
        }

        #endregion Methods

        #region Functions

        private void initalizeDataSource()
        {
        }

        #endregion Functions
    }
}