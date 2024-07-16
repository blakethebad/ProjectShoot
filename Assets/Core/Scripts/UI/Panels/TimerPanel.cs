using System;
using System.Text;
using TMPro;
using UnityEngine;

namespace CaseWixot.Core.Scripts.UI
{
    public class TimerPanel : UIPanel, ITimerListener
    {
        [SerializeField] private TextMeshProUGUI _timerText;

        public static Action<int> OnTimerChange;
        private StringBuilder _builder;
        
        public override void Open()
        {
            _builder = new StringBuilder();
            gameObject.SetActive(true);
            OnTimerChange += OnTimerChanged;
        }

        public override void Close()
        {
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

    public interface ITimerListener
    {
        void OnTimerChanged(int remaining);
    }
}