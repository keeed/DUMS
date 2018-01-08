using System;
using System.Windows.Forms;
using DUMS.Client.UI.Contract.UserManagement.Enums;
using DUMS.Client.UI.Contract.UserManagement.Objects;
using DUMS.Client.UI.Presenter.UserManagement;

namespace DUMS.Client.UI.Views.UserManagement.Controls
{
    /// <summary>
    /// Edit USer Account Form used for Edit User
    /// </summary>
    public partial class EditUserAccountForm : Form
    {
        #region Fields

        private UserAccountPresenter _userAccountPresenter;
        private UserAccount _userAccount;

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

        public UserAccount UserAccount
        {
            get
            {
                return _userAccount;
            }
            set
            {
                _userAccount = value;
            }
        }

        #endregion Properties

        #region Constructor

        public EditUserAccountForm(UserAccount userAccount)
        {
            InitializeComponent();

            datetimepickerBirthdate.MaxDate = DateTime.Now;

            _userAccount = userAccount;

            displayUserAccount();
        }

        #endregion Constructor



        #region Functions

        /// <summary>
        /// Displays User Accounts
        /// </summary>
        private void displayUserAccount()
        {
            labelUserID.Text = _userAccount.UserID.ToString();
            textboxUsername.Text = _userAccount.Username;
            textboxPassword.Text = _userAccount.Password;

            comboboxUserType.DataSource = Enum.GetValues(typeof(UserType));
            comboboxUserType.SelectedItem = _userAccount.UserType;

            textboxFirstName.Text = _userAccount.UserInfo.FirstName;
            textboxLastName.Text = _userAccount.UserInfo.LastName;
            datetimepickerBirthdate.Value = _userAccount.UserInfo.BirthDate;
        }

        /// <summary>
        /// Updates UserAccount from Form
        /// </summary>
        /// <returns>Updated UserAccount</returns>
        private UserAccount updateUserAccountFromForm()
        {
            _userAccount.UserID = long.Parse(labelUserID.Text);
            _userAccount.Username = textboxUsername.Text;
            _userAccount.Password = _userAccount.Password;
            _userAccount.UserType = getUserTypeFromComboBox();

            _userAccount.UserInfo.FirstName = textboxFirstName.Text;
            _userAccount.UserInfo.LastName = textboxLastName.Text;
            _userAccount.UserInfo.BirthDate = datetimepickerBirthdate.Value;

            return _userAccount;
        }

        /// <summary>
        /// Get UserType from combo box.
        /// </summary>
        /// <returns>UserType selected.</returns>
        private UserType getUserTypeFromComboBox()
        {
            UserType userType;
            Enum.TryParse<UserType>(
                comboboxUserType.SelectedValue.ToString(), out userType);

            return userType;
        }

        /// <summary>
        /// Validates password given.
        /// </summary>
        /// <returns>Boolean value indicating if it is valid or not.</returns>
        private bool passwordValidation()
        {
            bool isValid = true;

            if (!string.IsNullOrEmpty(textboxPassword.Text))
            {
                isValid = true;
            }
            else
            {
                MessageBox.Show(
                        this,
                        "Password cannot be empty!",
                        "Password - Empty",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                textboxPassword.Clear();

                isValid = false;
            }

            return isValid;
        }

        #region UI Events

        /// <summary>
        /// Edit Button Event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">EventArgs object.</param>
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            _userAccount = updateUserAccountFromForm();

            if (string.IsNullOrEmpty(textboxUsername.Text))
            {
                MessageBox.Show(
                    this,
                    "Username cannot be empty!",
                    "Username - Empty",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (passwordValidation())
            {
                var result = MessageBox.Show(
                    this,
                    "Edit this User?",
                    "Edit User",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    _userAccountPresenter.EditUser(_userAccount);
                    this.Close();
                }
                else if (result == DialogResult.Cancel)
                {
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Cancel Button Event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">EventArgs object.</param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion UI Events

        #endregion Functions
    }
}