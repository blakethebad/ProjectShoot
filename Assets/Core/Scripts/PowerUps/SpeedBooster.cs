using CaseWixot.Core.Scripts.Interfaces;

namespace CaseWixot.Core.Scripts.PowerUps
{
    public class SpeedBooster : PowerUp<IMoveHandler>
    {
        private int _fastSpeed = 3;
        private int _normalSpeed = 1;
        
        public override void Enable()
        {
            ModifiedEntity.ChangeSpeed(_fastSpeed);
        }

        public override void Disable()
        {
            ModifiedEntity.ChangeSpeed(_normalSpeed);
        }

        public SpeedBooster(IMoveHandler modifiableEntity) : base(modifiableEntity)
        {
        }
    }
}