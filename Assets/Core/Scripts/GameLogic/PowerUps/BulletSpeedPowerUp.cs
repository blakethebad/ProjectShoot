using ProjectShoot.Core.GameLogic.Interfaces;

namespace ProjectShoot.Core.GameLogic.PowerUps
{
    public class BulletSpeedPowerUp : PowerUp<IWeapon> 
    {
        private IProjectileFactory _regularFactory;
        private IProjectileFactory _fastProjectileFactory;
        
        public BulletSpeedPowerUp(IWeapon modifiableEntity, int index, IProjectileFactory projectileFactory, IProjectileFactory fastFactory) : base(modifiableEntity, index)
        {
            _regularFactory = projectileFactory;
            _fastProjectileFactory = fastFactory;
        }

        public override void Enable()
        {
            base.Enable();
            ModifiedEntity.ChangeBulletFactory(_fastProjectileFactory);
        }

        public override void Disable()
        {
            base.Disable();
            ModifiedEntity.ChangeBulletFactory(_regularFactory);
        }
    }
}