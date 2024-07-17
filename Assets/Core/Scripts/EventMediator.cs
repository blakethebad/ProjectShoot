using CaseWixot.Core.Scripts.EventSystem;
using CaseWixot.Core.Scripts.EventSystem.Events;

namespace CaseWixot.Core.Scripts
{
    public static class EventMediator
    {
        public static IEventBinder<PowerUpEvent> PowerUpEnableEvent;
        public static IEventBinder<PowerUpEvent> PowerUpDisableEvent;

        public static void Init()
        {
            PowerUpEnableEvent = new EventBinder<PowerUpEvent>();
            PowerUpDisableEvent = new EventBinder<PowerUpEvent>();
        }
    }

}