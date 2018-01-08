namespace DUMS.Client.UI.Contract.Login
{
    public interface ILoginView
    {
        /// <summary>
        /// View implementation of when the Login succeeded.
        /// <param name="message">Message to be displayed in messagebox.</param>
        /// </summary>
        void LoginSuccess(string message);

        /// <summary>
        /// View implementation of when the login failed.
        /// <param name="message">Message to be displayed in messagebox.</param>
        /// </summary>
        void LoginFailed(string message);
    }
}