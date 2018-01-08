namespace DUMS.Client.UI.Contract.UserManagement.Enums
{
    public enum UserAccountActionType
    {
        /// <summary>
        /// Indicates that an Add User operation was done.
        /// </summary>
        AddUser,

        /// <summary>
        /// Indicates that an Add User operation was done but failed.
        /// </summary>
        AddUserFailed,

        /// <summary>
        /// Indicates that an Edit User operation was done.
        /// </summary>
        EditUser,

        /// <summary>
        /// Indicates that an Edit User operation was done but failed.
        /// </summary>
        EditUserFailed,

        /// <summary>
        /// Indicates that an Unlock User operation was done.
        /// </summary>
        UnlockUser,

        /// <summary>
        /// Indicates that an Unlock User operation was done but failed.
        /// </summary>
        UnlockUserFailed,

        /// <summary>
        /// Indicates that a Delete User operation was done.
        /// </summary>
        DeleteUser,

        /// <summary>
        /// Indicates that a Delete User operation was done but failed.
        /// </summary>
        DeleteUserFailed,

        /// <summary>
        /// Indicates that an Update User operation was triggered.
        /// </summary>
        UpdateUsers,

        /// <summary>
        /// Indicates that a Search User operation was triggered.
        /// </summary>
        SearchUsers
    }
}