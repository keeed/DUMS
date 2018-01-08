using System;
using System.Collections.Generic;
using System.Text;
using DUMS.Core.Contract.User;
using DUMS.Core.Contract.UserManagement.Enums;
using DUMS.Core.Contract.UserManagement.Objects;
using DUMS.Core.Contract.UserManagement.Objects.Request;
using DUMS.Core.Contract.UserManagement.Objects.Response;
using DUMS.Core.UserManagement.Converters;
using DUMS.Core.UserManagement.DataHandler;
using DUMS.Core.UserManagement.Helpers;
using DUMS.Data.Contract.DataProvider;
using DUMS.Data.Contract.UserManagement.Services;
using DUMS.SharedArchitecture.ComponentManager;
using DUMS.SharedArchitecture.Logging;
using DUMS.SharedArchitecture.Logging.Enums;

using DCO = DUMS.Core.Contract.UserManagement.Objects;

using DDO = DUMS.Data.Contract.UserManagement.Objects;

namespace DUMS.Core.UserManagement
{
    /// <summary>
    /// Implementation of IUserManagementServices
    /// Implements core functionalities of DUMS
    /// </summary>
    public class UserManagementServices : MarshalByRefObject, IUserManagementServices
    {
        #region Constructor

        public UserManagementServices()
        {
            initializeComponents();

            verifyAndUpdateUserAccounts();
        }

        #endregion Constructor

        #region Implementation of IUserManagementServices

        /// <summary>
        /// Handles the request object based on the Action Type.
        /// </summary>
        /// <param name="request">Request object to be processed.</param>
        /// <returns>Response object with the results from the request.</returns>
        public UserManagementResponse UserManagementHandleRequest(UserManagementRequest request)
        {
            // 1.) Create container for response object.
            UserManagementResponse response = createResponseObject(request);

            try
            {
                // Based on the Action Type, select what action to perform.
                switch (request.UserManagementActionType)
                {
                    case UserManagementActionType.AddUser:
                        response = addUser(request, response);
                        break;

                    case UserManagementActionType.DeleteUser:
                        response = deleteUser(request, response);
                        break;

                    case UserManagementActionType.EditUser:
                        response = editUser(request, response);
                        break;

                    case UserManagementActionType.GetUsers:
                        response = getUsers(request, response);
                        break;

                    case UserManagementActionType.SearchUsers:
                        response = searchUsersByName(request, response);
                        break;

                    case UserManagementActionType.Login:
                        response = login(request, response);
                        break;

                    case UserManagementActionType.UnlockUser:
                        response = unlock(request, response);
                        break;
                }
            }
            // Unknown exception occured.
            catch (Exception e)
            {
                Logger.Log(e,
                    LogType.Error);
            }

            return response;
        }

        #endregion Implementation of IUserManagementServices

        #region Functions

