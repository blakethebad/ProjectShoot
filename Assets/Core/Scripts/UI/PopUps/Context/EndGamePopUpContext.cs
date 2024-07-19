using System;

namespace ProjectShoot.Core.UI.PopUps.Context
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