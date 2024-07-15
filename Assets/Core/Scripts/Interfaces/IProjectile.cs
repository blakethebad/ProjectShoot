using UnityEngine;

namespace CaseWixot.Core.Scripts.Interfaces
{
    public interface IProjectile
    {
        void Launch(Vector3 initPos, Vector3 direction);
    }
}