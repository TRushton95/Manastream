using Manastream.Src.EventSystem.Events;
using System.Collections.Generic;

namespace Manastream.Src.EventSystem
{
    public delegate void EventHandler(Event e);

    /// <summary>
    /// The event manager that routes event messages to and from the <see cref="Listener"/> class.
    /// </summary>
    public class EventManager
    {
        #region Fields

        private static EventManager eventManager;
        private SortedDictionary<string, List<Listener>> eventListenerLookup;

        #endregion

        #region Constructors
        
        /// <summary>
        /// Initialises a new instance of the <see cref="EventManager"/> class.
        /// </summary>
        public EventManager()
        {
            eventListenerLookup = new SortedDictionary<string, List<Listener>>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get the instance of the <see cref="EventManager"/> class.
        /// </summary>
        public static EventManager GetInstance()
        {
            if (eventManager == null)
            {
                eventManager = new EventManager();
            }

            return eventManager;
        }

        /// <summary>
        /// Notify the event manager of a new event
        /// </summary>
        public void Notify(Event e)
        {
            List<Listener> eventListeners;
            bool eventTypeFound = eventListenerLookup.TryGetValue(e.EventType, out eventListeners);

            if (!eventTypeFound)
            {
                return;
            }

            foreach (Listener eventListener in eventListeners)
            {
                eventListener.OnEventReceived(e);
            }
        }

        /// <summary>
        /// Register a new listener for a given event type.
        /// </summary>
        public void AddEventListener(string eventType, Listener listener)
        {
            List<Listener> eventListeners;
            bool eventTypeFound = eventListenerLookup.TryGetValue(eventType, out eventListeners);

            if (!eventTypeFound)
            {
                eventListeners = new List<Listener>();
                eventListenerLookup.Add(eventType, eventListeners);
            }

            if (!eventListeners.Contains(listener))
            {
                eventListeners.Add(listener);
            }
        }

        /// <summary>
        /// Deregister an event listener from a given event type.
        /// </summary>
        /// <remarks>If no listeners remain for a given event type, remove the empty list entry.</remarks>
        public void RemoveEventListener(string eventType, Listener listener)
        {
            List<Listener> eventListeners;
            bool eventTypeFound = eventListenerLookup.TryGetValue(eventType, out eventListeners);

            if (!eventTypeFound)
            {
                return;
            }

            eventListeners.Remove(listener);

            if (eventListeners.Count == 0)
            {
                eventListenerLookup.Remove(eventType);
            }
        }

        #endregion
    }
}
