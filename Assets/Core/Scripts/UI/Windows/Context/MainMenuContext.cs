using System;

namespace CaseWixot.Core.Scripts.UI
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