        /// <summary>
        /// Adds a User.
        /// </summary>
        /// <param name="request">Request object.</param>
        /// <param name="response">Response object.</param>
        /// <returns>Populated Response object.</returns>
        public UserManagementResponse addUser(
            UserManagementRequest request,
            UserManagementResponse response)
        {
            IUserManagementDataServices userManagementDataServices = getUserManagementDataServices();

            // Check if Username already exists
            DDO.UserAccount dataUserAccount =
                userManagementDataServices.GetUserByUsername(request.UserAccountToProcess.Username);

            if (dataUserAccount != null)
            {
                var coreUserAccount = UserAccountConverter.ConvertToCoreUserAccount(dataUserAccount);

                if (coreUserAccount.Username == request.UserAccountToProcess.Username &&
                    coreUserAccount.UserID != request.UserAccountToProcess.UserID)
                {
                    Logger.Log("[Add User Failed] Username already exists.",
                    LogType.Warning);

                    response.IsRequestSuccessful = false;
                    response.ResponseErrorMessage = "Username already taken. Username should be unique. ";

                    return response;
                }
            }

            // Process Age
            request.UserAccountToProcess.UserInfo.Age =
                UserManagementHelper.CalculateAge(request.UserAccountToProcess.UserInfo.BirthDate);

            // Check Username given.
            if (string.IsNullOrEmpty(request.UserAccountToProcess.Username))
            {
                Logger.Log("[Add User Failed] Empty Username",
                    LogType.Warning);

                response.IsRequestSuccessful = false;
                response.ResponseErrorMessage = "Username should not be empty. ";

                return response;
            }

            // Check Name given.
            if (!ValidationHelper.CheckIfNameIsValid(request.UserAccountToProcess.UserInfo.FirstName) ||
                !ValidationHelper.CheckIfNameIsValid(request.UserAccountToProcess.UserInfo.LastName))
            {
                Logger.Log("[Add User Failed] Invalid Names",
                    LogType.Warning);

                response.IsRequestSuccessful = false;
                response.ResponseErrorMessage = "Names should only be composed of letter, spaces, and should not be empty. ";

                return response;
            }

            dataUserAccount =
                UserAccountConverter.ConvertToDataUserAccount(request.UserAccountToProcess);

            response.IsRequestSuccessful = userManagementDataServices.AddUser(dataUserAccount);

            if (response.IsRequestSuccessful)
            {
                Logger.Log("[Add User Successful] " + request.UserAccountToProcess.ToString(),
                    LogType.Informational);
            }
            else
            {
                Logger.Log("[Add User Failed]",
                    LogType.Warning);

                response.ResponseErrorMessage = "Problem encountered when adding a user.\n\nNOTE: Duplicate Usernames are not allowed.";
            }

            return response;
        }

        /// <summary>
        /// Deletes a User.
        /// </summary>
        /// <param name="request">Request object.</param>
        /// <param name="response">Response object.</param>
        /// <returns>Populated Response object.</returns>
        public UserManagementResponse deleteUser(
            UserManagementRequest request,
            UserManagementResponse response)
        {
            IUserManagementDataServices userManagementDataServices = getUserManagementDataServices();

            if (request.RequestorUserAccount.UserID == request.UserAccountToProcess.UserID)
            {
                response.IsRequestSuccessful = false;
                response.ResponseErrorMessage = "The currently logged in user cannot delete itself.";
                return response;
            }

            DDO.UserAccount dataUserAccount = UserAccountConverter.ConvertToDataUserAccount(request.UserAccountToProcess);

            response.IsRequestSuccessful = userManagementDataServices.DeleteUser(dataUserAccount);

            if (response.IsRequestSuccessful)
            {
                Logger.Log("[Delete User Successful] " + request.UserAccountToProcess.ToString(),
                    LogType.Informational);
            }
            else
            {
                Logger.Log("[Delete User Failed]",
                    LogType.Warning);
                response.ResponseErrorMessage = "Problem encountered when deleting a user.";
            }

            return response;
        }

        /// <summary>
        /// Edits a User.
        /// </summary>
        /// <param name="request">Request object.</param>
        /// <param name="response">Response object.</param>
        /// <returns>Populated Response object.</returns>
        public UserManagementResponse editUser(
            UserManagementRequest request,
            UserManagementResponse response)
        {
            IUserManagementDataServices userManagementDataServices = getUserManagementDataServices();

            if (request.RequestorUserAccount.UserID == request.UserAccountToProcess.UserID)
            {
                response.IsRequestSuccessful = false;
                response.ResponseErrorMessage = "The currently logged in user cannot edit itself.";
                return response;
            }

            // Check Username given.
            if (string.IsNullOrEmpty(request.UserAccountToProcess.Username))
            {
                Logger.Log("[Edit User Failed] Empty Username",
                    LogType.Warning);

                response.IsRequestSuccessful = false;
                response.ResponseErrorMessage = "Username should not be empty. ";

                return response;
            }

            // Check if Username already exists
            DDO.UserAccount dataUserAccount =
                userManagementDataServices.GetUserByUsername(request.UserAccountToProcess.Username);

            if (dataUserAccount != null)
            {
                var coreUserAccount = UserAccountConverter.ConvertToCoreUserAccount(dataUserAccount);

                if (coreUserAccount.Username == request.UserAccountToProcess.Username &&
                    coreUserAccount.UserID != request.UserAccountToProcess.UserID)
                {
                    Logger.Log("[Edit User Failed] Username already exists.",
                    LogType.Warning);

                    response.IsRequestSuccessful = false;
                    response.ResponseErrorMessage = "Username already taken. Username should be unique. ";

                    return response;
                }
            }


            // Check Name given.
            if (!ValidationHelper.CheckIfNameIsValid(request.UserAccountToProcess.UserInfo.FirstName) ||
                !ValidationHelper.CheckIfNameIsValid(request.UserAccountToProcess.UserInfo.LastName))
            {
                Logger.Log("[Edit User Failed] Invalid Names",
                    LogType.Warning);

                response.IsRequestSuccessful = false;
                response.ResponseErrorMessage = "Names should only be composed of letter, spaces, and should not be empty. ";

                return response;
            }

            request.UserAccountToProcess.UserInfo.Age =
                UserManagementHelper.CalculateAge(request.UserAccountToProcess.UserInfo.BirthDate);

            dataUserAccount = UserAccountConverter.ConvertToDataUserAccount(request.UserAccountToProcess);

            response.IsRequestSuccessful = userManagementDataServices.EditUser(dataUserAccount);

            if (response.IsRequestSuccessful)
            {
                Logger.Log("[Edit User Successful] " + request.UserAccountToProcess.ToString(),
                    LogType.Informational);
            }
            else
            {
                Logger.Log("[Edit User Failed]",
                    LogType.Warning);
                response.ResponseErrorMessage = "Problem encountered while editing a user.";
            }

            return response;
        }

