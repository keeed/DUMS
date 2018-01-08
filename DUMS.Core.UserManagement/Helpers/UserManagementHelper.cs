using System;
using System.Text.RegularExpressions;

namespace DUMS.Core.UserManagement.Helpers
{
    /// <summary>
    /// Helper class for handling UserManagement logic.
    /// </summary>
    public class UserManagementHelper
    {
        #region Methods

        /// <summary>
        /// Calculates the Age of the User given a DateTime object.
        /// </summary>
        /// <param name="birthDate">Birthdate in DateTime</param>
        /// <returns>Age from birth date.</returns>
        public static int CalculateAge(DateTime birthDate)
        {
            int age;

            DateTime datetimeNow = DateTime.Now;

            age = datetimeNow.Year - birthDate.Year;

            if (age < 0)
            {
                return 0;
            }

            if (datetimeNow.Month >= birthDate.Month &&
                datetimeNow.Day >= birthDate.Day)
            {
                age += 1;
            }

            return age;
        }

        #endregion Methods
    }
}