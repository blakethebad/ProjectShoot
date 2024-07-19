using UnityEngine;

namespace ProjectShoot.Core.GameLogic.Interfaces
{
    public interface IMoveStrategy
    {
        public Vector3 Execute(Vector3 delta, int speed, int swipeResistance);
    }
}