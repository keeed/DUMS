using System;
using System.Collections.Generic;

namespace DUMS.SharedArchitecture.EventBus
{
    /// <summary>
    /// Event Bus that can be used to subscribe/broadcast events.
    /// </summary>
    /// <typeparam name="T">The EventArgs which mimics the delegate used by the Event Bus.</typeparam>
    public class EventBus<T>
        where T : class
    {
        #region Fields

        private static Dictionary<Type, EventBusDelegate> _eventsTable = new Dictionary<Type, EventBusDelegate>();

        #endregion Fields

        #region Properties

        /// <summary>
        /// Subsribes to a specific EventArgs.
        /// </summary>
        public static event EventBusDelegate Subscribe
        {
            add
            {
                lock (_eventsTable)
                {
                    if (!_eventsTable.ContainsKey(typeof(T)))
                    {
                        _eventsTable.Add(typeof(T), null);
                    }
                    _eventsTable[typeof(T)] = _eventsTable[typeof(T)] + value;
                }
            }
            remove
            {
                lock (_eventsTable)
                {
                    if (_eventsTable.ContainsKey(typeof(T)))
                    {
                        _eventsTable[typeof(T)] = _eventsTable[typeof(T)] - value;
                    }
                }
            }
        }

        #endregion Properties

        #region Constructor

        private EventBus()
        {
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Broadcasts to all the EventArgs Type (T) passed.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event Args passed.</param>
        public static void Broadcast(object sender, EventArgs e)
        {
            _eventsTable[typeof(T)](sender, e);
        }

        #endregion Methods
    }
}