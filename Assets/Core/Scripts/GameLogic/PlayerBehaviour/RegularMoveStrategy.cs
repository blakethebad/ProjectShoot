using UnityEngine;

namespace CaseWixot.Core.Scripts
{
    public class RegularMoveStrategy : IMoveStrategy
    {
        private Vector3 _calculatedVelocity = Vector3.up;

        Vector3 IMoveStrategy.Execute(Vector3 delta, int speed, int swipeResistance)
        {
            if (!(Mathf.Abs(delta.x) > swipeResistance) && !(Mathf.Abs(delta.y) > swipeResistance))
                return _calculatedVelocity * speed;
            
            if (Mathf.Abs(delta.normalized.x) > 0.7f)
            {
                _calculatedVelocity = delta.normalized.x > 0 ? Vector3.right : Vector3.left;
            }
            else
            {
                _calculatedVelocity = delta.normalized.y > 0 ? Vector3.up : Vector3.down;
            }

            return _calculatedVelocity * speed;
        }
    }
}