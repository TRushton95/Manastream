namespace Manastream.Src.EventSystem
{
    /// <summary>
    /// The event types provided with default ids.
    /// </summary>
    public class EventTypes
    {
        /// <summary>
        /// The debug events.
        /// </summary>
        public class Debug
        {
            public static EventType NewTurn = new EventType("DBG_NEW_TURN");

            public static EventType NewPlayerTurn = new EventType("DBG_NEW_PLAYER_TURN");

            public static EventType HighlightUnit = new EventType("DBG_HIGHLIGHT_UNIT");

            public static EventType SelectUnit = new EventType("DBG_SELECT_UNIT");

            public static EventType UserAlert = new EventType("DBG_USER_ALERT");
        }

        /// <summary>
        /// The mouse events.
        /// </summary>
        public class Mouse
        {
            public static EventType MouseMoved = new EventType("MS_MOUSE_MOVED");

            public static EventType LeftMousePressed = new EventType("MS_LEFT_MOUSE_PRESSED");

            public static EventType RightMousePressed = new EventType("MS_RIGHT_MOUSE_PRESSED");

            public static EventType LeftMouseReleased = new EventType("MS_LEFT_MOUSE_RELEASED");

            public static EventType RightMouseReleased = new EventType("MS_RIGHT_MOUSE_RELEASED");

            public static EventType LeftMouseDragged = new EventType("MS_LEFT_MOUSE_DRAGGED");

            public EventType RightMouseDragged = new EventType("MS_RIGHT_MOUSE_DRAGGED");
        }

        /// <summary>
        /// The game events.
        /// </summary>
        public class Game
        {
            public static EventType EndTurn = new EventType("GM_END_TURN");

            public static EventType UnitSpawn = new EventType("GM_UNIT_SPAWN");
        }

        /// <summary>
        /// The graphics events.
        /// </summary>
        public class Graphics
        {
            public static EventType TextureDrawReady = new EventType("GFX_TEXTURE_DRAW_READY");

            public static EventType StringDrawReady = new EventType("GFX_STRING_DRAW_READY");
        }
    }
}
