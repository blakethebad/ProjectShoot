using System;

namespace CaseWixot.Core.Scripts.UI.PopUps
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