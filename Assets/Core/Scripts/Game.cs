using CaseWixot.Core.Scripts.Interfaces;
using CaseWixot.Core.Scripts.PowerUps;
using CaseWixot.Core.Scripts.UI;
using UnityEngine;

namespace CaseWixot.Core.Scripts
{
    public class Game : MonoBehaviour
    {
        //Will be moved to asset management
        [SerializeField] private Transform _playerPrefab;
        [SerializeField] private Transform _projectilePrefab;
        [SerializeField] private GameWindow _gameWindow;
        //Will be moved to asset management

        private Player _activePlayer;

        private void Start()
        {
            Transform player = Instantiate(_playerPrefab);
            _activePlayer = player.GetComponent<Player>();

            IProjectileFactory projectileFactory = new ProjectileFactory(_projectilePrefab);
            IProjectileFactory fastProjectileFactory = new FastProjectileFactory(_projectilePrefab);
            IWeapon weapon = new Weapon();
            weapon.SetBulletProvider(projectileFactory);
            IMoveHandler moveHandler = new MovementHandler(player);
            
            IPowerUp fastBulletBooster = new BulletSpeedBooster(weapon, projectileFactory, fastProjectileFactory);
            IPowerUp speedBooster = new SpeedBooster(moveHandler);
            IPowerUp coneShotBooster = new ConeShotBooster(weapon);
            IPowerUp doubleShotBooster = new DoubleShotBooster(weapon);
            IPowerUp shotIntervalBooster = new ShotIntervalBooster(weapon);
            
            _activePlayer.InitPlayer(_gameWindow.PowerUpPublisher, weapon, moveHandler, 
                fastBulletBooster, speedBooster, coneShotBooster, doubleShotBooster, shotIntervalBooster);
        }
    }
}