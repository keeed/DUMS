using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DUMS.Client.UI.Contract.UserManagement;
using DUMS.Client.UI.Contract.UserManagement.Enums;
using DUMS.Client.UI.Contract.UserManagement.Objects;
using DUMS.Client.UI.Presenter.UserManagement;
using DUMS.Client.UI.Views.Login;

namespace DUMS.Client.UI.Views.UserManagement
{
    /// <summary>
    /// HomeForm form
    /// </summary>
    public partial class HomeForm : Form, IUserAccountView
    {
        #region Fields

        private UserAccountPresenter _userAccountPresenter;
        private LoginForm _loginForm;

        #endregion Fields



        #region Constructor

        public HomeForm(LoginForm loginForm)
        {
            InitializeComponent();

            _loginForm = loginForm;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Initalizes dependencies.
        /// </summary>
        public void InitializeDepdencies()
        {
            _userAccountPresenter = new UserAccountPresenter();

            userControls.UserAccountPresenter = _userAccountPresenter;
            userAccountTable.UserAccountPresenter = _userAccountPresenter;
            userAccountSearchControl.UserAccountPresenter = _userAccountPresenter;

            userControls.RegisterViewToModel();
            userAccountTable.RegisterViewToModel();

            userControls.userAccountTable = userAccountTable;

            _userAccountPresenter.RegisterView(typeof(IUserAccountView), this);

            retrieveData();
        }

        #region Implementation of IUserAccountView

        /// <summary>
        /// User Account Action
        /// </summary>
        /// <param name="userAccountActionType">Action Type</param>
        /// <param name="userAccounts">User Accounts retrieved.</param>
        /// <param name="userAccountLoggedIn">User Account logged in.</param>
        /// <param name="messageFromServer">Message from server.</param>
        public void UserAccountAction(
            Contract.UserManagement.Enums.UserAccountActionType userAccountActionType,
            List<UserAccount> userAccounts,
            Contract.UserManagement.Objects.UserAccount userAccountLoggedIn,
            string messageFromServer)
        {
            switch (userAccountActionType)
            {
                case UserAccountActionType.AddUser:
                    handleAddUser();
                    break;

                case UserAccountActionType.AddUserFailed:
                    handleAddUserFailed(messageFromServer);
                    break;

                case UserAccountActionType.EditUser:
                    handleEditUser();
                    break;

                case UserAccountActionType.EditUserFailed:
                    handleEditUserFailed(messageFromServer);
                    break;

                case UserAccountActionType.UnlockUser:
                    handleUnlockUser();
                    break;

                case UserAccountActionType.UnlockUserFailed:
                    handleUnlockUserFailed();
                    break;

                case UserAccountActionType.DeleteUser:
                    handleDeleteUser();
                    break;

                case UserAccountActionType.DeleteUserFailed:
                    handleDeleteUserFailed(messageFromServer);
                    break;
            }
        }

        #endregion Implementation of IUserAccountView

        #endregion Methods

        #region Functions

        /// <summary>
        /// Retrieve Data
        /// </summary>
        private void retrieveData()
        {
            _userAccountPresenter.UpdateUsers();
        }

        /// <summary>
        /// Handle add user
        /// </summary>
        private void handleAddUser()
        {
            MessageBox.Show(
                this,
                "User was successfully added.\nTable will now be updated.",
                "Add User Successful",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Handle add user failed.
        /// </summary>
        private void handleAddUserFailed(string message)
        {
            string displayMessage = "Add User Failed, please try again.";

            if (!string.IsNullOrEmpty(message))
            {
                displayMessage = "Add User Failed, please try again.\n\nReason: " + message;
            }

            MessageBox.Show(
                this,
                displayMessage,
                "Add User Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        /// <summary>
        /// Handle Edit User
        /// </summary>
        private void handleEditUser()
        {
            MessageBox.Show(
                this,
                "User was successfully edited.\nTable will now be updated.",
                "Edit User Successful",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Handle Edit User Failed
        /// </summary>
        /// <param name="message"></param>
        private void handleEditUserFailed(string message)
        {
            string displayMessage = "Edit User Failed, please try again.";

            if (!string.IsNullOrEmpty(message))
            {
                displayMessage = "Edit User Failed, please try again.\nReason: " + message;
            }

            MessageBox.Show(
                this,
                displayMessage,
                "Edit User Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        /// <summary>
        /// Handle Unlock User
        /// </summary>
        private void handleUnlockUser()
        {
            MessageBox.Show(
                this,
                "User was successfully unlocked.",
                "Unlock User Successful",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Handle Unlock User Failed
        /// </summary>
        private void handleUnlockUserFailed()
        {
            MessageBox.Show(
                this,
                "Unlock User Failed, please try again.",
                "Unlock User Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        /// <summary>
        /// Handle Delete User
        /// </summary>
        private void handleDeleteUser()
        {
            MessageBox.Show(
                this,
                "User was successfully deleted.\nTable will now be updated.",
                "Delete User Successful",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// Handle Delete User Failed
        /// </summary>
        /// <param name="message">Message from server.</param>
        private void handleDeleteUserFailed(string message)
        {
            string displayMessage = "Delete User Failed, please try again.";

            if (!string.IsNullOrEmpty(message))
            {
                displayMessage = "Delete User Failed, please try again.\nReason: " + message;
            }

            MessageBox.Show(
                this,
                displayMessage,
                "Delete User Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        #region UI Events

        /// <summary>
        /// Tool Strip Menu Logout Click Event Handler
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">EventArgs object.</param>
        private void toolstripmenuLogout_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            _loginForm.ClearPassword();
            if (_loginForm.ShowDialog(this) == DialogResult.OK)
            {
                retrieveData();
                this.Visible = true;
                this.Focus();
            }
            else
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Tool Strip Exit Logout Click Event Handler
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">EventArgs object.</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion UI Events

        #endregion Functions
    }
}