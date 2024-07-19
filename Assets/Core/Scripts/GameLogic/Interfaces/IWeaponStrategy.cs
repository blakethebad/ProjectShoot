using UnityEngine;

namespace ProjectShoot.Core.GameLogic.Interfaces
{
    public interface IWeaponStrategy
    {
        void Execute(IProjectileFactory factory, Vector3 initPos, Vector3 velocity);
        bool HandleNew(IWeaponStrategy weaponStrategy);
    }
}