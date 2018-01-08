using System;

namespace DUMS.SharedArchitecture.EventBus
{
    /// <summary>
    /// Event Bus Delegate which mimics an Event.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">EventArgs object.</param>
    public delegate void EventBusDelegate(object sender, EventArgs e);
}