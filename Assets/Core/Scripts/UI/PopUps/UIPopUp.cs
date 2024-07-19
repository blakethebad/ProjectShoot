using UnityEngine;

namespace CaseWixot.Core.Scripts.UI.PopUps
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