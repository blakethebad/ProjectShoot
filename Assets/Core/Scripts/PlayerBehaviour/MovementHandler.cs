using System;
using CaseWixot.Core.Scripts.Interfaces;
using UnityEngine;

namespace CaseWixot.Core.Scripts
{
    public class MovementHandler : IMoveHandler
    {
        private Transform _transform;
        private bool _isMoving;
        private Vector3 _position;
        private Vector3 _dragDir;
        private Vector3 _velocity = Vector3.up;
        private float _speed = 1f;

        public MovementHandler(Transform transform)
        {
            _transform = transform;
        }
        
        public void Move()
        {
            if (_isMoving)
            {
                Vector3 pos = Input.mousePosition;

                if (Math.Abs(pos.x - _position.x) > 0.002f || Math.Abs(pos.y - _position.y) > 0.002f)
                {
                    _dragDir = Input.mousePosition - _position;
                    _dragDir = _dragDir.normalized;
                    _velocity = _dragDir * _speed;
                }
                _transform.position += _velocity * Time.deltaTime;

            }
            if (Input.GetMouseButtonDown(0))
            {
                _isMoving = true;
                _position = Input.mousePosition;
                Debug.LogError(_position);

            }
            if (Input.GetMouseButtonUp(0))
            {
                _isMoving = false;
                _velocity = Vector3.up;
                _position = Vector3.zero;
            }

            _transform.up = _velocity;
        }

        public void ChangeSpeed(int speed)
        {
            _speed = speed;
        }

        public Vector3 GetDirection()
        {
            return _velocity.normalized;
        }

        public Vector3 GetPosition()
        {
            return _transform.position;
        }
    }
}