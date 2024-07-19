using CaseWixot.Core.Scripts.Interfaces;

namespace CaseWixot.Core.Scripts.PowerUps
{
    public class DoubleFirePowerUp : PowerUp<IWeapon>
    {
        private IWeaponDecorator _strategy;
        public DoubleFirePowerUp(IWeapon modifiableEntity, int index) : base(modifiableEntity, index)
        {
        }

        public override void Enable()
        {
            base.Enable();
            _strategy = new DoubleFire();
            ModifiedEntity.AddStrategy(_strategy);
        }

        public override void Disable()
        {
            base.Disable();
            IWeaponStrategy strategy = _strategy.ReleaseDecorated();
            ModifiedEntity.AddStrategy(strategy);
        }
    }

}