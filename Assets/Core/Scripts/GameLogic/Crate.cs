using CaseWixot.Core.Scripts.Interfaces;
using UnityEngine;

namespace CaseWixot.Core.Scripts
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