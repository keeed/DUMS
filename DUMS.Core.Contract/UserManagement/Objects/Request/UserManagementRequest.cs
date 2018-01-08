using System.Runtime.Serialization;
using DUMS.Core.Contract.UserManagement.Enums;

namespace DUMS.Core.Contract.UserManagement.Objects.Request
{
    /// <summary>
    /// Request Object used when requesting for a
    /// User Management Services action.
    /// </summary>
    [DataContract]
    public class UserManagementRequest
    {
        #region Fields

        private UserManagementActionType _userManagementActionType;
        private UserAccount _requestorUserAccount;
        private UserAccount _userAccountToProcess;
        private string _searchKeyWord;
        private UserInfoSearchCriteriaEnum _searchCriteriaEnum;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Action Type to be performed.
        /// NOTE:
        ///     - Required all the time.
        /// </summary>
        [DataMember]
        public UserManagementActionType UserManagementActionType
        {
            get { return _userManagementActionType; }
            set { _userManagementActionType = value; }
        }

        /// <summary>
        /// User Account of the logged in user.
        /// NOTE:
        ///     - Required all the time.
        ///     - User info during login will be retrieved from this property.
        /// </summary>
        [DataMember]
        public UserAccount RequestorUserAccount
        {
            get { return _requestorUserAccount; }
            set { _requestorUserAccount = value; }
        }

        /// <summary>
        /// Search Key Word used for searching.
        /// NOTE:
        ///     - Required only when searching.
        /// </summary>
        [DataMember]
        public string SearchKeyWord
        {
            get { return _searchKeyWord; }
            set { _searchKeyWord = value; }
        }

        /// <summary>
        /// Search Criteria used for searching.
        /// NOTE:
        ///     - Required only when searching.
        /// </summary>
        [DataMember]
        public UserInfoSearchCriteriaEnum SearchCriteriaEnum
        {
            get { return _searchCriteriaEnum; }
            set { _searchCriteriaEnum = value; }
        }

        /// <summary>
        /// User Account to be processed.
        /// NOTE:
        ///     - Required for Add User
        ///     - Required for Edit User
        ///     - Required for Unlock User
        ///     - Required for Delete User
        /// </summary>
        [DataMember]
        public UserAccount UserAccountToProcess
        {
            get { return _userAccountToProcess; }
            set { _userAccountToProcess = value; }
        }

        #endregion Properties

        #region Constructor

        public UserManagementRequest()
        {
        }

        #endregion Constructor
    }
}