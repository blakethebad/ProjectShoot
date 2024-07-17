using System;
using System.Collections;
using System.Collections.Generic;
using CaseWixot.Core.Scripts.UI;
using CaseWixot.Core.Scripts.UI.PopUps;
using UnityEngine;

namespace CaseWixot.Core.Scripts.States
{
    //State where the player is able to play the game until the timer reaches zero
    public class PlayerState : BaseGameState
    {
        private int _remainingTime = 2;
        private MonoBehaviour _monoBehaviour;
        private Coroutine _timer;

        public static event Action<int> OnTimerUpdated; 

        public PlayerState(Action<GameState> changeStateCallback, MonoBehaviour monoBehaviour) : base(changeStateCallback)
        {
            _monoBehaviour = monoBehaviour;
        }

        public override void EnterState()
        {
            _timer = _monoBehaviour.StartCoroutine(Timer());
        }

        private IEnumerator Timer()
        {
            yield return new WaitForSeconds(1f);
            _remainingTime -= 1;
            OnTimerUpdated?.Invoke(_remainingTime);
            
            if (_remainingTime == 0)
            {
                _monoBehaviour.StopCoroutine(_timer);
                ChangeStateCallback.Invoke(GameState.EndGame);
                yield break;
            }

            yield return Timer();
        }
    }
}