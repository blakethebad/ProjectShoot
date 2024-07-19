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
                GameObject prefab = assetService.GetAsset<GameObject>(popUpKey);
                UIPopUp instance = Object.Instantiate(prefab, poolParent, true).GetComponent<UIPopUp>();
                _popUps.Add(popUpKey, instance);
            }
        }

        public void ShowPopUp(PopUpKey key, PopUpContext context = null)
        {
            if (!_popUps.TryGetValue(key, out UIPopUp popUp)) return;
            popUp.transform.SetParent(_popUpParent);
            popUp.Show(context);
        }

        public void HidePopUp(PopUpKey key)
        {
            if (!_popUps.TryGetValue(key, out UIPopUp popUp)) return;
            
            popUp.transform.SetParent(_poolParent);
            popUp.Hide();
        }
    }
}