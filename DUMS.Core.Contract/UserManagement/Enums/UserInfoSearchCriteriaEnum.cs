using System.Runtime.Serialization;

namespace DUMS.Core.Contract.UserManagement.Enums
{
    /// <summary>
    /// Enum Used to indicate what property of UserInfo should we do the search.
    /// </summary>
    [DataContract]
    public enum UserInfoSearchCriteriaEnum
    {
        /// <summary>
        /// Indicates that the search must be performed on the Last Name.
        /// </summary>
        [EnumMember]
        LastName,

        /// <summary>
        /// Indicates that the search must be performed on the First Name.
        /// </summary>
        [EnumMember]
        FirstName
    }
}