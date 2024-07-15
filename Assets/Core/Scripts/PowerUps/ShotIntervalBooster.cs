using CaseWixot.Core.Scripts.Interfaces;

namespace CaseWixot.Core.Scripts.PowerUps
{
    public class ShotIntervalBooster : PowerUp<IWeapon>
    {
        public ShotIntervalBooster(IWeapon modifiableEntity) : base(modifiableEntity)
        {
        }

        public override void Enable()
        {
            ModifiedEntity.SetBulletInterval(1f);
        }

        public override void Disable()
        {
            ModifiedEntity.SetBulletInterval(2f);
        }
    }
}