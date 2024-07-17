using System;
using System.Collections.Generic;
using CaseWixot.Core.Scripts.Services;
using CaseWixot.Core.Scripts.UI.PopUps;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CaseWixot.Core.Scripts
{
    public class PopUpProvider : IPopUpProvider
    {
        private readonly Dictionary<PopUpKey, UIPopUp> _popUps;
        private readonly Transform _popUpParent;
        private readonly Transform _poolParent;
        
        public PopUpProvider(IAssetService assetService, Transform popUpParent, Transform poolParent)
        {
            _popUpParent = popUpParent;
            _poolParent = poolParent;
            _popUps = new Dictionary<PopUpKey, UIPopUp>();

            foreach (PopUpKey popUpKey in Enum.GetValues(typeof(PopUpKey)))
            {
                UIPopUp prefab = assetService.GetAsset<UIPopUp>(popUpKey);
                UIPopUp instance = Object.Instantiate(prefab, poolParent, true);
                _popUps.Add(popUpKey, instance);
            }
        }

        public void ShowPopUp(PopUpKey key, PopUpDefinition definition = null)
        {
            if (_popUps.TryGetValue(key, out UIPopUp popUp))
            {
                popUp.transform.SetParent(_popUpParent);
                popUp.Show(definition);
            }
        }

        public void HidePopUp(PopUpKey key)
        {
            if (_popUps.TryGetValue(key, out UIPopUp popUp))
            {
                popUp.transform.SetParent(_poolParent);
                popUp.Hide();
            }
        }
    }
}