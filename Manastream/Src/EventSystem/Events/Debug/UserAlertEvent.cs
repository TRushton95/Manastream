namespace Manastream.Src.EventSystem.Events.Debug
{
    /// <summary>
    /// The user alert event.
    /// <para>This event is for when pushing alerts to the user interface is the only
    /// required behaviour - this is to reduce overhead in creating an event for every
    /// scenario that will involve notifying the user only.</para>
    /// </summary>
    public class UserAlertEvent : Event
    {
        public UserAlertEvent(string message)
            : base(EventTypes.Debug.UserAlert)
        {
            this.Message = message;
        }

        public string Message
        {
            get;
        }
    }
}
