using System;
using System.Configuration;
using DUMS.Data.Contract.DataProvider;

namespace DUMS.Core.UserManagement.DataHandler
{
    /// <summary>
    /// Helper class for handling the data provider.
    /// </summary>
    public static class DataProviderHelper
    {
        #region Fields

        private static object _dataProviderInstance;
        private static string _dataProviderConnectionString;

        #endregion Fields

        #region Properties

        public static object DataProviderInstance
        {
            get
            {
                if (_dataProviderInstance == null)
                {
                    _dataProviderInstance = getDataProviderInstance();
                }
                return _dataProviderInstance;
            }
        }

        public static string DataProviderConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_dataProviderConnectionString))
                {
                    _dataProviderConnectionString = getDataProviderConnectionString();
                }
                return _dataProviderConnectionString;
            }
        }

        #endregion Properties

        #region Functions

        /// <summary>
        /// Gets the data provider instance configured in App.config.
        /// </summary>
        /// <returns>The data provider instance.</returns>
        private static object getDataProviderInstance()
        {
            string dataProviderType = ConfigurationManager.AppSettings["DataProvider"];

            Type type = Type.GetType(dataProviderType, false);

            object dataProviderInstance = null;

            if (typeof(IDataProvider).IsAssignableFrom(type))
            {
                dataProviderInstance = Activator.CreateInstance(type);
            }

            return dataProviderInstance;
        }

        /// <summary>
        /// Gets the connection string to be used by the data provider.
        /// </summary>
        /// <returns>Connection string,</returns>
        private static string getDataProviderConnectionString()
        {
            string dataProviderConnectionString = ConfigurationManager.AppSettings["DataProviderConnectionString"];

            return dataProviderConnectionString;
        }

        #endregion Functions
    }
}