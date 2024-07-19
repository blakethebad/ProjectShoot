using System;

namespace ProjectShoot.Core.UI.Windows.Context
{
    public class MainMenuContext : WindowContext
    {
        public Action OnMainMenuPressed;

        public MainMenuContext(Action onMainMenuPressed)
        {
            OnMainMenuPressed = onMainMenuPressed;
        }
    }
}