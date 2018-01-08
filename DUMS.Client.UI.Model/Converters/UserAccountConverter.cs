using DCO = DUMS.Core.Contract.UserManagement;
using DCU = DUMS.Client.UI.Contract.UserManagement;

namespace DUMS.Client.UI.Model.Converters
{
    /// <summary>
    /// Converter class for converting UserAccounts object.
    /// </summary>
    public static class UserAccountConverter
    {
        #region Client to Core Conversion

        #region Methods

        /// <summary>
        /// Converts a Client User Account to Core User Account.
        /// </summary>
        /// <param name="clientUserAccount">Client User Account to be converted.</param>
        /// <returns>Converted Core User Account.</returns>
        public static DCO.Objects.UserAccount CovertToCoreUserAccount
            (DCU.Objects.UserAccount clientUserAccount)
        {
            DCO.Objects.UserAccount coreUserAccount = new DCO.Objects.UserAccount();

            if (clientUserAccount == null)
            {
                return coreUserAccount;
            }

            coreUserAccount.UserID = clientUserAccount.UserID;
            coreUserAccount.Username = clientUserAccount.Username;
            coreUserAccount.Password = clientUserAccount.Password;

            coreUserAccount.UserType = convertToCoreUserType(clientUserAccount.UserType);

            coreUserAccount.UserInfo = new Core.Contract.User.UserInfo();
            if (clientUserAccount.UserInfo != null)
            {
                coreUserAccount.UserInfo.FirstName = clientUserAccount.UserInfo.FirstName;
                coreUserAccount.UserInfo.LastName = clientUserAccount.UserInfo.LastName;
                coreUserAccount.UserInfo.Age = clientUserAccount.UserInfo.Age;
                coreUserAccount.UserInfo.BirthDate = clientUserAccount.UserInfo.BirthDate;
            }

            return coreUserAccount;
        }

        /// <summary>
        /// Converts a Client UserInfoSearchCriteria to Core UserInfoSearchCriteria.
        /// </summary>
        /// <param name="clientUserInfoSearchCriteria">Client UserInfoSearchCriteria to be converted.</param>
        /// <returns>Converted Core UserInfoSearchCriteria.</returns>
        public static DCO.Enums.UserInfoSearchCriteriaEnum ConvertToCoreUserInfoSearchCriteria
            (DCU.Enums.UserInfoSearchCriteria clientUserInfoSearchCriteria)
        {
            switch (clientUserInfoSearchCriteria)
            {
                case DCU.Enums.UserInfoSearchCriteria.FirstName:
                    return DCO.Enums.UserInfoSearchCriteriaEnum.FirstName;

                case DCU.Enums.UserInfoSearchCriteria.LastName:
                    return DCO.Enums.UserInfoSearchCriteriaEnum.LastName;
            }

            return DCO.Enums.UserInfoSearchCriteriaEnum.FirstName;
        }

        #endregion Methods

        #region Functions

        /// <summary>
        /// Converts a Client UserType to a Core UserType.
        /// </summary>
        /// <param name="clientUserType">Client UserType to be converted.</param>
        /// <returns>Converted Core USerType.</returns>
        private static DCO.Enums.UserType convertToCoreUserType(DCU.Enums.UserType clientUserType)
        {
            switch (clientUserType)
            {
                case DCU.Enums.UserType.Admin:
                    return DCO.Enums.UserType.Admin;

                case DCU.Enums.UserType.Normal:
                    return DCO.Enums.UserType.Normal;
            }

            return DCO.Enums.UserType.Normal;
        }

        #endregion Functions

        #endregion Client to Core Conversion

        #region Core to Client Conversion

        #region Methods

        /// <summary>
        /// Converts a Core UserAccount to a Client UserAccount.
        /// </summary>
        /// <param name="coreUserAccount">Core UserAccount to be converted.</param>
        /// <returns>Converted Client UserAccount.</returns>
        public static DCU.Objects.UserAccount CovertToClientUserAccount
            (DCO.Objects.UserAccount coreUserAccount)
        {
            DCU.Objects.UserAccount clientUserAccount = new DCU.Objects.UserAccount();

            if (coreUserAccount == null)
            {
                return clientUserAccount;
            }

            clientUserAccount.UserID = coreUserAccount.UserID;
            clientUserAccount.Username = coreUserAccount.Username;
            clientUserAccount.Password = coreUserAccount.Password;

            clientUserAccount.UserType = convertToClientUserType(coreUserAccount.UserType);

            clientUserAccount.UserInfo = new DCU.Objects.UserInfo();
            if (coreUserAccount.UserInfo != null)
            {
                clientUserAccount.UserInfo.FirstName = coreUserAccount.UserInfo.FirstName;
                clientUserAccount.UserInfo.LastName = coreUserAccount.UserInfo.LastName;
                clientUserAccount.UserInfo.Age = coreUserAccount.UserInfo.Age;
                clientUserAccount.UserInfo.BirthDate = coreUserAccount.UserInfo.BirthDate;
            }

            return clientUserAccount;
        }

        /// <summary>
        /// Converts a Core UserInfoSearchCriteria to a Client UserInfoSearchCriteria.
        /// </summary>
        /// <param name="coreUserInfoSearchCriteria">Core UserInfoSearchCriteria to be converted.</param>
        /// <returns>Converted Client UserInfoSearchCriteria.</returns>
        public static DCU.Enums.UserInfoSearchCriteria ConvertToClientUserInfoSearchCriteria
            (DCO.Enums.UserInfoSearchCriteriaEnum coreUserInfoSearchCriteria)
        {
            switch (coreUserInfoSearchCriteria)
            {
                case DCO.Enums.UserInfoSearchCriteriaEnum.FirstName:
                    return DCU.Enums.UserInfoSearchCriteria.FirstName;

                case DCO.Enums.UserInfoSearchCriteriaEnum.LastName:
                    return DCU.Enums.UserInfoSearchCriteria.LastName;
            }

            return DCU.Enums.UserInfoSearchCriteria.FirstName;
        }

        #endregion Methods

        #region Functions

        /// <summary>
        /// Converts a Core UserType to a Client UserType.
        /// </summary>
        /// <param name="coreUserType">Core UserType to be converted.</param>
        /// <returns>Converted Client UserType.</returns>
        private static DCU.Enums.UserType convertToClientUserType(DCO.Enums.UserType coreUserType)
        {
            switch (coreUserType)
            {
                case DCO.Enums.UserType.Admin:
                    return DCU.Enums.UserType.Admin;

                case DCO.Enums.UserType.Normal:
                    return DCU.Enums.UserType.Normal;
            }

            return DCU.Enums.UserType.Normal;
        }

        #endregion Functions

        #endregion Core to Client Conversion
    }
}