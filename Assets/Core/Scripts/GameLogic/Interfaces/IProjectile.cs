using System;
using UnityEngine;

namespace CaseWixot.Core.Scripts.Interfaces
{
    public interface IProjectile
    {
        void Init(float speed, Action<GameObject> onJourneyComplete);
        void Launch(Vector3 initPos, Vector3 direction);
    }
}