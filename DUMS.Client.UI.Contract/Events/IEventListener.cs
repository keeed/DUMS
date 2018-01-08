using System;

namespace DUMS.Client.UI.Contract.Events
{
    /// <summary>
    /// Interface to implement an event listener.
    /// </summary>
    public interface IEventListener
    {
        /// <summary>
        /// Handle the event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">EventArgs object.</param>
        void HandleEvent(object sender, EventArgs e);
    }
}