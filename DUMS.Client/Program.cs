using System;
using System.ServiceModel;
using System.Windows.Forms;
using DUMS.Client.UI.Views.Login;
using DUMS.Client.UI.Views.UserManagement;

namespace DUMS.Client
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                // 1.) Initialize required services.
                ProgramHelper.RegisterUserManagementServices();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // 2.) Show login form to initiate login.
                LoginForm login = new LoginForm();

                // If dialog result is OK, it means that
                // the user has successfully loggedi in.
                if (login.ShowDialog() == DialogResult.OK)
                {
                    HomeForm homeForm = new HomeForm(login);
                    homeForm.InitializeDepdencies();
                    Application.Run(homeForm);
                }
                else
                {
                    Application.Exit();
                }
            }
            // Handle FaultException which indicates that
            // an unhandled exception is thrown by the server.
            catch (FaultException fe)
            {
                MessageBox.Show(
                    null,
                    "Connection error encountered.\n\nApplication will now exit.\n\nMessage: " + fe.Message,
                    "Cannot connect to server.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            // Handle CommunicationException which indicates that
            // the client cannot connect to the server.
            catch (CommunicationException ce)
            {
                MessageBox.Show(
                    null,
                    "Cannot connect to the server's services.\n\nPlease make sure that the service uri is "
                    + "correctly configured and that the server's services are running."
                    + "\n\nApplication will now exit.\n\nMessage: " + ce.Message,
                    "Cannot connect to server.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            // Handles all uncatched exception.
            catch (Exception ex)
            {
                MessageBox.Show(
                    null,
                    "Unhandled Exception.\n\nApplication will now exit.\n\nMessage: " + ex.Message,
                    "Application Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}