using System;
using System.Collections.Generic;
using CaseWixot.Core.Scripts.Services;
using CaseWixot.Core.Scripts.UI;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CaseWixot.Core.Scripts
{
    public class WindowProvider : IWindowProvider
    {
        private readonly Dictionary<WindowKey, UIWindow> _windows;
        private readonly Transform _windowParent;
        private readonly Transform _poolParent;

        public WindowProvider(IAssetService assetService, Transform windowParent, Transform poolParent)
        {
            _windowParent = windowParent;
            _poolParent = poolParent;
            _windows = new Dictionary<WindowKey, UIWindow>();

            foreach (WindowKey windowKey in Enum.GetValues(typeof(WindowKey)))
            {
                GameObject prefab = assetService.GetAsset<GameObject>(windowKey);
                UIWindow instance = Object.Instantiate(prefab, _poolParent, true).GetComponent<UIWindow>();
                _windows.Add(windowKey, instance);
            }
        }

        public void OpenWindow(WindowKey key, WindowContext context = null)
        {
            if (!_windows.TryGetValue(key, out UIWindow window)) return;
            window.transform.SetParent(_windowParent);
            window.Open(context);
        }

        public void CloseWindow(WindowKey key)
        {
            if (!_windows.TryGetValue(key, out UIWindow window)) return;
            window.transform.SetParent(_poolParent);
            window.Close();
        }
    }
}