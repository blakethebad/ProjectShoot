using CaseWixot.Core.Scripts.Interfaces;
using CaseWixot.Core.Scripts.Services;
using CaseWixot.Core.Scripts.UI;
using UnityEngine;

namespace CaseWixot.Core.Scripts
{
    public class Player : MonoBehaviour, IActiveEntity, IPoolObject
    {
        private IWeapon _weapon;
        private IMoveHandler _moveHandler;
        private IPowerUp[] _ownedPowerUps;

        private Coroutine _weaponRoutine;
        private bool _isActive = true;

        public void InitPlayer(IWeapon weapon, IMoveHandler moveHandler, params IPowerUp[] powerUps)
        {
            _weapon = weapon;
            _moveHandler = moveHandler;
            _ownedPowerUps = powerUps;

            PowerUpPanel.OnPowerUpPressed += OnPowerUpPressed;
            _weaponRoutine = StartCoroutine(_weapon.Shoot(moveHandler));
        }
        
        private void Update()
        {
            if(!_isActive) return;
            _moveHandler.Move();
        }

        private void OnPowerUpPressed(int index)
        {
            _ownedPowerUps[index].Enable();
        }

        public void Deactivate()
        {
            _isActive = false;
            StopCoroutine(_weaponRoutine);
        }
    }

    public interface IActiveEntity
    {
        void Deactivate();
    }

}