        /// <summary>
        /// Gets all the Users.
        /// </summary>
        /// <param name="request">Request object.</param>
        /// <param name="response">Response object.</param>
        /// <returns>Populated response object.</returns>
        public UserManagementResponse getUsers(
            UserManagementRequest request,
            UserManagementResponse response)
        {
            IUserManagementDataServices userManagementDataServices = getUserManagementDataServices();

            List<DDO.UserAccount> dataUserAccounts = userManagementDataServices.GetUsers();

            List<DCO.UserAccount> coreUserAccounts = new List<UserAccount>();

            foreach (DDO.UserAccount dataUserAccount in dataUserAccounts)
            {
                coreUserAccounts.Add(UserAccountConverter.ConvertToCoreUserAccount(dataUserAccount));
            }

            response.UserAccountsRetrieved = coreUserAccounts;

            Logger.Log("[Get Users Success] Total User Accounts Retrieved: " + coreUserAccounts.Count,
                    LogType.Informational);

            return response;
        }

        /// <summary>
        /// Search users.
        /// </summary>
        /// <param name="request">Request object.</param>
        /// <param name="response">Response object.</param>
        /// <returns>Populated Response object.</returns>
        public UserManagementResponse searchUsersByName(
            UserManagementRequest request,
            UserManagementResponse response)
        {
            IUserManagementDataServices userManagementDataServices = getUserManagementDataServices();

            List<DDO.UserAccount> dataUserAccounts = new List<DDO.UserAccount>();

            List<DCO.UserAccount> coreUserAccounts = new List<UserAccount>();

            switch (request.SearchCriteriaEnum)
            {
                case UserInfoSearchCriteriaEnum.FirstName:
                    dataUserAccounts = userManagementDataServices.GetUsersByFirstName(request.SearchKeyWord);
                    break;

                case UserInfoSearchCriteriaEnum.LastName:
                    dataUserAccounts = userManagementDataServices.GetUsersByLastName(request.SearchKeyWord);
                    break;
            }

            foreach (DDO.UserAccount dataUserAccount in dataUserAccounts)
            {
                coreUserAccounts.Add(UserAccountConverter.ConvertToCoreUserAccount(dataUserAccount));
            }

            response.UserAccountsRetrieved = coreUserAccounts;
            response.IsRequestSuccessful = true;

            StringBuilder sbuilder = new StringBuilder();

            sbuilder.Append("[Search Users Success] [Keyword:").Append(request.SearchKeyWord).Append("]")
                    .Append("[Criteria:").Append(request.SearchCriteriaEnum.ToString("g")).Append("]")
                    .Append("[ResultCount:").Append(coreUserAccounts.Count).Append("]");

            Logger.Log(sbuilder.ToString(),
                    LogType.Informational);

            return response;
        }

