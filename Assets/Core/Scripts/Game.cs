using System;
using System.Collections.Generic;
using CaseWixot.Core.Scripts.Interfaces;
using CaseWixot.Core.Scripts.PowerUps;
using CaseWixot.Core.Scripts.States;
using CaseWixot.Core.Scripts.UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CaseWixot.Core.Scripts
{
    public class Game : MonoBehaviour
    {
        //Will be moved to asset management
        [SerializeField] private CameraHandler _camera;
        [SerializeField] private Transform _playerPrefab;
        [SerializeField] private Transform _projectilePrefab;
        [SerializeField] private GameWindow _gameWindow;
        [SerializeField] private InputAction _positionInput;
        [SerializeField] private InputAction _pressInput;

        private Player _activePlayer;

        private BaseGameState _currentState;
        private Dictionary<GameState, BaseGameState> _states;

        private void Start()
        {
            _states = new Dictionary<GameState, BaseGameState>()
            {
                {GameState.Intro, new IntroState(ChangeState, OnGameStart)},
                {GameState.Player, new PlayerState(ChangeState)},
                {GameState.EndGame, new EndGameState(ChangeState)}
            };
            _currentState = _states[GameState.Intro];
            _currentState.EnterState();
            
            OnGameStart();
        }

        private void OnGameStart()
        {
            Transform player = Instantiate(_playerPrefab); //Get from pool
            _activePlayer = player.GetComponent<Player>();

            IWeapon weapon = new Weapon();
            IWeaponStrategy basicStrategy = new BasicFire();
            IWeaponStrategy coneStrategy = new ConeFire();
            
            IProjectileFactory projectileFactory = new ProjectileFactory(_projectilePrefab);
            IProjectileFactory fastProjectileFactory = new FastProjectileFactory(_projectilePrefab);
            
            IMoveHandler moveHandler = new MovementHandler(player, _positionInput, _pressInput);
            
            IPowerUp fastBulletBooster = new BulletSpeedBooster(weapon, projectileFactory, fastProjectileFactory);
            IPowerUp speedBooster = new SpeedBooster(moveHandler);
            IPowerUp coneShotBooster = new ConeShotBooster(weapon, basicStrategy, coneStrategy);
            IPowerUp doubleShotBooster = new DoubleShotBooster(weapon);
            IPowerUp shotIntervalBooster = new ShotIntervalBooster(weapon);
            
            weapon.SetBulletProvider(projectileFactory);
            weapon.SetStrategy(basicStrategy);
            
            _activePlayer.InitPlayer(weapon, moveHandler, 
                fastBulletBooster, speedBooster, 
                coneShotBooster, doubleShotBooster, shotIntervalBooster);
            _camera.InitCamera(moveHandler);
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