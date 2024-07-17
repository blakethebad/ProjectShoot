using System;
using CaseWixot.Core.Scripts.Interfaces;
using CaseWixot.Core.Scripts.PowerUps;
using UnityEngine;

namespace CaseWixot.Core.Scripts
{
    public class Player : MonoBehaviour, IPowerUpHolder
    {
        private IWeapon _weapon;
        private IMoveComponent _moveComponent;

        private IPowerUp[] _ownedPowerUps;
        
        public void InitPlayer(IWeapon weapon, IMoveComponent moveComponent, IPowerUp[] powerUps)
        {
            _weapon = weapon;
            _moveComponent = moveComponent;
            _ownedPowerUps = powerUps;

            StartCoroutine(_weapon.StartShoot(moveComponent));
        }
        
        private void Update()
        {
            _moveComponent.Move();
        }

        public void OnPowerUpToggled(int index)
        {
            _ownedPowerUps[index].Toggle();
        }
    }

    public interface IPowerUpHolder
    {
        void OnPowerUpToggled(int index);
    }
}