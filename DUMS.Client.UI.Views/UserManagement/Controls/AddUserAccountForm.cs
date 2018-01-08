using System;
using System.Windows.Forms;
using DUMS.Client.UI.Contract.UserManagement.Enums;
using DUMS.Client.UI.Contract.UserManagement.Objects;
using DUMS.Client.UI.Presenter.UserManagement;

namespace DUMS.Client.UI.Views.UserManagement.Controls
{
    /// <summary>
    /// AddUserAccount Form for Adding a User Account
    /// </summary>
    public partial class AddUserAccountForm : Form
    {
        #region Fields

        private UserAccountPresenter _userAccountPresenter;

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

        public AddUserAccountForm()
        {
            InitializeComponent();

            datetimepickerBirthdate.MaxDate = DateTime.Now;

            initalizeUserTypeComboBox();
        }

        #endregion Constructor



        #region Functions

        /// <summary>
        /// Initializes the UserType Combo box.
        /// </summary>
        private void initalizeUserTypeComboBox()
        {
            comboboxUserType.DataSource = Enum.GetValues(typeof(UserType));
        }

        /// <summary>
        /// Gets the UserType selected in the UserType Combo box.
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
        /// Creates a new UserAccount based on the populated form.
        /// </summary>
        /// <returns>UserAccount created.</returns>
        private UserAccount createNewUserAccount()
        {
            UserAccount newUserAccount = new UserAccount();

            newUserAccount.UserID = 0;
            newUserAccount.Username = textboxUsername.Text;
            newUserAccount.Password = textboxPassword.Text;
            newUserAccount.UserType = getUserTypeFromComboBox();

            newUserAccount.UserInfo = new UserInfo();

            newUserAccount.UserInfo.FirstName = textboxFirstName.Text;
            newUserAccount.UserInfo.LastName = textboxLastname.Text;
            newUserAccount.UserInfo.BirthDate = datetimepickerBirthdate.Value.Date;

            return newUserAccount;
        }

        /// <summary>
        /// Compares if the passwords given are the same.
        /// </summary>
        /// <returns>Boolean value to indicate if they are the same.</returns>
        private bool arePasswordsGivenSame()
        {
            if (textboxPassword.Text == textboxRetypePassword.Text)
            {
                return true;
            }

            return false;
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
                if (!arePasswordsGivenSame())
                {
                    MessageBox.Show(
                        this,
                        "Passwords given do not match!\nPlease re-type passwords.",
                        "Passwords - Not Match",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    textboxPassword.Clear();
                    textboxRetypePassword.Clear();

                    isValid = false;
                }
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
                textboxRetypePassword.Clear();

                isValid = false;
            }

            return isValid;
        }

        #region UI Events

        /// <summary>
        /// Add Button Click event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">EventArgs object.</param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            UserAccount userAccount = createNewUserAccount();

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

            if(passwordValidation())
            {
                var result = MessageBox.Show(
                    this,
                    "Add this User?",
                    "Add User",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    _userAccountPresenter.AddUser(userAccount);
                    this.Close();
                }
                else if (result == DialogResult.Cancel)
                {
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Cancel Button Click event handler.
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