using System.Collections.Generic;
using CaseWixot.Core.Scripts.EventSystem.Events;
using CaseWixot.Core.Scripts.Interfaces;

namespace CaseWixot.Core.Scripts
{
    public class PowerUpDeck : IPowerUpDeck
    {
        private IPowerUp[] _deck;
        private bool[] _isPowerUpEnabled;
        private int _maxActiveCount;

        private List<IPowerUp> _activeList = new List<IPowerUp>();

        public PowerUpDeck(IPowerUp[] powerUps)
        {
            _maxActiveCount = 3;
            _deck = powerUps;
        }

        void IPowerUpDeck.Init()
        {
            for (int i = 0; i < _deck.Length; i++)
            {
                EventMediator.PowerUpAddedEvent.Raise(new PowerUpDeckEvent(i));
            }
        }

        void IPowerUpDeck.OnPowerUpToggled(int index)
        {
            IPowerUp powerUp = _deck[index];

            if (powerUp.IsActive)
            {
                powerUp.Disable();
                _activeList.Remove(powerUp);
            }
            else if (_activeList.Count < _maxActiveCount)
            {
                powerUp.Enable();
                _activeList.Add(powerUp);
            }
        }
    }
}