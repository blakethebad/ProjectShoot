using System;
using System.Collections.Generic;
using CaseWixot.Core.Scripts.UI.PopUps;

namespace CaseWixot.Core.Scripts
{
    public enum PopUpType
    {
        StartGame,
        EndGame
    }
    
    public class PopUpFactory : IPopUpFactory
    {
        private Dictionary<PopUpType, IPopUp> _popUps;

        public PopUpFactory(StartGamePopUp startGamePopUp, EndGamePopUp endGamePopUp)
        {
            _popUps = new Dictionary<PopUpType, IPopUp>()
            {
                { PopUpType.StartGame , startGamePopUp},
                { PopUpType.EndGame , endGamePopUp}
            };
        }

        public void Pull(PopUpType popUpType)
        {
            if (_popUps.TryGetValue(popUpType, out IPopUp popUp))
            {
                popUp.Show();
            }
        }

        public void Release(IPopUp popUp)
        {
            if (_popUps.ContainsValue(popUp))
            {
                popUp.Hide();
            }
        }
    }

    public interface IPopUpFactory
    {
        void Pull(PopUpType popUpType);
        void Release(IPopUp popUp);
    }
}