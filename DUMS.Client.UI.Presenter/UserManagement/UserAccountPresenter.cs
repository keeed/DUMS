using System;
using System.Collections.Generic;
using DUMS.Client.UI.Contract.Events;
using DUMS.Client.UI.Contract.UserManagement;
using DUMS.Client.UI.Contract.UserManagement.Enums;
using DUMS.Client.UI.Contract.UserManagement.Events;
using DUMS.Client.UI.Contract.UserManagement.Objects;
using DUMS.Client.UI.Model.UserManagement;
using DUMS.SharedArchitecture.EventBus;

namespace DUMS.Client.UI.Presenter.UserManagement
{
    /// <summary>
    /// User Account Presenter
    /// </summary>
    public class UserAccountPresenter : PresenterBase, IEventListener
    {
        #region Fields

        private UserAccountModel _userAccountModel;

        #endregion Fields



        #region Constructor

        public UserAccountPresenter() :
            base()
        {
            _userAccountModel = new UserAccountModel();

            RegisterToEventBus();
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Updates Users
        /// </summary>
        public void UpdateUsers()
        {
            _userAccountModel.UpdateUsers();
        }

        /// <summary>
        /// Adds a User Account
        /// </summary>
        /// <param name="userAccount">User Account to be added.</param>
        public void AddUser(UserAccount userAccount)
        {
            _userAccountModel.AddUser(userAccount);
        }

        /// <summary>
        /// Edits a User Account
        /// </summary>
        /// <param name="userAccount">User Account to be edited.</param>
        public void EditUser(UserAccount userAccount)
        {
            _userAccountModel.EditUser(userAccount);
        }

        /// <summary>
        /// Unlocks a User Account.
        /// </summary>
        /// <param name="userAccount">User Account to be unlocked.</param>
        public void UnlockUser(UserAccount userAccount)
        {
            _userAccountModel.UnlockUser(userAccount);
        }

        /// <summary>
        /// Deletes a User Account.
        /// </summary>
        /// <param name="userAccount">User Account to be deleted.</param>
        public void DeleteUser(UserAccount userAccount)
        {
            _userAccountModel.DeleteUser(userAccount);
        }

        /// <summary>
        /// Search for User Accounts
        /// </summary>
        /// <param name="searchCriteria">Search Criteria.</param>
        /// <param name="keyWord">Search key word.</param>
        public void SearchUser(UserInfoSearchCriteria searchCriteria, string keyWord)
        {
            _userAccountModel.SearchUser(searchCriteria, keyWord);
        }

        /// <summary>
        /// Register to the EventBus
        /// </summary>
        public override void RegisterToEventBus()
        {
            EventBus<UserAccountEventArgs>.Subscribe += this.HandleEvent;
        }

        #region Implementation of IEventListener

        /// <summary>
        /// Handle EventArg
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">EventArgs object</param>
        public override void HandleEvent(object sender, EventArgs e)
        {
            if (e is UserAccountEventArgs)
            {
                handleUserAccountEventArgs(e as UserAccountEventArgs);
            }
        }

        #endregion Implementation of IEventListener

        #endregion Methods

        #region Functions

        /// <summary>
        /// Handles the UserAccountEventArgs received.
        /// </summary>
        /// <param name="userAccountEventArgs">User Account Event Args</param>
        public void handleUserAccountEventArgs(UserAccountEventArgs userAccountEventArgs)
        {
            IEnumerable<IUserAccountView> views = new List<IUserAccountView>();
            switch (userAccountEventArgs.UserAccountActionType)
            {
                case UserAccountActionType.UpdateUsers:
                case UserAccountActionType.AddUser:
                case UserAccountActionType.AddUserFailed:
                case UserAccountActionType.EditUser:
                case UserAccountActionType.EditUserFailed:
                case UserAccountActionType.UnlockUser:
                case UserAccountActionType.UnlockUserFailed:
                case UserAccountActionType.DeleteUser:
                case UserAccountActionType.DeleteUserFailed:
                case UserAccountActionType.SearchUsers:
                    views = GetViews<IUserAccountView>();
                    break;
            }

            foreach (IUserAccountView view in views)
            {
                view.UserAccountAction
                    (userAccountEventArgs.UserAccountActionType,
                    userAccountEventArgs.UserAccounts,
                    userAccountEventArgs.UserAccountLoggedIn,
                    userAccountEventArgs.UserAccountActionMessage);
            }
        }

        #endregion Functions
    }
}