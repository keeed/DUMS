using System;

namespace DUMS.Client.UI.Contract.UserManagement.Objects
{
    public class UserInfo
    {
        #region Fields

        private string _firstName;
        private string _lastName;
        private int _age;
        private DateTime _birthDate;

        #endregion Fields

        #region Properties

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return _birthDate;
            }
            set
            {
                _birthDate = value;
            }
        }

        #endregion Properties

        #region Constructor

        public UserInfo()
        {
        }

        #endregion Constructor
    }
}