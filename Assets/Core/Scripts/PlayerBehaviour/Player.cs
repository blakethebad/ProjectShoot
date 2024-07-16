using CaseWixot.Core.Scripts.Interfaces;
using CaseWixot.Core.Scripts.UI;
using UnityEngine;

namespace CaseWixot.Core.Scripts
{
    public class Player : MonoBehaviour
    {
        private IWeapon _weapon;
        private IMoveHandler _moveHandler;
        private IPowerUp[] _ownedPowerUps;

        public void InitPlayer(IWeapon weapon, IMoveHandler moveHandler, params IPowerUp[] powerUps)
        {
            _weapon = weapon;
            _moveHandler = moveHandler;
            _ownedPowerUps = powerUps;

            PowerUpPanel.OnPowerUpPressed += OnPowerUpPressed;
            StartCoroutine(_weapon.Shoot(moveHandler));
        }
        
        private void Update()
        {
            _moveHandler.Move();
        }

        private void OnPowerUpPressed(int index)
        {
            _ownedPowerUps[index].Enable();
        }

    }

}