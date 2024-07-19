using UnityEngine;

namespace ProjectShoot.Core.UI.Windows
{
    public abstract class UIWindow : MonoBehaviour
    {
        public abstract void Open(WindowContext context);
        public abstract void Close();
    }
}