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

        public override void Open(WindowDefinition windowDefinition)
        {
            gameObject.SetActive(true);
        }

        public override void Close()
        {
            gameObject.SetActive(false);
        }
    }
    
}