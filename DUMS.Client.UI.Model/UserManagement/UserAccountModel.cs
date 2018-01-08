using System.Collections.Generic;
using DUMS.Client.UI.Contract.UserManagement.Enums;
using DUMS.Client.UI.Contract.UserManagement.Events;
using DUMS.Client.UI.Model.Converters;
using DUMS.Client.UI.Model.Helpers;
using DUMS.Core.Contract.User;
using DUMS.Core.Contract.UserManagement.Enums;
using DUMS.Core.Contract.UserManagement.Objects.Request;
using DUMS.Core.Contract.UserManagement.Objects.Response;
using DUMS.SharedArchitecture.ComponentManager;
using DUMS.SharedArchitecture.EventBus;
using DCO = DUMS.Core.Contract.UserManagement;
using DCU = DUMS.Client.UI.Contract.UserManagement;

namespace DUMS.Client.UI.Model.UserManagement
{
    /// <summary>
    /// User Account Model used for UserAccounts.
    /// </summary>
    public class UserAccountModel
    {
        #region Constructor

        public UserAccountModel()
        {
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Adds a User based on the UserAccount given.
        /// </summary>
        /// <param name="userAccount">User Account to be added.</param>
        public void AddUser(DCU.Objects.UserAccount userAccount)
        {
            // 1.) Get Service.
            IUserManagementServices userManagementServices =
                ComponentManager.GetComponent<IUserManagementServices>();

            // 2.) Create Request.
            UserManagementRequest request = UserManagementHelper.CreateUserManagementRequest(
                UserManagementActionType.AddUser,
                UserAccountConverter.CovertToCoreUserAccount(userAccount));

            // 3.) Send Request.
            UserManagementResponse response =
                userManagementServices.UserManagementHandleRequest(request);

            // 4.) Hanlde Response.
            if (response.IsRequestSuccessful)
            {
                // Broadcast to UserAccountEventArgs that add was successful.
                UpdateUsers(UserAccountActionType.AddUser);
            }
            else
            {
                // Get the logged in user account that was used by the server
                // when handling the request.
                DCU.Objects.UserAccount clientUserAccountLoggedIn =
                    UserAccountConverter.CovertToClientUserAccount(response.RequestorUserAccount);

                UserAccountEventArgs userAccountEventArgs =
                createUserAccountEventArgs(
                    UserAccountActionType.AddUserFailed,
                    null,
                    clientUserAccountLoggedIn,
                    response.ResponseErrorMessage);

                // Broadcast to UserAccountEventArgs that add failed.
                EventBus<UserAccountEventArgs>.Broadcast(
                    this,
                    userAccountEventArgs);
            }
        }

        /// <summary>
        /// Edits a User Account
        /// </summary>
        /// <param name="userAccount">User Account to be edited.</param>
        public void EditUser(DCU.Objects.UserAccount userAccount)
        {
            // 1.) Get Service
            IUserManagementServices userManagementServices =
                ComponentManager.GetComponent<IUserManagementServices>();

            // 2.) Create Request
            UserManagementRequest request = UserManagementHelper.CreateUserManagementRequest(
                UserManagementActionType.EditUser,
                UserAccountConverter.CovertToCoreUserAccount(userAccount));

            // 3.) Send Request
            UserManagementResponse response =
                userManagementServices.UserManagementHandleRequest(request);

            // 4.) Handle Response
            if (response.IsRequestSuccessful)
            {
                // Broadcast to UserAccountEventArgs that add was successful.
                UpdateUsers(UserAccountActionType.EditUser);
            }
            else
            {
                // Get the logged in user account that was used by the server
                // when handling the request.
                DCU.Objects.UserAccount clientUserAccountLoggedIn =
                    UserAccountConverter.CovertToClientUserAccount(response.RequestorUserAccount);

                UserAccountEventArgs userAccountEventArgs =
                createUserAccountEventArgs(
                    UserAccountActionType.EditUserFailed,
                    null,
                    clientUserAccountLoggedIn,
                    response.ResponseErrorMessage);

                // Broadcast to UserAccountEventArgs that add failed.
                EventBus<UserAccountEventArgs>.Broadcast(
                    this,
                    userAccountEventArgs);
            }
        }

        /// <summary>
        /// Deletes a User Account.
        /// </summary>
        /// <param name="userAccount"></param>
        public void DeleteUser(DCU.Objects.UserAccount userAccount)
        {
            // 1.) Get Service
            IUserManagementServices userManagementServices =
                ComponentManager.GetComponent<IUserManagementServices>();

            // 2.) Create Request
            UserManagementRequest request = UserManagementHelper.CreateUserManagementRequest(
                UserManagementActionType.DeleteUser,
                UserAccountConverter.CovertToCoreUserAccount(userAccount));

            // 3.) Send Request
            UserManagementResponse response =
                userManagementServices.UserManagementHandleRequest(request);

            // 4.) Handle Response
            if (response.IsRequestSuccessful)
            {
                // Broadcast to UserAccountEventArgs that add was successful.
                UpdateUsers(UserAccountActionType.DeleteUser);
            }
            else
            {
                // Get the logged in user account that was used by the server
                // when handling the request.
                DCU.Objects.UserAccount clientUserAccountLoggedIn =
                    UserAccountConverter.CovertToClientUserAccount(response.RequestorUserAccount);

                UserAccountEventArgs userAccountEventArgs =
                createUserAccountEventArgs(
                    UserAccountActionType.DeleteUserFailed,
                    null,
                    clientUserAccountLoggedIn,
                    response.ResponseErrorMessage);

                // Broadcast to UserAccountEventArgs that delete failed.
                EventBus<UserAccountEventArgs>.Broadcast(
                    this,
                    userAccountEventArgs);
            }
        }

        /// <summary>
        /// Updates User Accounts
        /// </summary>
        /// <param name="actionType">Action Type</param>
        public void UpdateUsers(
            UserAccountActionType actionType = UserAccountActionType.UpdateUsers)
        {
            // 1.) Get Service
            IUserManagementServices userManagementServices =
                ComponentManager.GetComponent<IUserManagementServices>();


            // 2.) Create Request
            UserManagementRequest request = UserManagementHelper.CreateUserManagementRequest(
                UserManagementActionType.GetUsers);

            // 3.) Send Request
            UserManagementResponse response =
                userManagementServices.UserManagementHandleRequest(request);

            // 4.) Handle Response
            List<DCO.Objects.UserAccount> coreUserAccounts = response.UserAccountsRetrieved;

            List<DCU.Objects.UserAccount> clientUserAccounts = new List<DCU.Objects.UserAccount>();

            foreach (DCO.Objects.UserAccount coreUserAccount in coreUserAccounts)
            {
                clientUserAccounts.Add(UserAccountConverter.CovertToClientUserAccount(coreUserAccount));
            }

            // Get the logged in user account that was used by the server
            // when handling the request.
            DCU.Objects.UserAccount clientUserAccountLoggedIn =
                UserAccountConverter.CovertToClientUserAccount(response.RequestorUserAccount);

            UserAccountEventArgs userAccountEventArgs =
                createUserAccountEventArgs(
                    actionType,
                    clientUserAccounts,
                    clientUserAccountLoggedIn,
                    response.ResponseErrorMessage);

            // Broadcast to UserAccountEventArgs that update users was triggered.
            EventBus<UserAccountEventArgs>.Broadcast(
                this,
                userAccountEventArgs);
        }

        /// <summary>
        /// Unlocks a User Account
        /// </summary>
        /// <param name="userAccount">User Account to be unlocked.</param>
        public void UnlockUser(DCU.Objects.UserAccount userAccount)
        {
            // 1.) Get Service
            IUserManagementServices userManagementServices =
                ComponentManager.GetComponent<IUserManagementServices>();

            // 2.) Create Request
            UserManagementRequest request = UserManagementHelper.CreateUserManagementRequest(
                UserManagementActionType.UnlockUser,
                UserAccountConverter.CovertToCoreUserAccount(userAccount));

            // 3.) Send Request
            UserManagementResponse response =
                userManagementServices.UserManagementHandleRequest(request);

            // 4.) Handle Response
            UserAccountActionType userAccountActionType;
            string message;

            if (response.IsRequestSuccessful)
            {
                userAccountActionType = UserAccountActionType.UnlockUser;
                message = response.ResponseMessage;
            }
            else
            {
                userAccountActionType = UserAccountActionType.UnlockUserFailed;
                message = response.ResponseErrorMessage;
            }

            // Get the logged in user account that was used by the server
            // when handling the request.
            DCU.Objects.UserAccount clientUserAccountLoggedIn =
                UserAccountConverter.CovertToClientUserAccount(response.RequestorUserAccount);

            UserAccountEventArgs userAccountEventArgs =
                createUserAccountEventArgs(
                    userAccountActionType,
                    null,
                    clientUserAccountLoggedIn,
                    message);

            // Broadcast to UserAccountEventARgs that an unlock user was triggered.
            EventBus<UserAccountEventArgs>.Broadcast(
                this,
                userAccountEventArgs);
        }

        /// <summary>
        /// Search for Users
        /// </summary>
        /// <param name="clientSearchCriteria">Search criteria.</param>
        /// <param name="keyWord">Search key word.</param>
        public void SearchUser(
            DCU.Enums.UserInfoSearchCriteria clientSearchCriteria,
            string keyWord)
        {
            // 1.) Get Service
            IUserManagementServices userManagementServices =
                ComponentManager.GetComponent<IUserManagementServices>();

            // 2.) Create Request
            DCO.Enums.UserInfoSearchCriteriaEnum coreSearchCriteria =
                UserAccountConverter.ConvertToCoreUserInfoSearchCriteria(clientSearchCriteria);

            UserManagementRequest request = UserManagementHelper.CreateUserManagementRequest(
                UserManagementActionType.SearchUsers,
                searchKeyWord: keyWord,
                userInfoSearchCriteria: coreSearchCriteria);

            // 3.) Send Request
            UserManagementResponse response =
                userManagementServices.UserManagementHandleRequest(request);


            // 4.) Handle Response
            List<DCO.Objects.UserAccount> coreUserAccounts = response.UserAccountsRetrieved;

            List<DCU.Objects.UserAccount> clientUserAccounts = new List<DCU.Objects.UserAccount>();

            foreach (DCO.Objects.UserAccount coreUserAccount in coreUserAccounts)
            {
                clientUserAccounts.Add(UserAccountConverter.CovertToClientUserAccount(coreUserAccount));
            }

            // Get the logged in user account that was used by the server
            // when handling the request.
            DCU.Objects.UserAccount clientUserAccountLoggedIn =
                UserAccountConverter.CovertToClientUserAccount(response.RequestorUserAccount);

            UserAccountEventArgs userAccountEventArgs =
                createUserAccountEventArgs(
                    UserAccountActionType.SearchUsers,
                    clientUserAccounts,
                    clientUserAccountLoggedIn,
                    response.ResponseErrorMessage);

            // Broadcast to UserAccountEventArgs that a search user was triggered.
            EventBus<UserAccountEventArgs>.Broadcast(
                this,
                userAccountEventArgs);
        }

        #endregion Methods

        #region Functions

        /// <summary>
        /// Creates a UserAccountEventArgs.
        /// </summary>
        /// <param name="userAccountActionType">Action Type</param>
        /// <param name="userAccounts">UserAccounts retrieved.</param>
        /// <param name="userAccountLoggedIn">User account logged in.</param>
        /// <param name="userAccountActionMessage">Message from server.</param>
        /// <returns>Populated UserAccountEventArgs</returns>
        private UserAccountEventArgs createUserAccountEventArgs(
            UserAccountActionType userAccountActionType,
            List<DCU.Objects.UserAccount> userAccounts,
            DCU.Objects.UserAccount userAccountLoggedIn,
            string userAccountActionMessage)
        {
            return new UserAccountEventArgs()
            {
                UserAccountActionType = userAccountActionType,
                UserAccounts = userAccounts,
                UserAccountLoggedIn = userAccountLoggedIn,
                UserAccountActionMessage = userAccountActionMessage
            };
        }

        #endregion Functions
    }
}