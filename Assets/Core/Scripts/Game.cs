using System;
using System.Collections.Generic;
using CaseWixot.Core.Scripts.Interfaces;
using CaseWixot.Core.Scripts.PowerUps;
using CaseWixot.Core.Scripts.States;
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

        private BaseGameState _currentState;
        private Dictionary<GameState, BaseGameState> _states;

        private void Start()
        {
            _states = new Dictionary<GameState, BaseGameState>()
            {
                {GameState.Intro, new IntroState(ChangeState)},
                {GameState.Player, new PlayerState(ChangeState)},
                {GameState.EndGame, new EndGameState(ChangeState)}
            };
            _currentState = _states[GameState.Intro];
            _currentState.EnterState();
            
            Transform player = Instantiate(_playerPrefab);
            _activePlayer = player.GetComponent<Player>();

            IProjectileFactory projectileFactory = new ProjectileFactory(_projectilePrefab);
            IProjectileFactory fastProjectileFactory = new FastProjectileFactory(_projectilePrefab);
            IWeapon weapon = new Weapon();
            weapon.SetBulletProvider(projectileFactory);
            weapon.SetStrategy(new BasicFire());
            
            IMoveHandler moveHandler = new MovementHandler(player);
            
            IPowerUp fastBulletBooster = new BulletSpeedBooster(weapon, projectileFactory, fastProjectileFactory);
            IPowerUp speedBooster = new SpeedBooster(moveHandler);
            IPowerUp coneShotBooster = new ConeShotBooster(weapon);
            IPowerUp doubleShotBooster = new DoubleShotBooster(weapon);
            IPowerUp shotIntervalBooster = new ShotIntervalBooster(weapon);
            
            _activePlayer.InitPlayer(weapon, moveHandler, 
                fastBulletBooster, speedBooster, coneShotBooster, doubleShotBooster, shotIntervalBooster);
        }
        
        

        private void ChangeState(GameState desiredType)
        {
            _currentState.ExitState();
            if (_states.TryGetValue(desiredType, out BaseGameState desiredState))
            {
                _currentState = desiredState;
            }
            _currentState.EnterState();
        }
    }
}