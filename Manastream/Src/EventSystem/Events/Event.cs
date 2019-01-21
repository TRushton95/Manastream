namespace Manastream.Src.EventSystem.Events
{
    /// <summary>
    /// The event base class.
    /// </summary>
    public abstract class Event
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="Event"/> class.
        /// </summary>
        public Event(EventType eventType)
        {
            this.EventType = eventType;
        }
        
        public EventType EventType
        {
            get;
        }
    }
}
