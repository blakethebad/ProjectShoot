using System;

namespace CaseWixot.Core.Scripts.States
{
    //The state in which the timer is over or the player stopped the game
    public class EndGameState : BaseGameState
    {
        public EndGameState(Action<GameState> changeStateCallback) : base(changeStateCallback)
        {
        }

        public override void EnterState()
        {
        }

        public override void ExitState()
        {
        }
    }
}