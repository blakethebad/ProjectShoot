using UnityEngine;

namespace CaseWixot.Core.Scripts.Interfaces
{
    public interface IMoveHandler
    {
        void Move();
        void ChangeSpeed(int speed);
        Vector3 GetDirection();
        Vector3 GetPosition();
    }
}