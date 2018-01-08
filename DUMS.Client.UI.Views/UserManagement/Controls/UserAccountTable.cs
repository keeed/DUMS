using System.Collections.Generic;
using System.Windows.Forms;
using DUMS.Client.UI.Contract.UserManagement;
using DUMS.Client.UI.Contract.UserManagement.Enums;
using DUMS.Client.UI.Contract.UserManagement.Objects;
using DUMS.Client.UI.Presenter.UserManagement;

namespace DUMS.Client.UI.Views.UserManagement.Controls
{
    /// <summary>
    /// UserAccountTable Control
    /// </summary>
    public partial class UserAccountTable : UserControl, IUserAccountView
    {
        #region Fields

        private UserAccountPresenter _userAccountPresenter;
        private List<UserAccount> _userAccounts;

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

        #endregion Properties



        #region Constructor

        public UserAccountTable()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Registers this View to Model
        /// </summary>
        public void RegisterViewToModel()
        {
            _userAccountPresenter.RegisterView(typeof(IUserAccountView), this);
        }

        /// <summary>
        /// Get selected UserAccount
        /// </summary>
        /// <returns>UserAccount selected.</returns>
        public UserAccount GetSelectedUserAccount()
        {
            var selectedRow = datagridviewUserAccounts.SelectedRows[0];

            int selectedUserID = int.Parse(selectedRow.Cells["ID"].Value.ToString());

            return _userAccounts.Find(u => u.UserID == selectedUserID);
        }

        #region Implementation of IUserAccountView

        /// <summary>
        /// UserAccountAction
        /// </summary>
        /// <param name="userAccountActionType">Action Type</param>
        /// <param name="userAccounts">UserAccounts retrieved.</param>
        /// <param name="userAccountLoggedIn">UserAccount logged in.</param>
        /// <param name="messageFromServer">Message from server.</param>
        public void UserAccountAction(
            Contract.UserManagement.Enums.UserAccountActionType userAccountActionType,
            List<Contract.UserManagement.Objects.UserAccount> userAccounts,
            Contract.UserManagement.Objects.UserAccount userAccountLoggedIn,
            string messageFromServer)
        {
            if (userAccounts != null)
            {
                _userAccounts = userAccounts;
            }
            switch (userAccountActionType)
            {
                case UserAccountActionType.UpdateUsers:
                    handleUpdateUsers();
                    break;

                case UserAccountActionType.AddUser:
                    handleAddUser();
                    break;

                case UserAccountActionType.EditUser:
                    handleSearchUsers();
                    break;

                case UserAccountActionType.DeleteUser:
                    handleDeleteUser();
                    break;

                case UserAccountActionType.SearchUsers:
                    handleSearchUsers();
                    break;
            }
        }

        #endregion Implementation of IUserAccountView

        #endregion Methods

        #region Functions

        /// <summary>
        /// Handle Add User
        /// </summary>
        private void handleAddUser()
        {
            updateDataGridView();
        }

        /// <summary>
        /// Handle Delete User
        /// </summary>
        private void handleDeleteUser()
        {
            updateDataGridView();
        }

        /// <summary>
        /// Handle Update Users
        /// </summary>
        private void handleUpdateUsers()
        {
            updateDataGridView();
        }

        /// <summary>
        /// Handle Search Users
        /// </summary>
        private void handleSearchUsers()
        {
            updateDataGridView();
        }

        /// <summary>
        /// Update data grid view
        /// </summary>
        private void updateDataGridView()
        {
            datagridviewUserAccounts.Rows.Clear();
            foreach (UserAccount userAccount in _userAccounts)
            {
                int rowIndex = datagridviewUserAccounts.Rows.Add();
                DataGridViewRow row = datagridviewUserAccounts.Rows[rowIndex];

                row.Cells["ID"].Value = userAccount.UserID;
                row.Cells["Username"].Value = userAccount.Username;
                row.Cells["Password"].Value = userAccount.Password;
                row.Cells["Usertype"].Value = userAccount.UserType;
                row.Cells["Firstname"].Value = userAccount.UserInfo.FirstName;
                row.Cells["Lastname"].Value = userAccount.UserInfo.LastName;
                row.Cells["Age"].Value = userAccount.UserInfo.Age;
                row.Cells["Birthdate"].Value = userAccount.UserInfo.BirthDate.ToString("MM/dd/yyyy");
            }
        }

        #endregion Functions
    }
}