        /// <summary>
        /// Attempt to Login a user account.
        /// </summary>
        /// <param name="request">Request object to login.</param>
        /// <param name="response">Response object to populate with details.</param>
        /// <returns>Response object with details about login.</returns>
        public DCO.Response.UserManagementResponse login(
            UserManagementRequest request,
            UserManagementResponse response)
        {
            IUserManagementDataServices userManagementDataServices = getUserManagementDataServices();

            DDO.UserAccount retrievedDataUserAccount =
                userManagementDataServices.GetUserByUsername(request.UserAccountToProcess.Username);

            DCO.UserAccount retrievedCoreUserAccount =
                UserAccountConverter.ConvertToCoreUserAccount(retrievedDataUserAccount);

            // Check if a user is found.
            if (retrievedCoreUserAccount != null)
            {
                // Check if the passwords match.
                if (retrievedCoreUserAccount.Password == request.UserAccountToProcess.Password)
                {
                    if (retrievedDataUserAccount.FailedAttempts >= 3)
                    {
                        response.IsRequestSuccessful = false;
                        response.ResponseErrorMessage = "User is currently locked out. Please contact an administrator.";

                        Logger.Log("[Locked Account] " + retrievedCoreUserAccount.ToString(),
                            LogType.Warning);
                    }
                    else
                    {
                        retrievedDataUserAccount.FailedAttempts = 0;
                        userManagementDataServices.EditUser(retrievedDataUserAccount);

                        response.UserAccountsRetrieved.Add(retrievedCoreUserAccount);
                        response.IsRequestSuccessful = true;

                        Logger.Log("[Login Successful] " + retrievedCoreUserAccount.ToString(),
                            LogType.Informational);
                    }
                }
                // User found but password given was incorrect.
                // Increase failed attempts.
                else
                {
                    // If failed attempts is less than 3,
                    // add counters to failed attempts.
                    if (retrievedDataUserAccount.FailedAttempts < 3)
                    {
                        retrievedDataUserAccount.FailedAttempts += 1;
                        userManagementDataServices.EditUser(retrievedDataUserAccount);

                        if (retrievedDataUserAccount.FailedAttempts == 3)
                        {
                            Logger.Log("[Locking Account] " + retrievedCoreUserAccount.ToString(),
                            LogType.Warning);
                        }
                    }
                }
            }

            return response;
        }

        /// <summary>
        /// Unlocks a User.
        /// </summary>
        /// <param name="request">Request object.</param>
        /// <param name="response">Response object.</param>
        /// <returns>Populated Response object.</returns>
        private UserManagementResponse unlock(
            UserManagementRequest request,
            UserManagementResponse response)
        {
            IUserManagementDataServices userManagementDataServices = getUserManagementDataServices();

            DDO.UserAccount retrievedDataUserAccount =
                userManagementDataServices.GetUserById(request.UserAccountToProcess.UserID);

            retrievedDataUserAccount.FailedAttempts = 0;

            userManagementDataServices.EditUser(retrievedDataUserAccount);

            response.IsRequestSuccessful = true;
            response.ResponseMessage = "User unlocked successfully.";

            Logger.Log("[Unlocked Account] " + request.UserAccountToProcess.ToString(),
                            LogType.Informational);

            return response;
        }

        /// <summary>
        /// Initalizes required components.
        /// </summary>
        private void initializeComponents()
        {
            bool isInitalizationSuccessful = true;

            try
            {
                // Register IDataProvider Component
                ComponentManager.RegisterComponent<IDataProvider>(
                    DataProviderHelper.DataProviderInstance);

                ComponentManager.GetComponent<IDataProvider>().Connect(DataProviderHelper.DataProviderConnectionString);
            }
            catch (Exception ex)
            {
                isInitalizationSuccessful = false;

                Logger.Log(ex, LogType.Error);
                Logger.Log("[Service Failed to Initialize] Application will now exit.",
                            LogType.Informational);

            }

            if (!isInitalizationSuccessful)
            {
                // Terminate server since it cannot connect to the data source.B
                Environment.Exit(1);
            }
        }

