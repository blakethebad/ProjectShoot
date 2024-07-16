using UnityEngine;

namespace CaseWixot.Core.Scripts.UI.PopUps
{
    public abstract class UIPopUp : MonoBehaviour
    {
        public abstract void Show(PopUpContext endGameContext = null);

        public abstract void Hide();
    }
}