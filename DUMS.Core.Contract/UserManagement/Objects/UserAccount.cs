using System.Runtime.Serialization;
using System.Text;
using DUMS.Core.Contract.User;
using DUMS.Core.Contract.UserManagement.Enums;

namespace DUMS.Core.Contract.UserManagement.Objects
{
    [DataContract]
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        #region Methods

        public override string ToString()
        {
            StringBuilder sbuilder = new StringBuilder();

            sbuilder.Append("[UserID:").Append(UserID).Append("]")
                    .Append("[Username:").Append(Username).Append("]")
                    .Append("[UserType:").Append(UserType.ToString("g")).Append("]")
                    .Append(UserInfo.ToString());

            return sbuilder.ToString();
        }

        #endregion Methods
    }
}