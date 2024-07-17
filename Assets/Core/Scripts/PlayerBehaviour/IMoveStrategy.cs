using UnityEngine;

namespace CaseWixot.Core.Scripts
{
    public interface IMoveStrategy
    {
        public Vector3 Execute(Vector3 delta, int speed, int swipeResistance);
    }
}