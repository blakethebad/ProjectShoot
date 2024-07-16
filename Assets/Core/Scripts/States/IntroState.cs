using System;
using CaseWixot.Core.Scripts.UI;

namespace CaseWixot.Core.Scripts.States
{
    //State where the game waits for the player to Tap for the game to start
    public class IntroState : BaseGameState
    {
        private readonly Action _onStartPressed;
        
        public IntroState(Action<GameState> changeStateCallback, Action onStartPressed) : base(changeStateCallback)
        {
            _onStartPressed = onStartPressed;
        }
        
        public override void EnterState()
        {
            UIManager.Instance.OpenPopUp(PopUpType.StartGamePopUp, new StartGameContext((() =>
            {
                _onStartPressed.Invoke();
                ChangeStateCallback.Invoke(GameState.Player);
            })));
        }
        

        public override void ExitState()
        {
        }


    }
}