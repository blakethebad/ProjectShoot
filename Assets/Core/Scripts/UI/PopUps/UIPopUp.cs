using UnityEngine;

namespace CaseWixot.Core.Scripts.UI.PopUps
{
    public abstract class UIPopUp : MonoBehaviour
    {
        public abstract void Show(PopUpDefinition popUpDefinition);
        public abstract void Hide();
    }
}