using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUMS.Client.Common.EventBus;
using DUMS.Client.UI.Contract.Events;

namespace DUMS.Client.Common.EventBus
{
    public class EventBus<T> 
        where T : class
    {
        #region Fields
        private static Dictionary<Type, EventBusDelegate> _eventsTable = new Dictionary<Type, EventBusDelegate>();
        #endregion

        #region Properties
        public static event EventBusDelegate Subscribe
        {
            add
            {
                lock(_eventsTable)
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
        #endregion

        #region Constructor
        private EventBus()
        {

        }
        #endregion

        #region Methods
        public static void Broadcast(object sender, EventArgs e)
        {
            _eventsTable[typeof(T)](sender, e);
        }
        #endregion


        #region Functions
        #endregion
    }
}
