using CaseWixot.Core.Scripts.Interfaces;

namespace CaseWixot.Core.Scripts.PowerUps
{
    public class DoubleFirePowerUp : Booster<IWeapon>
    {
        private IWeaponStrategy _strategy;
        public DoubleFirePowerUp(IWeapon modifiableEntity, int index) : base(modifiableEntity, index)
        {
        }

        public override void Enable()
        {
            base.Enable();
            ModifiedEntity.AddStrategy(new DoubleFire());
        }

        public override void Disable()
        {
            base.Disable();
            ModifiedEntity.AddStrategy(_strategy);

        }
    }

}