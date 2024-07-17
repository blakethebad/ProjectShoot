using System.Collections.Generic;
using CaseWixot.Core.Scripts.EventSystem.Events;
using CaseWixot.Core.Scripts.Interfaces;
using CaseWixot.Core.Scripts.PowerUps;

namespace CaseWixot.Core.Scripts
{
    public class PowerUpComponent : IPowerUpComponent
    {
        private readonly IPowerUpFactory _factory;
        private IPowerUp[] _ownedPowerUps;
        private bool[] _isActive;
        
        public PowerUpComponent(IPowerUpFactory factory)
        {
            _factory = factory;
        }

        public void Init()
        {
            _ownedPowerUps = _factory.GenerateAll();
            _isActive = new bool[_ownedPowerUps.Length];
        }

        public void OnPowerUpToggled(int index)
        {
            _ownedPowerUps[index].Toggle();
        }
    }
}