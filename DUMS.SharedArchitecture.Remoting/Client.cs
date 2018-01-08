using System;
using System.ServiceModel;

namespace DUMS.SharedArchitecture.Remoting
{
    /// <summary>
    /// Connects to a given Service Uri
    /// given a Service (T).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Client<T>
        where T : class
    {
        #region Fields

        private string _serviceUri;

        #endregion Fields

        #region Properties

        public string ServiceUri
        {
            get
            {
                return _serviceUri;
            }
            set
            {
                _serviceUri = value;
            }
        }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="serviceUri">Service Directory Uri for the Service (T).</param>
        public Client(string serviceUri)
        {
            _serviceUri = serviceUri;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Gets the Service (T).
        /// </summary>
        /// <returns>The Service (T).</returns>
        public T GetService()
        {
            NetTcpBinding binding = new NetTcpBinding();
            binding.SendTimeout = TimeSpan.MaxValue;

            ChannelFactory<T> factory = new ChannelFactory<T>(
                binding,
                new EndpointAddress(_serviceUri));

            T proxy = factory.CreateChannel();

            return proxy;
        }

        #endregion Methods
    }
}