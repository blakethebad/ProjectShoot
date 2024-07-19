namespace CaseWixot.Core.Scripts.EventSystem.Events
{
    public struct PowerUpDeckEvent : IEvent
    {
        public int Index;

        public PowerUpDeckEvent(int index)
        {
            Index = index;
        }
    }
}