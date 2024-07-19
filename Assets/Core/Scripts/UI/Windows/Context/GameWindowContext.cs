using System;

namespace CaseWixot.Core.Scripts.UI
{
    public class GameWindowContext : WindowContext
    {
        public Action<int> PowerUpButtonPressed;
        public Action OnExitButtonPressed;

        public GameWindowContext(Action<int> onPowerUpPressed, Action onExitPressed)
        {
            PowerUpButtonPressed = onPowerUpPressed;
            OnExitButtonPressed = onExitPressed;
        }
    }
}