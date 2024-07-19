using System;

namespace ProjectShoot.Core.UI.Windows.Context
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