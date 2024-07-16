using UnityEngine;

namespace CaseWixot.Core.Scripts.UI
{
    public abstract class UIWindow : MonoBehaviour
    {
        public abstract void Open();
        public abstract void Close();
    }
}