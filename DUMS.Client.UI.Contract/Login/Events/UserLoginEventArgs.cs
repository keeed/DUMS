using System;
using DUMS.Client.UI.Contract.Login.Enums;

namespace DUMS.Client.UI.Contract.Login.Events
{
    public class UserLoginEventArgs : EventArgs
    {
        #region Fields

        private LoginResultType _loginResultType;
        private string message;

        #endregion Fields

        #region Properties

        public LoginResultType LoginResultType
        {
            get
            {
                return _loginResultType;
            }
            set
            {
                _loginResultType = value;
            }
        }

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }

        #endregion Properties
    }
}