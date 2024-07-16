using System.Text;
using TMPro;
using UnityEngine;

namespace CaseWixot.Core.Scripts.UI
{
    public class ScorePanel : UIPanel, IScoreListener
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        public override void Open()
        {
            gameObject.SetActive(true);
        }

        public override void Close()
        {
        }

        void IScoreListener.OnScoreChanged(int current)
        {
            _scoreText.text = current.ToString(); //TODO:String Builder Later
        }
    }

    public interface IScoreListener
    {
        void OnScoreChanged(int current);
    }
}