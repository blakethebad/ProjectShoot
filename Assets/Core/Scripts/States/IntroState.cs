using System;
using CaseWixot.Core.Scripts.UI;
using CaseWixot.Core.Scripts.UI.PopUps;

namespace CaseWixot.Core.Scripts.States
{
    //State where the game waits for the player to Tap for the game to start
    public class IntroState : BaseGameState , IStartGameListener
    {
        private readonly Action _onStartPressed;
        private IPopUpFactory _popUpFactory;
        
        public IntroState(Action<GameState> changeStateCallback, Action onStartPressed, IPopUpFactory popUpFactory) : base(changeStateCallback)
        {
            _onStartPressed = onStartPressed;
            _popUpFactory = popUpFactory;
        }
        
        public override void EnterState()
        {
            _popUpFactory.Pull(PopUpType.StartGame);
            StartGamePopUp.OnTap += OnScreenTap;
        }

        public override void ExitState()
        {
            StartGamePopUp.OnTap -= OnScreenTap;
        }

        public void OnScreenTap()
        {
            _onStartPressed.Invoke();
            ChangeStateCallback.Invoke(GameState.Player);
        }
    }
}