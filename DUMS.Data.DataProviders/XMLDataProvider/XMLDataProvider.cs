using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUMS.Data.Contract.DataProvider;
using DUMS.Data.Contract.UserManagement.Enums;
using DUMS.Data.Contract.UserManagement.Objects;
using DUMS.Data.Contract.UserManagement.Services;
using DUMS.Data.DataProviders.XMLDataProvider.Utilities;

namespace DUMS.Data.DataProviders.XMLDataProvider
{
    public class XMLDataProvider : IUserManagementDataServices
    {
        #region Fields
        private XMLHandler _xmlHandler;
        private static List<UserAccount> _userAccounts = new List<UserAccount>();
        #endregion

        #region Properties
        public XMLHandler XMLHandler
        {
            get
            {
                if (_xmlHandler == null)
                {
                    _xmlHandler = new XMLHandler();
                }
                return _xmlHandler;
            }
            set
            {
                _xmlHandler = value;
            }
        }
        #endregion

        #region Constructor
        #endregion

        #region Methods

        #region Implementation of IDataProvider

        public bool Connect(string connectionString)
        {
            _userAccounts = XMLHandler.LoadUserAccountsFromXml(connectionString);

            return true;
        }

        #endregion

        #region Implementation of IUserManagementDataService

        public bool AddUser(UserAccount userAccount)
        {
            userAccount.UserID = _userAccounts.Last().UserID + 1;

            _userAccounts.Add(userAccount);

            XMLHandler.SaveXml(_userAccounts);
            return true;
        }

        public bool DeleteUser(UserAccount userAccount)
        {
            UserAccount oldUserAccount = GetUserById(userAccount.UserID);

            bool isDeleteSuccessful = _userAccounts.Remove(oldUserAccount);

            if (isDeleteSuccessful)
            {
                XMLHandler.SaveXml(_userAccounts);
                return true;
            }

            return false;
        }

        public bool EditUser(UserAccount userAccount)
        {
            UserAccount oldUserAccount = GetUserById(userAccount.UserID);

            if (oldUserAccount == null)
            {
                return false;
            }

            oldUserAccount.Username = userAccount.Username;
            oldUserAccount.Password = userAccount.Password;
            oldUserAccount.UserType = userAccount.UserType;
            oldUserAccount.FailedAttempts = userAccount.FailedAttempts;

            oldUserAccount.UserInfo = userAccount.UserInfo;

            XMLHandler.SaveXml(_userAccounts);

            return true;
        }

        public UserAccount GetUserById(long id)
        {
            return _userAccounts.Find(u => u.UserID == id);
        }

        public UserAccount GetUserByUsername(string username)
        {
            return _userAccounts.Find(u => u.Username == username);
        }

        public List<UserAccount> GetUsers()
        {
            return _userAccounts;
        }

        public List<UserAccount> GetUsersByFirstName(string firstName)
        {
            List<UserAccount> retrievedUserAccounts = new List<UserAccount>();

            retrievedUserAccounts = _userAccounts.Where
                (u => u.UserInfo.FirstName.IndexOf(firstName, StringComparison.CurrentCultureIgnoreCase) != -1)
                .ToList();

            return retrievedUserAccounts;

        }

        public List<UserAccount> GetUsersByLastName(string lastName)
        {
            List<UserAccount> retrievedUserAccounts = new List<UserAccount>();

            retrievedUserAccounts = _userAccounts.Where
                (u => u.UserInfo.LastName.IndexOf(lastName, StringComparison.CurrentCultureIgnoreCase) != -1)
                .ToList();

            return retrievedUserAccounts;
        }

        public UserType GetUserType(long userID)
        {
            return GetUserById(userID).UserType;
        }


        public int GetNumberOfFailedAttempts(long userID)
        {
            return GetUserById(userID).FailedAttempts;
        }


        public bool SetNumberOfFailedAttempts(long userID, int numberOfFailedAttempts)
        {
            UserAccount userAccount = GetUserById(userID);

            if (userAccount == null)
            {
                return false;
            }

            userAccount.FailedAttempts = numberOfFailedAttempts;

            return true;
        }

        #endregion

        #endregion

        #region Functions
        #endregion
    }
}
