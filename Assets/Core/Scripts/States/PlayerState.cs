using System;

namespace CaseWixot.Core.Scripts.States
{
    //State where the player is able to play the game until the timer reaches zero
    public class PlayerState : BaseGameState
    {
        public PlayerState(Action<GameState> changeStateCallback) : base(changeStateCallback)
        {
        }

        public override void EnterState()
        {
            //Start a timer and connect that timer with UI and when the timer is over 
        }

        public override void ExitState()
        {
            //We might change something if the player Gave up or the timer finished
        }
    }
}