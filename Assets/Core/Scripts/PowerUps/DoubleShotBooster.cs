using CaseWixot.Core.Scripts.Interfaces;

namespace CaseWixot.Core.Scripts.PowerUps
{
    public class DoubleShotBooster : PowerUp<IWeapon>
    {
        public DoubleShotBooster(IWeapon modifiableEntity) : base(modifiableEntity)
        {
        }

        public override void Enable()
        {
            ModifiedEntity.SetDoubleShot(true);
        }

        public override void Disable()
        {
            ModifiedEntity.SetDoubleShot(false);
        }
    }
}