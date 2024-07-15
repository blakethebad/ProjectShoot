using CaseWixot.Core.Scripts.Interfaces;

namespace CaseWixot.Core.Scripts.PowerUps
{
    public abstract class PowerUp<T> : IPowerUp
    {
        protected readonly T ModifiedEntity;

        protected PowerUp(T modifiableEntity)
        {
            ModifiedEntity = modifiableEntity;
        }
        
        public abstract void Enable();
        public abstract void Disable();
    }
}