using System;
using ProjectShoot.Core.UI.Windows;
using UnityEngine;

namespace ProjectShoot.Core.UI.Panels
{
    public abstract class UIPanel : MonoBehaviour
    {
        public Action OnClose;
        public abstract void Open(WindowContext windowContext);
        public abstract void Close();
    }

    public interface IUIPublisher
    {
        
    }
}