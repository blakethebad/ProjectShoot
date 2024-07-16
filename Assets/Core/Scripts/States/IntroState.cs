using System;

namespace CaseWixot.Core.Scripts.States
{
    //State where the game waits for the player to Tap for the game to start
    public class IntroState : BaseGameState
    {
        public IntroState(Action<GameState> changeStateCallback) : base(changeStateCallback)
        {
        }
        
        public override void EnterState()
        {
            //Open StartPopup and add a callback method that will change state
        }
        

        public override void ExitState()
        {
            //Close StartPopup
        }


    }
}