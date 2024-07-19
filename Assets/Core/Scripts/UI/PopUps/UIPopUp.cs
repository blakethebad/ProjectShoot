using UnityEngine;

namespace ProjectShoot.Core.UI.PopUps
{
    public abstract class PopUpContext
    {
    }
    public abstract class UIPopUp : MonoBehaviour
    {
        public abstract void Show(PopUpContext popUpContext);
        public abstract void Hide();
    }
}