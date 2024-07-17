using System;
using System.Collections.Generic;
using CaseWixot.Core.Scripts.Interfaces;
using CaseWixot.Core.Scripts.PowerUps;
using CaseWixot.Core.Scripts.States;
using CaseWixot.Core.Scripts.UI;
using CaseWixot.Core.Scripts.UI.PopUps;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace CaseWixot.Core.Scripts
{
    public class Game : MonoBehaviour
    {
        //Will be moved to asset management
        [SerializeField] private Transform _playerPrefab;
        [SerializeField] private Transform _projectilePrefab;
        [SerializeField] private Transform _fastProjectilePrefab;
        [SerializeField] private GameWindow _gameWindow;
        [SerializeField] private MainMenuWindow _mainMenuWindow;
        [SerializeField] private StartGamePopUp _startGamePopUp;
        [SerializeField] private EndGamePopUp _endGamePopUp;

        
        [SerializeField] private CameraHandler _camera;
        [SerializeField] private InputAction _positionInput;
        [SerializeField] private InputAction _pressInput;


        private BaseGameState _currentState;
        private Dictionary<GameState, BaseGameState> _states;
        private List<IActiveEntity> _gameEntities = new List<IActiveEntity>();

        private IPopUpFactory _popUpFactory;
        private IWindowFactory _windowFactory;

        private void Start()
        {
            _popUpFactory = new PopUpFactory(_startGamePopUp, _endGamePopUp);
            _windowFactory = new WindowFactory(_gameWindow, _mainMenuWindow);
            _states = new Dictionary<GameState, BaseGameState>()
            {
                {GameState.Intro, new IntroState(ChangeState, OnGameStart, _popUpFactory)},
                {GameState.Player, new PlayerState(ChangeState, this)},
                {GameState.EndGame, new EndGameState(ChangeState, _popUpFactory)}
            };
            _currentState = _states[GameState.Intro];
            _currentState.EnterState();
        }
        
        private void OnGameStart()
        {
            _windowFactory.Pull(WindowKey.GameWindow);
            Transform playerObject = Instantiate(_playerPrefab); //Get from pool
            Player player = playerObject.GetComponent<Player>();

            IWeaponStrategy basicStrategy = new BasicFire();
            IWeaponStrategy coneStrategy = new ConeFire();
            
            IProjectileFactory projectileFactory = new ProjectileFactory(_projectilePrefab);
            IProjectileFactory fastProjectileFactory = new FastProjectileFactory(_fastProjectilePrefab);
            
            IWeapon weapon = new Weapon(basicStrategy, projectileFactory);

            IMoveHandler moveHandler = new MovementHandler(player.transform, _positionInput, _pressInput);
            IPowerUpFactory powerUpFactory = new PowerUpFactory(moveHandler, weapon, projectileFactory,
                fastProjectileFactory, basicStrategy, coneStrategy);
            
            _gameEntities.Add(player);
            player.InitPlayer(weapon, moveHandler, powerUpFactory.GenerateAll());
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

        private void OnRestart()
        {
            SceneManager.UnloadSceneAsync(0);
            SceneManager.LoadScene(0);
        }

        private void OnTimerEnd()
        {
            foreach (IActiveEntity entity in _gameEntities)
            {
                entity.Deactivate();
            }
        }
    }


    public interface ISubject<T>
    {
        public event Action<T> OnNotify;
    }
}