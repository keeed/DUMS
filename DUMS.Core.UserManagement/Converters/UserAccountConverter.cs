using DCO = DUMS.Core.Contract.UserManagement;
using DDO = DUMS.Data.Contract.UserManagement;

namespace DUMS.Core.UserManagement.Converters
{
    /// <summary>
    /// Converter class for handling Core->Data or Data->Core object conversions.
    /// </summary>
    public static class UserAccountConverter
    {
        #region Core to Data Conversion

        #region Methods

        /// <summary>
        /// Converts a Core User Account to a Data User Account.
        /// </summary>
        /// <param name="coreUserAccount">Core User Account to be converted.</param>
        /// <returns>Converted Data User Account.</returns>
        public static DDO.Objects.UserAccount ConvertToDataUserAccount(DCO.Objects.UserAccount coreUserAccount)
        {
            if (coreUserAccount == null)
            {
                return null;
            }

            DDO.Objects.UserAccount dataUserAccount = new DDO.Objects.UserAccount();

            dataUserAccount.UserID = coreUserAccount.UserID;
            dataUserAccount.Username = coreUserAccount.Username;
            dataUserAccount.Password = coreUserAccount.Password;

            dataUserAccount.UserType = convertToDataUserType(coreUserAccount.UserType);

            dataUserAccount.UserInfo = new DDO.Objects.UserInfo();
            if (coreUserAccount.UserInfo != null)
            {
                dataUserAccount.UserInfo.FirstName = coreUserAccount.UserInfo.FirstName;
                dataUserAccount.UserInfo.LastName = coreUserAccount.UserInfo.LastName;
                dataUserAccount.UserInfo.Age = coreUserAccount.UserInfo.Age;
                dataUserAccount.UserInfo.BirthDate = coreUserAccount.UserInfo.BirthDate;
            }

            return dataUserAccount;
        }

        #endregion Methods

        #region Functions

        /// <summary>
        /// Converts Core UserType to Data UserType.
        /// </summary>
        /// <param name="coreUserType">Core UserType to be converted.</param>
        /// <returns>Converted Data UserType.</returns>
        private static DDO.Enums.UserType convertToDataUserType(DCO.Enums.UserType coreUserType)
        {
            switch (coreUserType)
            {
                case DCO.Enums.UserType.Admin:
                    return DDO.Enums.UserType.Admin;

                case DCO.Enums.UserType.Normal:
                    return DDO.Enums.UserType.Normal;
            }

            return DDO.Enums.UserType.Normal;
        }

        #endregion Functions

        #endregion Core to Data Conversion

        #region Data to Core Conversion

        #region Methods

        /// <summary>
        /// Converts Data User Account to Core User Account.
        /// </summary>
        /// <param name="dataUserAccount">Data User Account to be converted.</param>
        /// <returns>Converted Core User Account.</returns>
        public static DCO.Objects.UserAccount ConvertToCoreUserAccount(DDO.Objects.UserAccount dataUserAccount)
        {
            if (dataUserAccount == null)
            {
                return null;
            }

            DCO.Objects.UserAccount coreUserAccount = new DCO.Objects.UserAccount();

            coreUserAccount.UserID = dataUserAccount.UserID;
            coreUserAccount.Username = dataUserAccount.Username;
            coreUserAccount.Password = dataUserAccount.Password;

            coreUserAccount.UserType = convertToCoreUserType(dataUserAccount.UserType);

            coreUserAccount.UserInfo = new Contract.User.UserInfo();
            if (dataUserAccount.UserInfo != null)
            {
                coreUserAccount.UserInfo.FirstName = dataUserAccount.UserInfo.FirstName;
                coreUserAccount.UserInfo.LastName = dataUserAccount.UserInfo.LastName;
                coreUserAccount.UserInfo.Age = dataUserAccount.UserInfo.Age;
                coreUserAccount.UserInfo.BirthDate = dataUserAccount.UserInfo.BirthDate;
            }

            return coreUserAccount;
        }

        #endregion Methods

        #region Functions

        /// <summary>
        /// Converts Data UserType to Core UserType.
        /// </summary>
        /// <param name="dataUserType">Data UserType to be converted.</param>
        /// <returns>Converted Core UserType.</returns>
        private static DCO.Enums.UserType convertToCoreUserType(DDO.Enums.UserType dataUserType)
        {
            switch (dataUserType)
            {
                case DDO.Enums.UserType.Admin:
                    return DCO.Enums.UserType.Admin;

                case DDO.Enums.UserType.Normal:
                    return DCO.Enums.UserType.Normal;
            }

            return DCO.Enums.UserType.Normal;
        }

        #endregion Functions

        #endregion Data to Core Conversion
    }
}