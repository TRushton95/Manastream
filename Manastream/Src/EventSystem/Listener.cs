using Manastream.Src.EventSystem.Events;
using System.Collections.Generic;

namespace Manastream.Src.EventSystem
{
    /// <summary>
    /// The listener base class to notify and receive messages from the <see cref="EventManager"/>.
    /// </summary>
    public abstract class Listener
    {
        #region Fields

        protected EventManager eventManager;
        private SortedDictionary<string, List<EventHandler>> eventHandlerLookup;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Listener"/> class.
        /// </summary>
        public Listener()
        {
            eventManager = EventManager.GetInstance();
            eventHandlerLookup = new SortedDictionary<string, List<EventHandler>>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoke the relevant event handlers on a received event.
        /// </summary>
        public void OnEventReceived(Event e)
        {
            string eventType = e.EventType;

            if (string.IsNullOrWhiteSpace(eventType))
            {
                return;
            }

            List<EventHandler> eventHandlers;
            bool eventTypeFound = eventHandlerLookup.TryGetValue(eventType, out eventHandlers);

            if (!eventTypeFound)
            {
                return;
            }

            foreach (EventHandler eventHandler in eventHandlers)
            {
                eventHandler.Invoke(e);
            }
        }

        /// <summary>
        /// Add a new event handler to handle a given event type.
        /// </summary>
        public void AddEventHandler(string eventType, EventHandler eventHandlerToAdd)
        {
            List<EventHandler> eventHandlers;
            bool eventTypeFound = eventHandlerLookup.TryGetValue(eventType, out eventHandlers);

            if (!eventTypeFound)
            {
                eventHandlers = new List<EventHandler>();
                eventHandlerLookup.Add(eventType, eventHandlers);
            }

            eventHandlers.Add(eventHandlerToAdd);

            eventManager.AddEventListener(eventType, this);
        }

        /// <summary>
        /// Remove an event handler.
        /// </summary>
        public void RemoveEventHandler(string eventType, EventHandler eventHandlerToRemove)
        {
            List<EventHandler> eventHandlers;
            bool eventTypeFound = eventHandlerLookup.TryGetValue(eventType, out eventHandlers);

            if (!eventTypeFound)
            {
                return;
            }

            eventHandlers.Remove(eventHandlerToRemove);

            if (eventHandlers.Count == 0)
            {
                eventManager.RemoveEventListener(eventType, this);
            }
        }

        #endregion
    }
}
