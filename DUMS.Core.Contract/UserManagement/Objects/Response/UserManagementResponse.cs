using System.Collections.Generic;
using System.Runtime.Serialization;
using DUMS.Core.Contract.UserManagement.Enums;

namespace DUMS.Core.Contract.UserManagement.Objects.Response
{
    /// <summary>
    /// Response object containg the response from
    /// User Management Services
    /// </summary>
    [DataContract]
    public class UserManagementResponse
    {
        #region Fields

        private UserManagementActionType _userManagementActionType;
        private UserAccount _requestorUserAccount;
        private string _searchKeyWord;
        private UserInfoSearchCriteriaEnum _searchCriteriaEnum;

        private List<UserAccount> _userAccountsRetrieved;
        private bool _isRequestSuccessful;
        private string _responseMessage;
        private string _responseErrorMessage;

        #endregion Fields

        #region Properties

        /// <summary>
        /// The Action Type that was performed.
        /// </summary>
        [DataMember]
        public UserManagementActionType UserManagementActionType
        {
            get { return _userManagementActionType; }
            set { _userManagementActionType = value; }
        }

        /// <summary>
        /// The requestor user account.
        /// </summary>
        [DataMember]
        public UserAccount RequestorUserAccount
        {
            get { return _requestorUserAccount; }
            set { _requestorUserAccount = value; }
        }

        /// <summary>
        /// Search Key word.
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
        /// Search Criteria.
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
        /// Users account retrieved based on the action.
        /// NOTE:
        ///     - All operations that will return a UserAccount will be placed here.
        /// </summary>
        [DataMember]
        public List<UserAccount> UserAccountsRetrieved
        {
            get { return _userAccountsRetrieved; }
            set { _userAccountsRetrieved = value; }
        }

        /// <summary>
        /// Boolean flag to determine if the request was successful.
        /// </summary>
        [DataMember]
        public bool IsRequestSuccessful
        {
            get { return _isRequestSuccessful; }
            set { _isRequestSuccessful = value; }
        }

        /// <summary>
        /// Response message from server.
        /// Populated when the request was successful.
        /// </summary>
        [DataMember]
        public string ResponseMessage
        {
            get { return _responseMessage; }
            set { _responseMessage = value; }
        }

        /// <summary>
        /// Response message from the server.
        /// Populated when the request failed.
        /// </summary>
        [DataMember]
        public string ResponseErrorMessage
        {
            get { return _responseErrorMessage; }
            set { _responseErrorMessage = value; }
        }

        #endregion Properties

        #region Constructor

        public UserManagementResponse()
        {
        }

        #endregion Constructor
    }
}