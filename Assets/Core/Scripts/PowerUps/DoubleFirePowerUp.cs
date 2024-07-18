using CaseWixot.Core.Scripts.Interfaces;

namespace CaseWixot.Core.Scripts.PowerUps
{
    public class DoubleFirePowerUp : PowerUp<IWeapon>
    {
        private IDecorator _strategy;
        public DoubleFirePowerUp(IWeapon modifiableEntity, int index) : base(modifiableEntity, index)
        {
        }

        public override void Enable()
        {
            base.Enable();
            _strategy = new DoubleFire();
            IWeaponStrategy strategy = (IWeaponStrategy)_strategy;
            ModifiedEntity.AddStrategy(strategy);
        }

        public override void Disable()
        {
            base.Disable();
            IWeaponStrategy strategy = _strategy.ReleaseDecorated();
            ModifiedEntity.AddStrategy(strategy);
        }
    }

}