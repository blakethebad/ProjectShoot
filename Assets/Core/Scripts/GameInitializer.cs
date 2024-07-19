using System;
using System.Collections.Generic;
using CaseWixot.Core.Scripts.Services;
using CaseWixot.Core.Scripts.UI.PopUps;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

namespace CaseWixot.Core.Scripts
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private Transform _persistentUI;
        [SerializeField] private Transform _poolTransform;
        private GameLoader _gameLoader;
        
        private void Awake()
        {
            _gameLoader = GetComponent<GameLoader>();
            GameEvents.Init();
            IAssetService assetService = new AssetService();
            IPoolService poolService = new PoolService(assetService, _poolTransform);

            assetService.Init((() =>
            {
                poolService.Init((() =>
                {
                    IWindowProvider windowProvider = new WindowProvider(assetService, _persistentUI, _poolTransform);
                    IPopUpProvider popUpProvider = new PopUpProvider(assetService, _persistentUI, _poolTransform);
                    
                    _gameLoader.StartLoader(assetService, poolService, windowProvider, popUpProvider);
                }));
            }));
        }
    }
}