using CaseWixot.Core.Scripts.UI.PopUps;

namespace CaseWixot.Core.Scripts
{
    public interface IPopUpProvider
    {
        void ShowPopUp(PopUpKey key, PopUpDefinition definition = null);
        void HidePopUp(PopUpKey key);
    }
}