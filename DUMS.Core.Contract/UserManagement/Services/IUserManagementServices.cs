using System.ServiceModel;
using DUMS.Core.Contract.UserManagement.Objects.Request;
using DUMS.Core.Contract.UserManagement.Objects.Response;

namespace DUMS.Core.Contract.User
{
    /// <summary>
    /// Service Contract used when implementing User Management Services
    /// </summary>
    [ServiceContract]
    public interface IUserManagementServices
    {
        #region User Management Methods

        /// <summary>
        /// Performs the request in the request object received.
        /// </summary>
        /// <param name="request">Request object.</param>
        /// <returns>Result of the request.</returns>
        [OperationContract]
        UserManagementResponse UserManagementHandleRequest(UserManagementRequest request);

        #endregion User Management Methods
    }
}