using CaseWixot.Core.Scripts.EventSystem;
using CaseWixot.Core.Scripts.EventSystem.Events;

namespace CaseWixot.Core.Scripts
{
    public static class GameEvents
    {
        public static IEventBinder<PowerUpToggleEvent> PowerUpEnableEvent;
        public static IEventBinder<PowerUpToggleEvent> PowerUpDisableEvent;
        public static IEventBinder<PowerUpDeckEvent> PowerUpAddedEvent;

        public static void Init()
        {
            PowerUpEnableEvent = new EventBinder<PowerUpToggleEvent>();
            PowerUpDisableEvent = new EventBinder<PowerUpToggleEvent>();

            PowerUpAddedEvent = new EventBinder<PowerUpDeckEvent>();
        }
    }

}