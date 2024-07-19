using ProjectShoot.Core.GameLogic.Interfaces;
using UnityEngine;

namespace ProjectShoot.Core
{
    public class CameraHandler : MonoBehaviour
    {
        [SerializeField] private float _distance = -10f;
        private IMoveComponent _moveComponent;
        private Vector3 _position = default;
        private bool _startedFollowing = false;

        public void InitCamera(IMoveComponent moveComponent)
        {
            _moveComponent = moveComponent;
            _position.z = _distance;
            _startedFollowing = true;
        }
        
        public void LateUpdate()
        {
            if(_startedFollowing == false)
                return;
            
            _position.x = _moveComponent.GetPosition().x;
            _position.y = _moveComponent.GetPosition().y;

            transform.position = _position;
        }
    }
}