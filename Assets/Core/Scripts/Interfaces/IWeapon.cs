using System.Collections;
using System.Collections.Generic;
using CaseWixot.Core.Scripts.PowerUps;

namespace CaseWixot.Core.Scripts.Interfaces
{
    public interface IWeapon
    {
        IEnumerator StartShoot(IMoveComponent moveComponent);
        void ChangeBulletFactory(IProjectileFactory projectileFactory);
        void AddStrategy(IWeaponStrategy strategy);
    }
}