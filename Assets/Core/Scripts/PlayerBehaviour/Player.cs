using System;
using CaseWixot.Core.Scripts.Interfaces;
using CaseWixot.Core.Scripts.PowerUps;
using UnityEngine;

namespace CaseWixot.Core.Scripts
{
    public class Player : MonoBehaviour
    {
        private IWeapon _weapon;
        private IMoveComponent _moveComponent;
        private IPowerUpDeck _powerUpDeck;
        
        public void InitPlayer(IWeapon weapon, IMoveComponent moveComponent, IPowerUpDeck powerUpDeck)
        {
            _weapon = weapon;
            _moveComponent = moveComponent;
            _powerUpDeck = powerUpDeck;
            
            _powerUpDeck.Init();
            StartCoroutine(_weapon.StartShoot(moveComponent));
        }
        
        private void Update()
        {
            _moveComponent.Move();
        }
    }
}