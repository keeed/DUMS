using DUMS.Client.UI.Contract.Login.Enums;
using DUMS.Client.UI.Contract.Login.Events;
using DUMS.Client.UI.Model.Converters;
using DUMS.Client.UI.Model.Helpers;
using DUMS.Core.Contract.User;
using DUMS.Core.Contract.UserManagement.Objects.Request;
using DUMS.Core.Contract.UserManagement.Objects.Response;
using DUMS.SharedArchitecture.ComponentManager;
using DUMS.SharedArchitecture.EventBus;
using DCO = DUMS.Core.Contract.UserManagement;
using DCU = DUMS.Client.UI.Contract.UserManagement;

namespace DUMS.Client.UI.Model.Login
{
    /// <summary>
    /// Model used for Login.
    /// </summary>
    public class LoginModel
    {
        #region Constructor

        public LoginModel()
        {
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Performs a login request to UserManagementServices.
        /// </summary>
        /// <param name="userAccount">UserAccount to login.</param>
        public void Login(DCU.Objects.UserAccount userAccount)
        {
            // 1.) Get Service
            IUserManagementServices userManagementServices =
                ComponentManager.GetComponent<IUserManagementServices>();

            // 2.) Populate and Create Request.
            DCO.Objects.UserAccount coreUserAccount = new DCO.Objects.UserAccount();
            coreUserAccount.Username = userAccount.Username;
            coreUserAccount.Password = userAccount.Password;

            UserManagementRequest request = UserManagementHelper.CreateUserManagementRequest(
                DCO.Enums.UserManagementActionType.Login,
                coreUserAccount);

            // 3.) Send Request
            UserManagementResponse response = userManagementServices.UserManagementHandleRequest
                (request);

            // 4.) Handle Response
            DCU.Objects.UserAccount userAccountLoggedIn = new DCU.Objects.UserAccount();

            if (response.UserAccountsRetrieved.Count > 0)
            {
                userAccountLoggedIn = UserAccountConverter.CovertToClientUserAccount(response.UserAccountsRetrieved[0]);
            }

            UserLoginEventArgs userLoginEventArg;

            if (response.IsRequestSuccessful)
            {
                ComponentManager.RegisterComponent<DCU.Objects.UserAccount>(userAccountLoggedIn);

                userLoginEventArg = createUserLoginEventArg(
                    LoginResultType.Success,
                    response.ResponseMessage);
            }
            else
            {
                userLoginEventArg = createUserLoginEventArg(
                    LoginResultType.Failed,
                    response.ResponseErrorMessage);
            }

            // 5.) Broadcast via the EventBus.
            EventBus<UserLoginEventArgs>.Broadcast(this, userLoginEventArg);
        }

        #endregion Methods

        #region Functions

        /// <summary>
        /// Creates a UserLoginEventArg
        /// </summary>
        /// <param name="loginResultType">LoginResult type.</param>
        /// <param name="message">Message from server.</param>
        /// <returns>Populated UserLoginEventArg</returns>
        private UserLoginEventArgs createUserLoginEventArg(
            LoginResultType loginResultType,
            string message)
        {
            UserLoginEventArgs userLoginEventHandler = new UserLoginEventArgs()
            {
                LoginResultType = loginResultType,
                Message = message
            };

            return userLoginEventHandler;
        }

        #endregion Functions
    }
}