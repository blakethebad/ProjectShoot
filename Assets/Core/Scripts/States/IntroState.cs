using System;

namespace CaseWixot.Core.Scripts.States
{
    //State where the game waits for the player to Tap for the game to start
    public class IntroState : BaseGameState
    {
        private Action _onStartPressed;
        
        public IntroState(Action<GameState> changeStateCallback, Action onStartPressed) : base(changeStateCallback)
        {
            _onStartPressed = onStartPressed;
        }
        
        public override void EnterState()
        {
            //Open StartPopup and add a callback method that will change state
            _onStartPressed.Invoke();
        }
        

        public override void ExitState()
        {
            //Close StartPopup
        }


    }
}