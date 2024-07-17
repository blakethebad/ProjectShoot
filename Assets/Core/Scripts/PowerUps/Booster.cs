using System;
using CaseWixot.Core.Scripts.EventSystem.Events;
using CaseWixot.Core.Scripts.Interfaces;

namespace CaseWixot.Core.Scripts.PowerUps
{
    public abstract class Booster<T> : IPowerUp
    {
        protected readonly T ModifiedEntity;
        private readonly int _index;
        private Action _onToggle;
        
        protected Booster(T modifiableEntity, int index)
        {
            ModifiedEntity = modifiableEntity;
            _onToggle = Enable;
            _index = index;
        }
        
        public void Toggle()
        {
            _onToggle.Invoke();
        }
        
        public virtual void Enable()
        {
            EventMediator.PowerUpEnableEvent.Raise(new PowerUpEvent()
            {
                EnabledIndex = _index
            });
            _onToggle = Disable;
        }

        public virtual void Disable()
        {
            EventMediator.PowerUpDisableEvent.Raise(new PowerUpEvent()
            {
                DisabledIndex = _index
            });
            _onToggle = Enable;
        }
    }
}