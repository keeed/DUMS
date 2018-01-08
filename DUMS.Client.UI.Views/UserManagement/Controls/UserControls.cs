using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DUMS.Client.UI.Contract.UserManagement;
using DUMS.Client.UI.Contract.UserManagement.Enums;
using DUMS.Client.UI.Contract.UserManagement.Objects;
using DUMS.Client.UI.Presenter.UserManagement;

namespace DUMS.Client.UI.Views.UserManagement.Controls
{
    /// <summary>
    /// UserControls control
    /// </summary>
    public partial class UserControls : UserControl, IUserAccountView
    {
        #region Fields

        private UserAccountPresenter _userAccountPresenter;
        private UserAccountTable _userAccountTable;

        #endregion Fields

        #region Properties

        public UserAccountPresenter UserAccountPresenter
        {
            get
            {
                return _userAccountPresenter;
            }
            set
            {
                _userAccountPresenter = value;
            }
        }

        public UserAccountTable userAccountTable
        {
            get
            {
                return _userAccountTable;
            }
            set
            {
                _userAccountTable = value;
            }
        }

        #endregion Properties



        #region Constructor

        public UserControls()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Registers view to model.
        /// </summary>
        public void RegisterViewToModel()
        {
            _userAccountPresenter.RegisterView(typeof(IUserAccountView), this);
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
            List<Contract.UserManagement.Objects.UserAccount> userAccounts,
            Contract.UserManagement.Objects.UserAccount userAccountLoggedIn,
            string messageFromServer)
        {
            switch (userAccountActionType)
            {
                case UserAccountActionType.UpdateUsers:
                    handleUpdateUsers(userAccountLoggedIn);
                    break;
            }
        }

        #endregion Implementation of IUserAccountView

        #endregion Methods

        #region Functions

        /// <summary>
        /// Handles update users
        /// </summary>
        /// <param name="loggedInUserAccount">Logged in User Account.</param>
        private void handleUpdateUsers(UserAccount loggedInUserAccount)
        {
            switch (loggedInUserAccount.UserType)
            {
                case UserType.Admin:
                    handleAdminControls();
                    break;

                case UserType.Normal:
                    handleNormalControls();
                    break;
            }
        }

        /// <summary>
        /// Handle Admin Controls
        /// </summary>
        private void handleAdminControls()
        {
            groupboxUserButtonControls.Visible = true;
            buttonAdd.Visible = true;
            buttonEdit.Visible = true;
            buttonUnlock.Visible = true;
            buttonDelete.Visible = true;
        }

        /// <summary>
        /// Handle Normal Controls
        /// </summary>
        private void handleNormalControls()
        {
            groupboxUserButtonControls.Visible = false;
            buttonAdd.Visible = false;
            buttonEdit.Visible = false;
            buttonUnlock.Visible = false;
            buttonDelete.Visible = false;
        }

        #region UI Events

        /// <summary>
        /// Add Button Event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event Args object.</param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddUserAccountForm addUserAccountForm = new AddUserAccountForm();
            addUserAccountForm.UserAccountPresenter = UserAccountPresenter;
            addUserAccountForm.ShowDialog();
        }

        /// <summary>
        /// Edit Button Event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event Args object.</param>
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            UserAccount userAccountSelected = userAccountTable.GetSelectedUserAccount();

            EditUserAccountForm editUserAccountForm = new EditUserAccountForm(userAccountSelected);
            editUserAccountForm.UserAccountPresenter = UserAccountPresenter;
            editUserAccountForm.ShowDialog();
        }

        /// <summary>
        /// Unlock Button Event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event Args object.</param>
        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            UserAccount userAccountSelected = userAccountTable.GetSelectedUserAccount();

            var result = MessageBox.Show(
                this,
                "Are you sure you want to unlock this User?",
                "Unlock User",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                _userAccountPresenter.UnlockUser(userAccountSelected);
            }
        }

        /// <summary>
        /// Delete Button Event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event Args object.</param>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            UserAccount userAccountSelected = userAccountTable.GetSelectedUserAccount();

            var result = MessageBox.Show(
                this,
                "Are you sure you want to delete this User?",
                "Delete User",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                _userAccountPresenter.DeleteUser(userAccountSelected);
            }
        }

        #endregion UI Events

        #endregion Functions
    }
}