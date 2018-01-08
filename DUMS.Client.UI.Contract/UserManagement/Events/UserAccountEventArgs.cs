using System;
using System.Collections.Generic;
using DUMS.Client.UI.Contract.UserManagement.Enums;
using DUMS.Client.UI.Contract.UserManagement.Objects;

namespace DUMS.Client.UI.Contract.UserManagement.Events
{
    public class UserAccountEventArgs : EventArgs
    {
        #region Fields

        private UserAccount _userAccountLoggedIn;
        private List<UserAccount> _userAccounts;
        private UserAccountActionType _userAccountActionType;
        private string _userAccountActionMessage;

        #endregion Fields

        #region Properties

        public UserAccount UserAccountLoggedIn
        {
            get
            {
                return _userAccountLoggedIn;
            }
            set
            {
                _userAccountLoggedIn = value;
            }
        }

        public List<UserAccount> UserAccounts
        {
            get
            {
                return _userAccounts;
            }
            set
            {
                _userAccounts = value;
            }
        }

        public UserAccountActionType UserAccountActionType
        {
            get
            {
                return _userAccountActionType;
            }
            set
            {
                _userAccountActionType = value;
            }
        }

        public string UserAccountActionMessage
        {
            get
            {
                return _userAccountActionMessage;
            }
            set
            {
                _userAccountActionMessage = value;
            }
        }

        #endregion Properties

        #region Constructor

        public UserAccountEventArgs()
        {
        }

        #endregion Constructor
    }
}