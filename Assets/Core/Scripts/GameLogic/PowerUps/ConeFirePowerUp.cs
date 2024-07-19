using ProjectShoot.Core.GameLogic.Interfaces;
using ProjectShoot.Core.GameLogic.WeaponBehaviour.Strategies;

namespace ProjectShoot.Core.GameLogic.PowerUps
{
    public class ConeFirePowerUp : PowerUp<IWeapon>
    {
        private readonly IWeaponStrategy _enabledStrategy;
        private readonly IWeaponStrategy _disabledStrategy;
        public ConeFirePowerUp(IWeapon modifiableEntity, int index) : base(modifiableEntity, index)
        {
            _enabledStrategy = new ConeFire();
            _disabledStrategy = new BasicFire();
        }

        public override void Enable()
        {
            base.Enable(); 
            ModifiedEntity.AddStrategy(_enabledStrategy);
        }

        public override void Disable()
        {
            base.Disable();
            ModifiedEntity.AddStrategy(_disabledStrategy);
        }
    }
}