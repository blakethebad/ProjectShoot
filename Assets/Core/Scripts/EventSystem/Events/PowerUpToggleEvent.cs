namespace CaseWixot.Core.Scripts.EventSystem.Events
{
    public struct PowerUpToggleEvent : IEvent
    {
        public int EnabledIndex;
        public int DisabledIndex;
    }

    public struct PowerUpDeckEvent : IEvent
    {
        public int Index;

        public PowerUpDeckEvent(int index)
        {
            Index = index;
        }
    }
}