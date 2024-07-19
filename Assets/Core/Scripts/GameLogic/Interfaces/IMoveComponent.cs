using CaseWixot.Core.Scripts.PowerUps;
using UnityEngine;

namespace CaseWixot.Core.Scripts.Interfaces
{
    public interface IMoveComponent
    {
        void Move();
        Vector3 GetDirection();
        Vector3 GetPosition();
        IModifiableStat<int> GetSpeed();
    }
}