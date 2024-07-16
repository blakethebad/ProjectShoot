using System;

namespace CaseWixot.Core.Scripts.States
{
    public enum GameState
    {
        Intro,
        Player,
        EndGame
    }
    
    public abstract class BaseGameState
    {
        protected Action<GameState> ChangeStateCallback;

        public BaseGameState(Action<GameState> changeStateCallback)
        {
            ChangeStateCallback = changeStateCallback;
        }
        
        public abstract void EnterState();
        public abstract void ExitState();
    }
    
}