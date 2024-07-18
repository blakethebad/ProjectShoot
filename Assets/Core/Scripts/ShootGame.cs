using CaseWixot.Core.Scripts.Interfaces;
using CaseWixot.Core.Scripts.PowerUps;
using CaseWixot.Core.Scripts.Services;
using CaseWixot.Core.Scripts.UI;
using CaseWixot.Core.Scripts.UI.PopUps;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CaseWixot.Core.Scripts
{
    public class ShootGame : MonoBehaviour
    {
        //Will be moved to asset management
        [SerializeField] private CameraHandler _camera;
        [SerializeField] private InputAction _positionInput;
        [SerializeField] private InputAction _pressInput;
        
        private IPoolService _poolService;
        private IPopUpProvider _popUpProvider;
        private IWindowProvider _windowProvider;
        
        public void InitGame(IPoolService poolService, IPopUpProvider popUpProvider, IWindowProvider windowProvider)
        {
            _poolService = poolService;
            _popUpProvider = popUpProvider;
            _windowProvider = windowProvider;
            popUpProvider.ShowPopUp(PopUpKey.StartGame, new StartGamePopUpDefinition(OnGameStart));
        }
        
        private void OnGameStart()
        {
            Player player = _poolService.GetAssetWithComponent<Player>("pref_player");
            player.gameObject.SetActive(true);

            IProjectileFactory fastProjectileFactory = new FastProjectileFactory(_poolService);
            IProjectileFactory projectileFactory = new ProjectileFactory(_poolService);

            IModifiableStat<int> speed = new SpeedStat(1);
            IMoveComponent moveComponent = new MovementComponent(player.transform, speed, _positionInput, _pressInput);

            IModifiableStat<float> fireInterval = new FireIntervalStat(2f);
            IWeapon weapon = new Weapon(fireInterval, new BasicFire(), projectileFactory);

            IPowerUp[] powerUps = new IPowerUp[5];
            powerUps[0] = new SpeedPowerUp(speed, 0);
            powerUps[1] = new FireIntervalPowerUp(fireInterval, 1);
            powerUps[2] = new BulletSpeedPowerUp(weapon, 2, projectileFactory, fastProjectileFactory);
            powerUps[3] = new ConeFirePowerUp(weapon, 3);
            powerUps[4] = new DoubleFirePowerUp(weapon, 4);

            Debug.LogError(powerUps.Length);
            IPowerUpDeck powerUpDeck = new PowerUpDeck(powerUps);

            _windowProvider.OpenWindow(WindowKey.GameWindow, new GameWindowDefinition(powerUpDeck.OnPowerUpToggled, OnExitButton));
            player.InitPlayer(weapon, moveComponent, powerUpDeck);
            _camera.InitCamera(moveComponent);
        }

        private void OnExitButton()
        {
            _popUpProvider.ShowPopUp(PopUpKey.EndGame, new EndGamePopUpDefinition(UnloadGame, ReloadGame));
            _windowProvider.CloseWindow(WindowKey.GameWindow);
            _positionInput.Disable();
            _pressInput.Disable();
        }

        private void UnloadGame()
        {
            //Unload
        }

        private void ReloadGame()
        {
            //Reload game
        }

    }

    public class FireIntervalStat : IModifiableStat<float>
    {
        private float _initialValue;
        private float _currentValue;
        public FireIntervalStat(float f)
        {
            _initialValue = f;
            _currentValue = _initialValue;
        }
        
        void IModifiableStat<float>.Modify(float modifiedValue) => _currentValue = modifiedValue;

        float IModifiableStat<float>.Get() => _currentValue;

        void IModifiableStat<float>.Clear()
        {
            _currentValue = _initialValue;
        }
    }
}