        /// <summary>
        /// Verifies and update UserAccounts retrieved from Data Provider.
        /// </summary>
        private void verifyAndUpdateUserAccounts()
        {
            // 1.) Get Services
            IUserManagementDataServices userManagementDataServices = getUserManagementDataServices();

            // 2.) Get Users
            List<DDO.UserAccount> dataUserAccounts = userManagementDataServices.GetUsers();

            // 3.) Validate and Verify Data
            List<DCO.UserAccount> coreUserAccounts = new List<UserAccount>();

            foreach (DDO.UserAccount dataUserAccount in dataUserAccounts)
            {
                coreUserAccounts.Add(UserAccountConverter.ConvertToCoreUserAccount(dataUserAccount));
            }

            foreach (DCO.UserAccount coreUserAccount in coreUserAccounts)
            {
                if (coreUserAccount.UserID == null)
                {
                    Logger.Log("[Data Error] A UserID is invalid. Terminating Applciation.",
                            LogType.Error);

                    Environment.Exit(1);
                }

                if (string.IsNullOrEmpty(coreUserAccount.Username))
                {
                    Logger.Log("[Data Error] A Username is invalid. Terminating Applciation.",
                            LogType.Error);

                    Environment.Exit(1);

                }
                else
                {
                    if (coreUserAccounts.FindAll(u => u.Username == coreUserAccount.Username).Count > 1)
                    {
                        Logger.Log("[Data Error] A duplicate UserID is found. Terminating Applciation.",
                            LogType.Error);

                        Environment.Exit(1);
                    }   
                }

                if (string.IsNullOrEmpty(coreUserAccount.Password))
                {
                    Logger.Log("[Data Error] A Password is invalid. Terminating Applciation.",
                            LogType.Error);

                    Environment.Exit(1);
                }

                if (coreUserAccount.UserInfo == null)
                {
                    Logger.Log("[Data Error] A UserInfo is invalid. Terminating Applciation.",
                            LogType.Error);

                    Environment.Exit(1);
                }

                if (!ValidationHelper.CheckIfNameIsValid(coreUserAccount.UserInfo.FirstName))
                {
                    Logger.Log("[Data Error] A First Name is invalid. Terminating Applciation.",
                            LogType.Error);

                    Environment.Exit(1);
                }

                if (!ValidationHelper.CheckIfNameIsValid(coreUserAccount.UserInfo.LastName))
                {
                    Logger.Log("[Data Error] A Last Name is invalid. Terminating Applciation.",
                            LogType.Error);

                    Environment.Exit(1);
                }

                if (coreUserAccount.UserInfo.BirthDate > DateTime.Now)
                {
                    Logger.Log("[Data Error] A BirthDate is invalid. Terminating Applciation.",
                            LogType.Error);

                    Environment.Exit(1);
                }

                coreUserAccount.UserInfo.Age =
                    UserManagementHelper.CalculateAge(coreUserAccount.UserInfo.BirthDate);
            }

            // 4.) Update Data 
            dataUserAccounts = new List<DDO.UserAccount>();

            foreach (DCO.UserAccount coreUserAccount in coreUserAccounts)
            {
                userManagementDataServices.EditUser(UserAccountConverter.ConvertToDataUserAccount(coreUserAccount));
            }   

        }

        /// <summary>
        /// Retrieves the data services.
        /// </summary>
        /// <returns></returns>
        private IUserManagementDataServices getUserManagementDataServices()
        {
            return ComponentManager.GetComponent<IUserManagementDataServices>();
        }

        /// <summary>
        /// Creates the Response object.
        /// </summary>
        /// <param name="request">Request object to copy other values from.</param>
        /// <returns>Populated Response object.</returns>
        private DCO.Response.UserManagementResponse createResponseObject(
            DCO.Request.UserManagementRequest request)
        {
            DCO.Response.UserManagementResponse response = new DCO.Response.UserManagementResponse();

            response.RequestorUserAccount = request.RequestorUserAccount;
            response.UserManagementActionType = request.UserManagementActionType;
            response.UserAccountsRetrieved = new List<UserAccount>();

            response.SearchKeyWord = request.SearchKeyWord;
            response.SearchCriteriaEnum = request.SearchCriteriaEnum;

            return response;
        }

        #endregion Functions
    }
}