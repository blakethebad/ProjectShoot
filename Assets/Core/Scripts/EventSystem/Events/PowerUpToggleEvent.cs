namespace CaseWixot.Core.Scripts.EventSystem.Events
{
    public struct PowerUpToggleEvent : IEvent
    {
        public int EnabledIndex;
        public int DisabledIndex;
    }
}