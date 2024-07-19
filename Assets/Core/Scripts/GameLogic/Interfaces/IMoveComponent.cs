using UnityEngine;

namespace ProjectShoot.Core.GameLogic.Interfaces
{
    public interface IMoveComponent
    {
        void Move();
        Vector3 GetDirection();
        Vector3 GetPosition();
        IModifiableStat<int> GetSpeed();
    }
}