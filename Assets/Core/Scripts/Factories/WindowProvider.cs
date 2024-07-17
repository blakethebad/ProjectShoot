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
                UIWindow prefab = assetService.GetAsset<UIWindow>(windowKey);
                UIWindow instance = Object.Instantiate(prefab, _poolParent, true);
                _windows.Add(windowKey, instance);
            }
        }

        public void OpenWindow(WindowKey key, WindowDefinition definition = null)
        {
            if (_windows.TryGetValue(key, out UIWindow window))
            {
                window.transform.SetParent(_windowParent);
                window.Open(definition);
            }
        }

        public void CloseWindow(WindowKey key)
        {
            if (_windows.TryGetValue(key, out UIWindow window))
            {
                window.transform.SetParent(_poolParent);
                window.Close();
            }
        }
    }
}