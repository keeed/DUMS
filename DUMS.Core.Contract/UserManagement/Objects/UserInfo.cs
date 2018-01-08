using System;
using System.Runtime.Serialization;
using System.Text;

namespace DUMS.Core.Contract.User
{
    [DataContract]
    public class UserInfo
    {
        #region Fields

        private string _firstName;
        private string _lastName;
        private int _age;
        private DateTime _birthDate;

        #endregion Fields

        #region Properties

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        [DataMember]
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

        #region Methods

        public override string ToString()
        {
            StringBuilder sbuilder = new StringBuilder();

            sbuilder.Append("[FirstName:").Append(FirstName).Append("]")
                    .Append("[LastName:").Append(LastName).Append("]")
                    .Append("[Age:").Append(Age).Append("]")
                    .Append("[Birthdate:").Append(BirthDate.ToString("MM/dd/yyyy")).Append("]");

            return sbuilder.ToString();
        }

        #endregion Methods
    }
}