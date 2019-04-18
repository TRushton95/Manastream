namespace Manastream.Src.UI
{
    #region Usings

    using Manastream.Src.EventSystem;
    using Manastream.Src.EventSystem.Events.Game;

    #endregion

    public class UIEventBeacon : Listener
    {
        #region Fields

        private UIEventBeacon instance;

        #endregion

        #region Properties

        public UIEventBeacon Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UIEventBeacon();
                }

                return instance;
            }
        }

        #endregion

        #region Methods

        public void SendEndTurnEvent()
        {
            eventManager.Notify(new EndTurnEvent());
        }

        #endregion
    }
}
