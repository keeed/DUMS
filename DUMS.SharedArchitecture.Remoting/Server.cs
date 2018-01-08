using System;
using System.ServiceModel;

namespace DUMS.SharedArchitecture.Remoting
{
    /// <summary>
    /// Provides an easy-way of creating a Wcf Server.
    /// </summary>
    public class Server
    {
        #region Fields

        private string _serviceUri;
        private string _serviceName;
        private ServiceHost _serviceHost;

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

        public string ServiceName
        {
            get
            {
                return _serviceName;
            }
            set
            {
                _serviceName = value;
            }
        }

        public ServiceHost ServiceHost
        {
            get
            {
                return _serviceHost;
            }
            set
            {
                _serviceHost = value;
            }
        }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="serviceUri">Service Uri for the Service.</param>
        /// <param name="serviceName">Service Name for the Service.</param>
        public Server(string serviceUri, string serviceName)
        {
            _serviceUri = serviceUri;
            _serviceName = serviceName;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Starts a Service.
        /// </summary>
        /// <param name="serviceInterface">Interface Class of the Service.</param>
        /// <param name="serviceProvider">Class that implements the Interface.</param>
        public void Start(Type serviceInterface, Type serviceProvider)
        {
            if (_serviceHost != null &&
               (_serviceHost.State != CommunicationState.Opened ||
                _serviceHost.State != CommunicationState.Opening))
            {
                return;
            }

            NetTcpBinding binding = new NetTcpBinding();

            Uri serviceUri = new Uri(_serviceUri);
            _serviceHost = new ServiceHost(serviceProvider, serviceUri);
            _serviceHost.AddServiceEndpoint(serviceInterface, binding, _serviceName);

            _serviceHost.Open();
        }

        /// <summary>
        /// Stops the Service.
        /// </summary>
        public void Stop()
        {
            if (_serviceHost.State != CommunicationState.Closed ||
                 _serviceHost.State != CommunicationState.Closing)
            {
                _serviceHost.Close();
            }
        }

        #endregion Methods
    }
}