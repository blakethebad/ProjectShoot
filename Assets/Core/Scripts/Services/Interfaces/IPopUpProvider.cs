using ProjectShoot.Core.Enums;
using ProjectShoot.Core.UI.PopUps;

namespace ProjectShoot.Core.Services.Interfaces
{
    public interface IPopUpProvider
    {
        void ShowPopUp(PopUpKey key, PopUpContext context = null);
        void HidePopUp(PopUpKey key);
    }
}