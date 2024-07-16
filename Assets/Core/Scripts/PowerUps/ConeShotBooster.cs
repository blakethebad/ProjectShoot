using CaseWixot.Core.Scripts.Interfaces;

namespace CaseWixot.Core.Scripts.PowerUps
{
    public sealed class ConeShotBooster : PowerUp<IWeapon>
    {
        private readonly IWeaponStrategy _initialStrategy;
        private readonly IWeaponStrategy _boostedStrategy;
        
        public ConeShotBooster(IWeapon modifiableEntity, IWeaponStrategy initialStrategy, IWeaponStrategy boostedStrategy) : base(modifiableEntity)
        {
            _initialStrategy = initialStrategy;
            _boostedStrategy = boostedStrategy;
        }

        public override void Enable()
        {
            ModifiedEntity.SetStrategy(_boostedStrategy);
        }

        public override void Disable()
        {
            ModifiedEntity.SetStrategy(_initialStrategy);
        }
    }
}