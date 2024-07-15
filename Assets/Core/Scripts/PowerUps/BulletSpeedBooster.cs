using CaseWixot.Core.Scripts.Interfaces;

namespace CaseWixot.Core.Scripts.PowerUps
{
    public class BulletSpeedBooster : PowerUp<IWeapon>
    {
        private readonly IProjectileFactory _regularBulletFactory;
        private readonly IProjectileFactory _fastBulletFactory;
        
        public BulletSpeedBooster(IWeapon modifiable, IProjectileFactory regularBulletFactory, IProjectileFactory fastBulletFactory) : base(modifiable)
        {
            _regularBulletFactory = regularBulletFactory;
            _fastBulletFactory = fastBulletFactory;
        }
        
        public override void Enable()
        {
            ModifiedEntity.SetBulletProvider(_fastBulletFactory);
        }

        public override void Disable()
        {
            ModifiedEntity.SetBulletProvider(_regularBulletFactory);
        }
    }
}