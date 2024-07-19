namespace ProjectShoot.Core.EventSystem.Events
{
    public struct PowerUpToggleEvent : IEvent
    {
        public int EnabledIndex;
        public int DisabledIndex;
    }
}