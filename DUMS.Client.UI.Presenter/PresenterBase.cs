using System;
using System.Collections.Generic;
using System.Linq;
using DUMS.Client.UI.Contract.Events;
using DUMS.Client.UI.Presenter.Objects;

namespace DUMS.Client.UI.Presenter
{
    /// <summary>
    /// Presenter Base Class
    /// </summary>
    public abstract class PresenterBase : IEventListener
    {
        #region Fields

        private List<ViewType> _views;

        #endregion Fields

        #region Properties

        public List<ViewType> Views
        {
            get
            {
                return _views;
            }
            set
            {
                _views = value;
            }
        }

        #endregion Properties

        #region Constructor

        public PresenterBase()
        {
            initializeFields();
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Registers a View
        /// </summary>
        /// <param name="type">Type of the view.</param>
        /// <param name="view">View object.</param>
        public void RegisterView(Type type, object view)
        {
            Views.Add(new ViewType() { Type = type, View = view });
        }

        /// <summary>
        /// Gets all the Views under (T)
        /// </summary>
        /// <typeparam name="T">Type of the views to retrieve.</typeparam>
        /// <returns>All views of type (T).</returns>
        public IEnumerable<T> GetViews<T>() where T : class
        {
            return from viewItem in _views
                   where viewItem.Type == typeof(T)
                   select viewItem.View as T;
        }

        /// <summary>
        /// Abstract implementation of registering to event bus.
        /// </summary>
        public abstract void RegisterToEventBus();

        #region Implementation of IEventListener

        /// <summary>
        /// Abstract interface implmenetation of IEventListener.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">EventArgs object.</param>
        public abstract void HandleEvent(object sender, EventArgs e);

        #endregion Implementation of IEventListener

        #endregion Methods

        #region Functions

        /// <summary>
        /// Initalizes all fields needed.
        /// </summary>
        private void initializeFields()
        {
            if (_views == null)
            {
                _views = new List<ViewType>();
            }
        }

        #endregion Functions
    }
}