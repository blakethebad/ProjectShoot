using UnityEngine;

namespace CaseWixot.Core.Scripts.Interfaces
{
    public interface IWeaponStrategy
    {
        void Execute(IProjectileFactory factory, Vector3 initPos, Vector3 velocity);
        bool HandleNew(IWeaponStrategy weaponStrategy);
    }
}