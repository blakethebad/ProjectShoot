using CaseWixot.Core.Scripts.Interfaces;
using CaseWixot.Core.Scripts.UI;
using UnityEngine;

namespace CaseWixot.Core.Scripts
{
    public class Player : MonoBehaviour
    {
        private IWeapon _weapon;
        private IMoveHandler _moveHandler;

        private IPowerUp[] _ownedPowerUps = new IPowerUp[5];
        private bool[] _activePowerUps;

        public void InitPlayer(IPowerUpPublisher powerUpPublisher, IWeapon weapon, IMoveHandler moveHandler, params IPowerUp[] powerUps)
        {
            _weapon = weapon;
            _moveHandler = moveHandler;

            _ownedPowerUps = powerUps;

            powerUpPublisher.PowerUpActivated += ActivatePowerUp;

            StartCoroutine(_weapon.Shoot(moveHandler));
        }
        
        private void Update()
        {
            _moveHandler.Move();
        }

        private void ActivatePowerUp(int index)
        {
            _ownedPowerUps[index].Enable();
        }
    }
}