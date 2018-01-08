using System;

namespace DUMS.Client.UI.Presenter.Objects
{
    /// <summary>
    /// ViewType container to be used by Presenters.
    /// </summary>
    public class ViewType
    {
        #region Fields

        private Type _type;
        private object _view;

        #endregion Fields

        #region Properites

        /// <summary>
        /// Type of the View
        /// </summary>
        public Type Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        /// <summary>
        /// The actual view object.
        /// </summary>
        public object View
        {
            get
            {
                return _view;
            }
            set
            {
                _view = value;
            }
        }

        #endregion Properites

        #region Construtor

        public ViewType()
        {
        }

        #endregion Construtor
    }
}