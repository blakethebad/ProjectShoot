using CaseWixot.Core.Scripts.UI.PopUps;

namespace CaseWixot.Core.Scripts
{
    public interface IPopUpProvider
    {
        void ShowPopUp(PopUpKey key, PopUpContext context = null);
        void HidePopUp(PopUpKey key);
    }
}