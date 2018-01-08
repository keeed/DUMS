using DUMS.Client.UI.Contract.UserManagement.Enums;

namespace DUMS.Client.UI.Contract.UserManagement.Objects
{
    public class UserAccount
    {
        #region Fields

        private long _userID;
        private string _username;
        private string _password;
        private UserInfo _userInfo;
        private UserType _userType;

        #endregion Fields

        #region Properties

        public long UserID
        {
            get
            {
                return _userID;
            }
            set
            {
                _userID = value;
            }
        }

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        public UserInfo UserInfo
        {
            get
            {
                return _userInfo;
            }
            set
            {
                _userInfo = value;
            }
        }

        public UserType UserType
        {
            get
            {
                return _userType;
            }
            set
            {
                _userType = value;
            }
        }

        #endregion Properties

        #region Constructor

        public UserAccount()
        {
        }

        #endregion Constructor
    }
}