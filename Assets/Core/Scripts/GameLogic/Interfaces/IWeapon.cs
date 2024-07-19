using System.Collections;

namespace CaseWixot.Core.Scripts.Interfaces
{
    public interface IWeapon
    {
        IEnumerator StartShoot(IMoveComponent moveComponent);
        void ChangeBulletFactory(IProjectileFactory projectileFactory);
        void AddStrategy(IWeaponStrategy strategy);
    }
}