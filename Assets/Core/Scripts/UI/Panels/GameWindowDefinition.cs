using System;

namespace CaseWixot.Core.Scripts.UI
{
    public class GameWindowDefinition : WindowDefinition
    {
        public Action<int> PowerUpButtonPressed;
        public Action OnExitButtonPressed;

        public GameWindowDefinition(Action<int> onPowerUpPressed, Action onExitPressed)
        {
            PowerUpButtonPressed = onPowerUpPressed;
            OnExitButtonPressed = onExitPressed;
        }
    }
}