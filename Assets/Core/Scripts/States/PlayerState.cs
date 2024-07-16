using System;
using System.Collections;
using CaseWixot.Core.Scripts.UI;
using UnityEngine;

namespace CaseWixot.Core.Scripts.States
{
    //State where the player is able to play the game until the timer reaches zero
    public class PlayerState : BaseGameState
    {
        private int _remainingTime = 100;
        private MonoBehaviour _monoBehaviour;
        private Coroutine _timer;
        
        public PlayerState(Action<GameState> changeStateCallback, MonoBehaviour monoBehaviour) : base(changeStateCallback)
        {
            _monoBehaviour = monoBehaviour;
        }

        public override void EnterState()
        {
            _timer = _monoBehaviour.StartCoroutine(Timer());
            //Start a timer and connect that timer with UI and when the timer is over 
        }

        private IEnumerator Timer()
        {
            Debug.LogError("Test");
            yield return new WaitForSeconds(1f);
            _remainingTime -= 1;
            TimerPanel.OnTimerChange.Invoke(_remainingTime);
            
            if (_remainingTime == 0)
            {
                _monoBehaviour.StopCoroutine(_timer);
                ChangeStateCallback.Invoke(GameState.EndGame);
                yield break;
            }

            yield return Timer();
        }

        public override void ExitState()
        {
            //We might change something if the player Gave up or the timer finished
        }
    }
}