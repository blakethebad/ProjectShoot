using System;
using ProjectShoot.Core.EventSystem;
using ProjectShoot.Core.EventSystem.Events;
using ProjectShoot.Core.GameLogic.Interfaces;

namespace ProjectShoot.Core.GameLogic.PowerUps
{
    public abstract class PowerUp<T> : IPowerUp
    {
        protected readonly T ModifiedEntity;
        private readonly int _index;
        
        protected PowerUp(T modifiableEntity, int index)
        {
            ModifiedEntity = modifiableEntity;
            _index = index;
        }
        
        public bool IsActive { get; private set; } = false;

        public virtual void Enable()
        {
            IsActive = true;
            GameEvents.PowerUpEnableEvent.Raise(new PowerUpToggleEvent()
            {
                EnabledIndex = _index
            });
        }

        public virtual void Disable()
        {
            IsActive = false;
            GameEvents.PowerUpDisableEvent.Raise(new PowerUpToggleEvent()
            {
                DisabledIndex = _index
            });
        }
    }
}