using CaseWixot.Core.Scripts.Interfaces;

namespace CaseWixot.Core.Scripts.PowerUps
{
    public class ConeShotBooster : PowerUp<IWeapon>
    {
        public ConeShotBooster(IWeapon modifiableEntity) : base(modifiableEntity)
        {
        }

        public override void Enable()
        {
            ModifiedEntity.SetStrategy(new ConeFire());
        }

        public override void Disable()
        {
            ModifiedEntity.SetStrategy(new BasicFire());
        }
    }
}