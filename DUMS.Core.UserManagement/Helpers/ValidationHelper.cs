using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DUMS.Core.UserManagement.Helpers
{
    /// <summary>
    /// Validation Helper Class
    /// </summary>
    public static class ValidationHelper
    {
        #region Fields
        private const string _nameRegex = @"^[a-zA-Z ]+$";
        #endregion

        #region Methods
        /// <summary>
        /// Checks if the name is valid or not.
        /// </summary>
        /// <param name="name">Name to check.</param>
        /// <returns>Boolean value if name is valid.</returns>
        public static bool CheckIfNameIsValid(string name)
        {
            bool isValid = true;

            if (!string.IsNullOrEmpty(name))
            {
                isValid = Regex.IsMatch(name, _nameRegex);
            }
            else
            {
                isValid = false;
            }

            return isValid;
        }
        #endregion
    }
}
