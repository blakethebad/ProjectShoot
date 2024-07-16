using System;
using CaseWixot.Core.Scripts.Interfaces;
using UnityEngine;

namespace CaseWixot.Core.Scripts
{
    public class CameraHandler : MonoBehaviour
    {
        [SerializeField] private float _distance = -10f;
        private IMoveHandler _moveHandler;
        private Vector3 _position = default;
        private bool _startedFollowing = false;

        public void InitCamera(IMoveHandler moveHandler)
        {
            _moveHandler = moveHandler;
            _position.z = _distance;
            _startedFollowing = true;
        }
        
        public void LateUpdate()
        {
            if(_startedFollowing == false)
                return;
            
            _position.x = _moveHandler.GetPosition().x;
            _position.y = _moveHandler.GetPosition().y;

            transform.position = _position;
        }
    }
}