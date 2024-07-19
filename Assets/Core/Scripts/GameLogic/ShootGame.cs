using System.Collections.Generic;
using CaseWixot.Core.Scripts.Interfaces;
using CaseWixot.Core.Scripts.PowerUps;
using CaseWixot.Core.Scripts.Services;
using CaseWixot.Core.Scripts.UI;
using CaseWixot.Core.Scripts.UI.PopUps;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CaseWixot.Core.Scripts
{
    public sealed class ShootGame : MonoBehaviour
    {
        //Will be moved to asset management
        [SerializeField] private CameraHandler _camera;
        [SerializeField] private InputAction _positionInput;
        [SerializeField] private InputAction _pressInput;
        
        private IPoolService _poolService;
        private IAssetService _assetService;
        private IPopUpProvider _popUpProvider;
        private IWindowProvider _windowProvider;

        private GameLoader _loader;
        private List<IActiveEntity> _activeEntities;

        public void InitGame(GameLoader loader,
            IAssetService assetService, 
            IPoolService poolService,
            IPopUpProvider popUpProvider,
            IWindowProvider windowProvider)
        {
            _activeEntities = new List<IActiveEntity>();
            _loader = loader;
            _assetService = assetService;
            _poolService = poolService;
            _popUpProvider = popUpProvider;
            _windowProvider = windowProvider;
            popUpProvider.ShowPopUp(PopUpKey.StartGamePopUp, new StartGamePopUpContext(OnGameStart));
        }
        
        private void OnGameStart()
        {
            Player player = _assetService.Instantiate(GameAssets.Player, transform, true).GetComponent<Player>();
            _activeEntities.Add(player);

            IProjectileFactory fastProjectileFactory = new FastProjectileFactory(_poolService);
            IProjectileFactory projectileFactory = new ProjectileFactory(_poolService);

            IModifiableStat<int> speed = new SpeedStat(1);
            IMoveComponent moveComponent = new MovementComponent(player.transform, speed, _positionInput, _pressInput);

            IModifiableStat<float> fireInterval = new FireIntervalStat(2f);
            IWeapon weapon = new Weapon(fireInterval, new BasicFire(), projectileFactory);

            IPowerUpFactory powerUpFactory =
                new PowerUpFactory(weapon, speed, fireInterval, projectileFactory, fastProjectileFactory);

            IPowerUpDeck powerUpDeck = new PowerUpDeck(powerUpFactory.GenerateAll());

            _windowProvider.OpenWindow(WindowKey.GameWindow, new GameWindowContext(powerUpDeck.OnPowerUpToggled, OnExitButton));
            player.InitPlayer(weapon, moveComponent, powerUpDeck);
            _camera.InitCamera(moveComponent);
        }

        private void OnExitButton()
        {
            foreach (var activeEntity in _activeEntities)
            {
                activeEntity.Deactivate();
            }
            _popUpProvider.ShowPopUp(PopUpKey.EndGamePopUp, new EndGamePopUpContext(ReturnToMainMenu, ReloadGame));
            _windowProvider.CloseWindow(WindowKey.GameWindow);
            _positionInput.Disable();
            _pressInput.Disable();
        }

        private void ReturnToMainMenu() => _loader.RemoveGame(this);

        private void ReloadGame() => _loader.ReloadGame(this);
    }
}