using System.Collections;

namespace CaseWixot.Core.Scripts.Interfaces
{
    public interface IWeapon
    {
        IEnumerator Shoot(IMoveHandler moveHandler);
        void SetBulletProvider(IProjectileFactory projectileFactory);
        void SetStrategy(IWeaponStrategy strategy);
        void SetBulletInterval(float interval);
        void SetDoubleShot(bool isDoubleShot);
    }
}