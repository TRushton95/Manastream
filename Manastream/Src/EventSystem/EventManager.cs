namespace Manastream.Src.EventSystem
{
    #region Usings

    using Manastream.Src.EventSystem.Events;
    using System.Collections.Generic;

    #endregion

    #region Delegates

    public delegate void EventHandler(Event e);

    #endregion

    /// <summary>
    /// The event manager that routes event messages to and from the <see cref="Listener"/> class.
    /// </summary>
    public class EventManager
    {
        #region Fields

        private static EventManager eventManager;
        private SortedDictionary<int, List<Listener>> eventListenerLookup;
        private int nextEventId = 0;

        #endregion

        #region Constructors
        
        /// <summary>
        /// Initialises a new instance of the <see cref="EventManager"/> class.
        /// </summary>
        private EventManager()
        {
            eventListenerLookup = new SortedDictionary<int, List<Listener>>();
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
            bool eventTypeFound = eventListenerLookup.TryGetValue(e.EventType.Id, out eventListeners);

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
        public void AddEventListener(EventType eventType, Listener listener)
        {
            if (eventType.Id == -1)
            {
                eventType.Id = nextEventId++;
            }

            List<Listener> eventListeners;
            bool eventTypeFound = eventListenerLookup.TryGetValue(eventType.Id, out eventListeners);

            if (!eventTypeFound)
            {
                eventListeners = new List<Listener>();
                eventListenerLookup.Add(eventType.Id, eventListeners);
            }

            if (!eventListeners.Contains(listener))
            {
                eventListeners.Add(listener);
            }
        }

        /// <summary>
        /// Deregister an event listener from a given event type.
        /// <para>If no listeners remain for a given event type, remove the empty list entry.</para>
        /// </summary>
        public void RemoveEventListener(EventType eventType, Listener listener)
        {
            List<Listener> eventListeners;
            bool eventTypeFound = eventListenerLookup.TryGetValue(eventType.Id, out eventListeners);

            if (!eventTypeFound)
            {
                return;
            }

            eventListeners.Remove(listener);

            if (eventListeners.Count == 0)
            {
                eventListenerLookup.Remove(eventType.Id);
            }
        }

        #endregion
    }
}
