namespace Manastream.Src.EventSystem
{
    /// <summary>
    /// The event types provided as constants
    /// </summary>
    public class EventTypes
    {
        /// <summary>
        /// The debug events
        /// </summary>
        public class Debug
        {
            public const string NewTurn = "DBG_NEW_TURN";

            public const string NewPlayerTurn = "DBG_NEW_PLAYER_TURN";

            public const string HighlightUnit = "DBG_HIGHLIGHT_UNIT";

            public const string SelectUnit = "DBG_SELECT_UNIT";

            public const string UserAlert = "DBG_USER_ALERT";
        }

        /// <summary>
        /// The mouse events
        /// </summary>
        public class Mouse
        {
            public const string MouseMoved = "MS_MOUSE_MOVED";

            public const string LeftMousePressed = "MS_LEFT_MOUSE_PRESSED";

            public const string RightMousePressed = "MS_RIGHT_MOUSE_PRESSED";

            public const string LeftMouseReleased = "MS_LEFT_MOUSE_RELEASED";

            public const string RightMouseReleased = "MS_RIGHT_MOUSE_RELEASED";

            public const string LeftMouseDragged = "MS_LEFT_MOUSE_DRAGGED";

            public const string RightMouseDragged = "MS_RIGHT_MOUSE_DRAGGED";
        }
    }
}
