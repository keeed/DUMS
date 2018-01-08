using System.Collections.Generic;

namespace DUMS.SharedArchitecture.ComponentManager
{
    /// <summary>
    /// Component Manager that can handle components/objects
    /// within the application.
    /// </summary>
    public class ComponentManager
    {
        #region Fields

        private static List<Component> _components = new List<Component>();

        #endregion Fields

        #region Constructor

        private ComponentManager()
        {
            _components = new List<Component>();
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Registers a component.
        /// NOTE:
        ///     - The type of the generics passed should be
        ///     assignable from the component passed.
        /// Ex.
        ///     A implements B.
        ///     Generic Type: B
        ///     Component: A
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="component"></param>
        public static void RegisterComponent<T>(object component) where T : class
        {
            if (component == null)
            {
                return;
            }

            if (typeof(T).IsAssignableFrom(component.GetType()))
            {
                Component newComponent = new Component();
                newComponent.Type = typeof(T);
                newComponent.Value = component;

                RemoveComponent<T>();
                _components.Add(newComponent);
            }
        }

        /// <summary>
        /// Gets a specific component.
        /// The Generic parameter will specify the component that will be returned.
        /// </summary>
        /// <typeparam name="T">The generic type to search for.</typeparam>
        /// <returns>The component found.</returns>
        public static T GetComponent<T>() where T : class
        {
            Component component = _components.Find(c => c.Value is T);
            if (component != null)
            {
                return (T)component.Value;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Removes a component.
        /// The Generic parameter will specify the component that will be removed.
        /// </summary>
        /// <typeparam name="T">The generic type to search for.</typeparam>
        public static void RemoveComponent<T>() where T : class
        {
            Component componentToRemove = _components.Find(c => c.Value is T);
            if (componentToRemove != null)
            {
                _components.Remove(componentToRemove);
            }
        }

        #endregion Methods
    }
}