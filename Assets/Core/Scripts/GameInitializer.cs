using System;
using System.Collections.Generic;
using CaseWixot.Core.Scripts.Services;
using CaseWixot.Core.Scripts.UI;
using CaseWixot.Core.Scripts.UI.PopUps;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

namespace CaseWixot.Core.Scripts
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private Transform _playerPrefab;
        [SerializeField] private Transform _projectilePrefab;
        [SerializeField] private Transform _fastProjectilePrefab;
        [SerializeField] private UIWindow _gameWindow;
        [SerializeField] private UIWindow _mainMenuWindow;
        [SerializeField] private UIPopUp _startGamePopUp;
        [SerializeField] private UIPopUp _endGamePopUp;

        [SerializeField] private Camera _menuCamera;
        [SerializeField] private Transform _persistentUI;

        [SerializeField] private Transform _poolTransform;
        [FormerlySerializedAs("_game")] [SerializeField] private ShootGame shootGame;

        private IAssetService _assetService;
        private IPoolService _poolService;
        
        private IPopUpProvider _popUpProvider;
        private IWindowProvider _windowProvider;
        
        private void Awake()
        {
            EventMediator.Init();
            _assetService = new AssetService(_gameWindow, _mainMenuWindow, _startGamePopUp, _endGamePopUp);
            _poolService = new PoolService(_poolTransform, new Dictionary<string, GameObject>()
            {

                {"pref_fastProjectile", _fastProjectilePrefab.gameObject},
                {"pref_projectile", _projectilePrefab.gameObject},
                {"pref_player", _playerPrefab.gameObject}
            });

            _popUpProvider = new PopUpProvider(_assetService, _persistentUI, _poolTransform);
            _windowProvider = new WindowProvider(_assetService, _persistentUI, _poolTransform);

            _poolService.Init((() =>
            {
                Debug.LogError("Init Complete");
            }));


            _windowProvider.OpenWindow(WindowKey.MainMenuWindow, new MainMenuDefinition(OnPlayPressed));

            void OnPlayPressed()
            {
                ShootGame shootGame = Object.Instantiate(this.shootGame);
                shootGame.InitGame(_poolService, _popUpProvider, _windowProvider);
                _menuCamera.gameObject.SetActive(false);
                _windowProvider.CloseWindow(WindowKey.MainMenuWindow);
            }
        }
    }
}