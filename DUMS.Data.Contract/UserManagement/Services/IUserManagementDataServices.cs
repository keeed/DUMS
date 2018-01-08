using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUMS.Data.Contract.DataProvider;
using DUMS.Data.Contract.UserManagement.Enums;
using DUMS.Data.Contract.UserManagement.Objects;

namespace DUMS.Data.Contract.UserManagement.Services
{
    public interface IUserManagementDataServices : IDataProvider
    {
        /// <summary>
        /// Adds a User.
        /// </summary>
        /// <param name="userAccount">UserAccount that will be added.<  /param>
        /// <returns>Boolean value to indicate if the add was succesful.</returns>
        bool AddUser(UserAccount userAccount);

        /// <summary>
        /// Deletes a User.
        /// </summary>
        /// <param name="UserAccount">UserAccount that will be deleted.</param>
        /// <returns>Boolean value to indicate if the delete was successful.</returns>
        bool DeleteUser(UserAccount userAccount);

        /// <summary>
        /// Edits a User
        /// </summary>
        /// <param name="UserAccount">UserAccount that will be edited.</param>
        /// <returns>Boolean value to indicate if the edit was successful.</returns>
        bool EditUser(UserAccount userAccount);

        /// <summary>
        /// Gets a User by ID
        /// </summary>
        /// <param name="id">ID of the User</param>
        /// <returns>UserAccount of the ID.</returns>
        UserAccount GetUserById(long id);

        /// <summary>
        /// Gets a User by Username
        /// </summary>
        /// <param name="userName">Username of the User</param>
        /// <returns>UserAccount of the Username.</returns>
        UserAccount GetUserByUsername(string username);

        /// <summary>
        /// Gets all the Users
        /// </summary>
        /// <returns>List of all the Users</returns>
        List<UserAccount> GetUsers();

        /// <summary>
        /// Gets all the Users that contains the first name given.
        /// </summary>
        /// <param name="firstName">First Name key word.</param>
        /// <returns>All users that contains the first name keyword.</returns>
        List<UserAccount> GetUsersByFirstName(string firstName);

        /// <summary>
        /// Gets all the Users that contains the last name given.
        /// </summary>
        /// <param name="lastName">Last Name key word.</param>
        /// <returns>All users that contains the last name keyword.</returns>
        List<UserAccount> GetUsersByLastName(string lastName);

        /// <summary>
        /// Gets the UserType of a User based on the user ID.
        /// </summary>
        /// <param name="userID">User ID of the User.</param>
        /// <returns>UserType of the User.</returns>
        UserType GetUserType(long userID);

        /// <summary>
        /// Gets the number of failed attempts based on the user ID.
        /// </summary>
        /// <param name="userID">User ID of the user account.</param>
        /// <returns>Number of failed attempts.</returns>
        int GetNumberOfFailedAttempts(long userID);

        /// <summary>
        /// Sets the number of failed attempts based on the user ID.
        /// </summary>
        /// <param name="userID">User ID of the user account.</param>
        /// <param name="numberOfFailedAttempts">Number of failed attempts.</param>
        /// <returns>Boolean value indicating if the set was successful.</returns>
        bool SetNumberOfFailedAttempts(long userID, int numberOfFailedAttempts);
    }
}
