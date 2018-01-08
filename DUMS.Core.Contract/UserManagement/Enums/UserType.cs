using System.Runtime.Serialization;

namespace DUMS.Core.Contract.UserManagement.Enums
{
    /// <summary>
    /// Defines the different UserTypes.
    /// </summary>
    [DataContract]
    public enum UserType
    {
        /// <summary>
        /// Administrator
        /// </summary>
        [EnumMember]
        Admin,

        /// <summary>
        /// Normal user
        /// </summary>
        [EnumMember]
        Normal
    }
}