using CaseWixot.Core.Scripts.UI.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CaseWixot.Core.Scripts.UI
{
    public class PowerUpButton : MonoBehaviour, IPowerUpButton, IPointerClickHandler
    {
        private Color _selectedColor;
        private Color _regularColor;
        private bool _isSelected;

        public void Init()
        {
            
        }
        
        
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.LogError("Test");
        }
    }
}