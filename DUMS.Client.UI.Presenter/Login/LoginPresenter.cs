using System;
using System.Collections.Generic;
using DUMS.Client.UI.Contract.Events;
using DUMS.Client.UI.Contract.Login;
using DUMS.Client.UI.Contract.Login.Events;
using DUMS.Client.UI.Contract.UserManagement.Objects;
using DUMS.Client.UI.Model.Login;
using DUMS.SharedArchitecture.EventBus;

namespace DUMS.Client.UI.Presenter.Login
{
    /// <summary>
    /// Presenter class for Login
    /// </summary>
    public class LoginPresenter : PresenterBase, IEventListener
    {
        #region Fields

        private LoginModel _loginModel;

        #endregion Fields



        #region Constructor

        public LoginPresenter() :
            base()
        {
            _loginModel = new LoginModel();

            RegisterToEventBus();
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Performs login.
        /// </summary>
        /// <param name="username">Username of the user trying to login.</param>
        /// <param name="password">Password of the user trying to login.</param>
        public void Login(string username, string password)
        {
            UserAccount userAccount = new UserAccount();
            userAccount.Username = username;
            userAccount.Password = password;

            _loginModel.Login(userAccount);
        }

        /// <summary>
        /// Registers self to the EventBus
        /// </summary>
        public override void RegisterToEventBus()
        {
            EventBus<UserLoginEventArgs>.Subscribe += this.HandleEvent;
        }

        #region Implementation of IEventListener

        /// <summary>
        /// Handles the EventArg passed.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">EventArgs</param>
        public override void HandleEvent(object sender, EventArgs e)
        {
            if (e is UserLoginEventArgs)
            {
                UserLoginEventArgs userLoginEventArg = e as UserLoginEventArgs;
                if (userLoginEventArg != null)
                {
                    IEnumerable<ILoginView> views;
                    switch (userLoginEventArg.LoginResultType)
                    {
                        case Contract.Login.Enums.LoginResultType.Failed:
                            views = GetViews<ILoginView>();
                            foreach (ILoginView view in views)
                            {
                                view.LoginFailed(userLoginEventArg.Message);
                            }
                            break;

                        case Contract.Login.Enums.LoginResultType.Success:
                            views = GetViews<ILoginView>();
                            foreach (ILoginView view in views)
                            {
                                view.LoginSuccess(userLoginEventArg.Message);
                            }
                            break;
                    }
                }
            }
        }

        #endregion Implementation of IEventListener

        #endregion Methods
    }
}