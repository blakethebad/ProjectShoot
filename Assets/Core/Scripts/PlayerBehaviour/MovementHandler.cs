using System;
using CaseWixot.Core.Scripts.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace CaseWixot.Core.Scripts
{
    public class MovementHandler : IMoveHandler
    {
        private Transform _transform;
        private bool _isMoving;
        private Vector3 _dragDir;
        private Vector3 _velocity = Vector3.up;
        private float _speed = 1f;
        private Vector3 _calculatedVelocity = Vector3.up;

        private InputAction _positionInput;
        private InputAction _pressInput;

        private Vector2 _currentDelta;
        private float _swipeResistance = 5;
        
        public MovementHandler(Transform transform, InputAction positionInput, InputAction pressInput)
        {
            _transform = transform;
            _positionInput = positionInput;
            _pressInput = pressInput;

            _positionInput.Enable();
            _pressInput.Enable();

            _positionInput.performed += (context =>
            {
                _currentDelta = _positionInput.ReadValue<Vector2>();
            });
            _pressInput.performed += context =>
            {
                _isMoving = true;
            };

            _pressInput.canceled += context =>
            {
                _isMoving = false;
            };
        }
        
        public void Move()
        {
            if (_isMoving)
            {
                if (Mathf.Abs(_currentDelta.x) > _swipeResistance || Mathf.Abs(_currentDelta.y) > _swipeResistance)
                {
                    if (Mathf.Abs(_currentDelta.normalized.x) > 0.7f)
                    {
                        _calculatedVelocity = _currentDelta.normalized.x > 0 ? Vector3.right : Vector3.left;
                    }
                    else
                    {
                        _calculatedVelocity = _currentDelta.normalized.y > 0 ? Vector3.up : Vector3.down;
                    }
                }
                _velocity = _calculatedVelocity * _speed;
                _transform.position += _velocity * Time.deltaTime;
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