
using ProjectShoot.Core.GameLogic.Interfaces;

namespace ProjectShoot.Core.GameLogic.PowerUps
{
    public class FireIntervalPowerUp : PowerUp<IModifiableStat<float>>
    {
        public FireIntervalPowerUp(IModifiableStat<float> modifiableEntity, int index) : base(modifiableEntity, index)
        {
        }

        public override void Enable()
        {
            base.Enable();
            ModifiedEntity.Modify(1f);
        }

        public override void Disable()
        {
            base.Disable();
            ModifiedEntity.Clear();
        }
    }
}