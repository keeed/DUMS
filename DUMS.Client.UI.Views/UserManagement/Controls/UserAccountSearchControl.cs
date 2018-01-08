using System;
using System.Windows.Forms;
using DUMS.Client.UI.Contract.UserManagement.Enums;
using DUMS.Client.UI.Presenter.UserManagement;

namespace DUMS.Client.UI.Views.UserManagement.Controls
{
    /// <summary>
    /// UserAccountSearch Control
    /// </summary>
    public partial class UserAccountSearchControl : UserControl
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

        public UserAccountSearchControl()
        {
            InitializeComponent();

            initializeDependencies();
        }

        #endregion Constructor



        #region Functions

        /// <summary>
        /// Initalizes Dependencies
        /// </summary>
        private void initializeDependencies()
        {
            initializeSearchCriteriaComboBox();
        }

        /// <summary>
        /// Initializes SearchCriteria Combo box.
        /// </summary>
        private void initializeSearchCriteriaComboBox()
        {
            comboboxSearchCriteria.DataSource = Enum.GetValues(typeof(UserInfoSearchCriteria));
        }

        /// <summary>
        /// Get SearchCriteria from Combo box.
        /// </summary>
        /// <returns>SearchCriteria.</returns>
        private UserInfoSearchCriteria getSearchCriteriaFromComboBox()
        {
            UserInfoSearchCriteria userinfoSearchCriteria;
            Enum.TryParse<UserInfoSearchCriteria>(
                comboboxSearchCriteria.SelectedValue.ToString(), out userinfoSearchCriteria);

            return userinfoSearchCriteria;
        }

        #region UI Events

        /// <summary>
        /// Search Button Click event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">EventArgs object.</param>
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string keyWord = textboxSearch.Text;
            UserInfoSearchCriteria searchCriteria = getSearchCriteriaFromComboBox();

            _userAccountPresenter.SearchUser(
                searchCriteria,
                keyWord);
        }

        /// <summary>
        /// CLear Button Click event handler.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">EventArgs object.</param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            textboxSearch.Clear();
            _userAccountPresenter.UpdateUsers();
        }

        #endregion UI Events

        #endregion Functions
    }
}