
using ProjectShoot.Core.GameLogic.Interfaces;

namespace ProjectShoot.Core.GameLogic.PowerUps
{
    public class SpeedPowerUp : PowerUp<IModifiableStat<int>>
    {
        public SpeedPowerUp(IModifiableStat<int> modifiableEntity, int index) : base(modifiableEntity, index)
        {
        }

        public override void Enable()
        {
            base.Enable();
            ModifiedEntity.Modify(3);
        }

        public override void Disable()
        {
            base.Disable();
            ModifiedEntity.Clear();
        }
    }
}