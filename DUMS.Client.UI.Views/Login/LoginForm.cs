using System;
using System.Windows.Forms;
using DUMS.Client.UI.Contract.Login;
using DUMS.Client.UI.Presenter.Login;

namespace DUMS.Client.UI.Views.Login
{
    /// <summary>
    /// Login Form used for Login
    /// </summary>
    public partial class LoginForm : Form, ILoginView
    {
        #region Fields

        private LoginPresenter _loginPresenter;

        #endregion Fields

        #region Properties

        public LoginPresenter LoginPresenter
        {
            get
            {
                return _loginPresenter;
            }
            set
            {
                _loginPresenter = value;
            }
        }

        #endregion Properties

        #region Constructor

        public LoginForm()
        {
            InitializeComponent();

            injectDependencies();
        }

        #endregion Constructor

        #region Methods

        public void ClearPassword()
        {
            textboxPassword.Clear();
        }

        #region Implementation of ILoginView

        public void LoginSuccess(string message)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public void LoginFailed(string message)
        {
            string displayMessage = !string.IsNullOrEmpty(message) ? message :
                "Incorrect username or password. \nPlease try again.";

            MessageBox.Show(
                displayMessage,
                "Login Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        #endregion Implementation of ILoginView

        #endregion Methods

        #region Functions

        private void injectDependencies()
        {
            _loginPresenter = new LoginPresenter();
            _loginPresenter.RegisterView(typeof(ILoginView), this);
        }

        #region UI Events

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            _loginPresenter.Login(textboxUsername.Text, textboxPassword.Text);
        }

        #endregion UI Events

        #endregion Functions
    }
}