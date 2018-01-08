using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using DUMS.Data.Contract.UserManagement.Enums;

namespace DUMS.Data.Contract.UserManagement.Objects
{
    [DataContract]
    [Serializable]
    public class UserInfo
    {
        #region Fields
        private string _firstName;
        private string _lastName;
        private int _age;
        private DateTime _birthDate;
        #endregion

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

        #endregion

        #region Constructor

        public UserInfo()
        {

        }

        #endregion
        
    }
}
