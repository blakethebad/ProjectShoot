using System;

namespace CaseWixot.Core.Scripts.UI.PopUps
{
    public class EndGamePopUpContext : PopUpContext
    {
        public Action OnMainMenuPressed;
        public Action OnRetryPressed;

        public EndGamePopUpContext(Action onMainMenuPressed, Action onRetryPressed)
        {
            OnMainMenuPressed = onMainMenuPressed;
            OnRetryPressed = onRetryPressed;
        }
    }
}