using System.Collections.Generic;
using ProjectShoot.Core.EventSystem;
using ProjectShoot.Core.EventSystem.Events;
using ProjectShoot.Core.GameLogic.Interfaces;

namespace ProjectShoot.Core.GameLogic.PlayerBehaviour
{
    public sealed class PowerUpDeck : IPowerUpDeck
    {
        private IPowerUp[] _deck;
        private bool[] _isPowerUpEnabled;
        private int _maxActiveCount;

        private List<IPowerUp> _activeList;

        public PowerUpDeck(IPowerUp[] powerUps)
        {
            _activeList = new List<IPowerUp>(_maxActiveCount);
            _maxActiveCount = 3;
            _deck = powerUps;
        }

        void IPowerUpDeck.Init()
        {
            for (int i = 0; i < _deck.Length; i++)
            {
                GameEvents.PowerUpAddedEvent.Raise(new PowerUpDeckEvent(i));
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