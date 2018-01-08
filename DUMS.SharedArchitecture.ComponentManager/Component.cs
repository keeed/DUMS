using System;

namespace DUMS.SharedArchitecture.ComponentManager
{
    /// <summary>
    ///  Component Class used by the Component Manager
    /// </summary>
    public class Component
    {
        #region Fields

        private Type _type;
        private object _value;

        #endregion Fields

        #region Properties

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

        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        #endregion Properties

        #region Constructor

        public Component()
        {
        }

        #endregion Constructor
    }
}