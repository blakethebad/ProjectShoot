using System.Collections;

namespace ProjectShoot.Core.GameLogic.Interfaces
{
    public interface IWeapon
    {
        IEnumerator StartShoot(IMoveComponent moveComponent);
        void ChangeBulletFactory(IProjectileFactory projectileFactory);
        void AddStrategy(IWeaponStrategy strategy);
    }
}