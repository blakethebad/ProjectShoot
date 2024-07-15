using CaseWixot.Core.Scripts.Interfaces;

namespace CaseWixot.Core.Scripts.PowerUps
{
    public class SpeedBooster : PowerUp<IMoveHandler>
    {
        private int _fastSpeed;
        private int _normalSpeed;
        
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