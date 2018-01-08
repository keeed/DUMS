using System.Collections.Generic;
using DUMS.Client.UI.Contract.UserManagement.Enums;
using DUMS.Client.UI.Contract.UserManagement.Objects;

namespace DUMS.Client.UI.Contract.UserManagement
{
    public interface IUserAccountView
    {
        /// <summary>
        /// Perform operation based on the UserAccountActionType.
        /// </summary>
        /// <param name="userAccountActionType">Action that was done.</param>
        /// <param name="userAccounts">List of all UserAccounts after the Action was completed.</param>
        /// <param name="userAccountLoggedIn">Logged in User Account.</param>
        /// <param name="messageFromServer">Message from server.</param>
        void UserAccountAction(
            UserAccountActionType userAccountActionType,
            List<UserAccount> userAccounts,
            UserAccount userAccountLoggedIn,
            string messageFromServer);
    }
}