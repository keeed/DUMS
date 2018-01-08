using System.Runtime.Serialization;

namespace DUMS.Core.Contract.UserManagement.Enums
{
    /// <summary>
    /// Enums that define the Action Type that will
    /// be performed inside UserManagementServices.
    /// </summary>
    [DataContract]
    public enum UserManagementActionType
    {
        /// <summary>
        /// Indicates an Add User Action
        /// </summary>
        [EnumMember]
        AddUser,

        /// <summary>
        /// Indicates an Edit User Action
        /// </summary>
        [EnumMember]
        EditUser,

        /// <summary>
        /// Indicates a Delete User Action
        /// </summary>
        [EnumMember]
        DeleteUser,

        /// <summary>
        /// Indicates a Get Users Action
        /// </summary>
        [EnumMember]
        GetUsers,

        /// <summary>
        /// Indicates a Search User Action
        /// </summary>
        [EnumMember]
        SearchUsers,

        /// <summary>
        /// Indicates a Login User Action
        /// </summary>
        [EnumMember]
        Login,

        /// <summary>
        /// Indicates an Unlock User Action
        /// </summary>
        [EnumMember]
        UnlockUser
    }
}