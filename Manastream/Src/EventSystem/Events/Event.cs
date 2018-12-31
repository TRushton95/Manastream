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
        public Event(string eventType)
        {
            this.EventType = eventType;
        }
        
        public string EventType
        {
            get;
        }
    }
}
