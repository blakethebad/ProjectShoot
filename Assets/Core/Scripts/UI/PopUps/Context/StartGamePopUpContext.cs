using System;

namespace ProjectShoot.Core.UI.PopUps.Context
{
    public class StartGamePopUpContext : PopUpContext
    {
        public Action OnScreenTap;
        public StartGamePopUpContext(Action onScreenTap)
        {
            OnScreenTap = onScreenTap;
        }
    }
}