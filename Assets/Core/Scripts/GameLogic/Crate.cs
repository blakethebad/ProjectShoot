using ProjectShoot.Core.GameLogic.Interfaces;
using UnityEngine;

namespace ProjectShoot.Core.GameLogic
{
    [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
    public class Crate : MonoBehaviour, IHittable
    {
        void IHittable.TakeHit()
        {
            Destroy(this.gameObject);
        }
    }
}