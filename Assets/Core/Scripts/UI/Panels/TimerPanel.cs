using System;
using System.Text;
using CaseWixot.Core.Scripts.States;
using CaseWixot.Core.Scripts.UI.PopUps;
using TMPro;
using UnityEngine;

namespace CaseWixot.Core.Scripts.UI
{
    public class TimerPanel : UIPanel
    {
        [SerializeField] private TextMeshProUGUI _timerText;

        private StringBuilder _builder;
        
        public override void Open()
        {
            PlayerState.OnTimerUpdated += OnTimerChanged;
            _builder = new StringBuilder();
            gameObject.SetActive(true);
        }

        public override void Close()
        {
            PlayerState.OnTimerUpdated -= OnTimerChanged;
        }

        public void OnTimerChanged(int remaining)
        {
            _builder.Clear();
            int minutes = remaining / 60;
            int seconds = remaining % 60;

            _builder.Append(minutes.ToString("D2"));
            _builder.Append(":");
            _builder.Append(seconds.ToString("D2"));
            _timerText.text = _builder.ToString();
        }
    }
}