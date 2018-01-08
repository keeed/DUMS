using System.Configuration;
using DUMS.Core.Contract.User;
using DUMS.SharedArchitecture.ComponentManager;
using DUMS.SharedArchitecture.Remoting;

namespace DUMS.Client
{
    public static class ProgramHelper
    {
        #region Methods

        /// <summary>
        /// Loads the User Management Services configured
        /// and registers them to the Component Manager.
        /// </summary>
        public static void RegisterUserManagementServices()
        {
            string serviceUriKey = ConfigurationManager.AppSettings["UserManagementServiceUri"];

            var service = GetService<IUserManagementServices>(serviceUriKey);

            ComponentManager.RegisterComponent<IUserManagementServices>(service);
        }

        #endregion Methods

        #region Functions

        /// <summary>
        /// Gets the given service.
        /// </summary>
        /// <typeparam name="T">Type of the service.</typeparam>
        /// <param name="appSettingServiceUriKey">Service Uri Key in AppConfig.</param>
        /// <returns></returns>
        public static T GetService<T>(string appSettingServiceUriKey) where T : class
        {
            Client<T> client = new Client<T>(appSettingServiceUriKey);

            return client.GetService();
        }

        #endregion Functions
    }
}