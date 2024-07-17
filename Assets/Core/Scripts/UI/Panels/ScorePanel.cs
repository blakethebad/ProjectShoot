using System;
using System.Text;
using CaseWixot.Core.Scripts.UI.PopUps;
using TMPro;
using UnityEngine;

namespace CaseWixot.Core.Scripts.UI
{
    public class ScorePanel : UIPanel
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        public override void Open()
        {
            gameObject.SetActive(true);
        }

        public override void Close()
        {
            _scoreText.text = 34.ToString(); //TODO:String Builder Later
        }
    }
    
}