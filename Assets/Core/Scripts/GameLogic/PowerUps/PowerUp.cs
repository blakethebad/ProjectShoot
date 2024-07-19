using System;
using CaseWixot.Core.Scripts.EventSystem.Events;
using CaseWixot.Core.Scripts.Interfaces;

namespace CaseWixot.Core.Scripts.PowerUps
{
    public abstract class PowerUp<T> : IPowerUp
    {
        protected readonly T ModifiedEntity;
        private readonly int _index;
        private Action _onToggle;
        
        protected PowerUp(T modifiableEntity, int index)
        {
            ModifiedEntity = modifiableEntity;
            _onToggle = Enable;
            _index = index;
        }
        
        public void Toggle()
        {
            _onToggle.Invoke();
        }

        public bool IsActive { get; private set; } = false;

        public virtual void Enable()
        {
            IsActive = true;
            GameEvents.PowerUpEnableEvent.Raise(new PowerUpToggleEvent()
            {
                EnabledIndex = _index
            });
            _onToggle = Disable;
        }

        public virtual void Disable()
        {
            IsActive = false;
            GameEvents.PowerUpDisableEvent.Raise(new PowerUpToggleEvent()
            {
                DisabledIndex = _index
            });
            _onToggle = Enable;
        }
    }
}