namespace Manastream.Src.EventSystem
{
    /// <summary>
    /// The event type class.
    /// </summary>
    public class EventType
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="EventType"/> class.
        /// </summary>
        public EventType(string name)
        {
            this.Name = name;
            this.Id = -1;
        }

        public string Name
        {
            get;
        }

        public int Id
        {
            get;
            set;
        }
    }
}
