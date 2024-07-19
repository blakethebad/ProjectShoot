using CaseWixot.Core.Scripts.Interfaces;
using UnityEngine;

namespace CaseWixot.Core.Scripts
{
    public sealed class Player : MonoBehaviour, IActiveEntity
    {
        private IWeapon _weapon;
        private IMoveComponent _moveComponent;
        private IPowerUpDeck _powerUpDeck;

        private Coroutine _weaponRoutine;
        
        public void InitPlayer(IWeapon weapon, IMoveComponent moveComponent, IPowerUpDeck powerUpDeck)
        {
            _weapon = weapon;
            _moveComponent = moveComponent;
            _powerUpDeck = powerUpDeck;
            
            _powerUpDeck.Init();
            _weaponRoutine = StartCoroutine(_weapon.StartShoot(moveComponent));
        }
        
        private void Update()
        {
            _moveComponent.Move();
        }

        public void Deactivate()
        {
            StopCoroutine(_weaponRoutine);
        }
    }
}