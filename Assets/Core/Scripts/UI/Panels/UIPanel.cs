using System;
using UnityEngine;

namespace CaseWixot.Core.Scripts.UI
{
    public abstract class UIPanel : MonoBehaviour
    {
        public Action OnClose;
        public abstract void Open();
        public abstract void Close();
    }

    public interface IUIPublisher
    {
        
    }
}