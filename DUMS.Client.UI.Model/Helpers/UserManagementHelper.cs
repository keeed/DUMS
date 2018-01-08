using DUMS.Client.UI.Model.Converters;
using DUMS.Core.Contract.UserManagement.Objects.Request;
using DUMS.SharedArchitecture.ComponentManager;
using DCO = DUMS.Core.Contract.UserManagement;
using DCU = DUMS.Client.UI.Contract.UserManagement;

namespace DUMS.Client.UI.Model.Helpers
{
    public class UserManagementHelper
    {
        /// <summary>
        /// Creates a UserManagementRequest object.
        /// Automatically gets the logged-in user account and sets it as the requestor.
        /// </summary>
        /// <param name="userManagementActionType">Action Type of the request.</param>
        /// <param name="userAccountToProcess">User Account to process.</param>
        /// <param name="searchKeyWord">Search Keyword (For Searching).</param>
        /// <param name="userInfoSearchCriteria">Search Criteria (For Searching).</param>
        /// <returns>Populated UserManagement Request.</returns>
        public static DCO.Objects.Request.UserManagementRequest CreateUserManagementRequest(
            DCO.Enums.UserManagementActionType userManagementActionType,
            DCO.Objects.UserAccount userAccountToProcess = null,
            string searchKeyWord = "",
            DCO.Enums.UserInfoSearchCriteriaEnum userInfoSearchCriteria = DCO.Enums.UserInfoSearchCriteriaEnum.FirstName)
        {
            UserManagementRequest request = new UserManagementRequest();

            request.UserManagementActionType = userManagementActionType;
            request.RequestorUserAccount = getCurrentlyLoggedInUserAccount();

            if (userAccountToProcess == null)
            {
                userAccountToProcess = new DCO.Objects.UserAccount();
            }
            request.UserAccountToProcess = userAccountToProcess;

            request.SearchKeyWord = searchKeyWord;
            request.SearchCriteriaEnum = userInfoSearchCriteria;

            return request;
        }

        /// <summary>
        /// Gets the currently logged in user account from the ComponentManager.
        /// </summary>
        /// <returns>Currently logged in user account.</returns>
        private static DCO.Objects.UserAccount getCurrentlyLoggedInUserAccount()
        {
            DCU.Objects.UserAccount clientUserAccount =
                ComponentManager.GetComponent<DCU.Objects.UserAccount>();

            return UserAccountConverter.CovertToCoreUserAccount(clientUserAccount);
        }
    }
}