namespace CaseWixot.Core.Scripts.EventSystem.Events
{
    public struct PowerUpEvent : IEvent
    {
        public int EnabledIndex;
        public int DisabledIndex;
    }
}