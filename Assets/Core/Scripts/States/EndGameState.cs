using System;
using CaseWixot.Core.Scripts.UI;
using CaseWixot.Core.Scripts.UI.PopUps;

namespace CaseWixot.Core.Scripts.States
{
    //The state in which the timer is over or the player stopped the game
    public class EndGameState : BaseGameState
    {
        private Action _onRestart;
        private Action _deactivateEntities;
        public EndGameState(Action<GameState> changeStateCallback, Action onRestart, Action deactivateEntities) : base(changeStateCallback)
        {
            _onRestart = onRestart;
            _deactivateEntities = deactivateEntities;
        }

        public override void EnterState()
        {
            _deactivateEntities.Invoke();
            UIManager.Instance.OpenPopUp(PopUpType.EndGamePopUp, new EndGameContext((() =>
            {
                _onRestart.Invoke();
            }), () =>
            {
                _onRestart.Invoke();
            }));
        }

        public override void ExitState()
        {
        }
    }
}