using CaseWixot.Core.Scripts.Services;
using CaseWixot.Core.Scripts.UI;
using UnityEngine;

namespace CaseWixot.Core.Scripts
{
    public sealed class GameLoader : MonoBehaviour
    {
        [SerializeField] private Camera _menuCamera;
        [SerializeField] private ShootGame _shootGame;

        private IAssetService _assetService;
        private IPoolService _poolService;
        private IWindowProvider _windowProvider;
        private IPopUpProvider _popUpProvider;
        public void StartLoader(
            IAssetService assetService, 
            IPoolService poolService, 
            IWindowProvider windowProvider,
            IPopUpProvider popUpProvider)
        {
            _assetService = assetService;
            _poolService = poolService;
            _windowProvider = windowProvider;
            _popUpProvider = popUpProvider;
            
            _windowProvider.OpenWindow(WindowKey.MainMenuWindow, new MainMenuContext(LoadGame));
        }

        public void LoadGame()
        {
            ShootGame shootGame = Object.Instantiate(_shootGame);
            shootGame.InitGame(this, _assetService, _poolService, _popUpProvider, _windowProvider);
            _menuCamera.gameObject.SetActive(false);
            _windowProvider.CloseWindow(WindowKey.MainMenuWindow);
        }

        public void ReloadGame(ShootGame game)
        {
            Destroy(game.gameObject);
            LoadGame();
        }

        public void RemoveGame(ShootGame game)
        {
            Destroy(game.gameObject);
            _menuCamera.gameObject.SetActive(true);
            _windowProvider.OpenWindow(WindowKey.MainMenuWindow, new MainMenuContext(LoadGame));
        }
        
        
    }
}