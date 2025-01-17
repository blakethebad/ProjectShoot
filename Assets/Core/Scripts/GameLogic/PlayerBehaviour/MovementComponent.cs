﻿using ProjectShoot.Core.GameLogic.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectShoot.Core.GameLogic.PlayerBehaviour
{
    public sealed class MovementComponent : IMoveComponent
    {
        private readonly Transform _transform;
        private bool _isMoving;
        
        private Vector3 _velocity = Vector3.up;
        private Vector2 _currentDelta;
        
        private IMoveStrategy _strategy;
        private IModifiableStat<int> _speed;

        public MovementComponent(Transform transform, IModifiableStat<int> speed, InputAction positionInput, InputAction pressInput)
        {
            _transform = transform;
            _speed = speed;
            _strategy = new RegularMoveStrategy();
            positionInput.Enable();
            pressInput.Enable();

            positionInput.performed += (context =>
            {
                _currentDelta = positionInput.ReadValue<Vector2>();
            });
            pressInput.performed += context =>
            {
                _isMoving = true;
            };
            pressInput.canceled += context =>
            {
                _isMoving = false;
            };
        }
        
        
        public Vector3 GetDirection() => _velocity.normalized;
        public Vector3 GetPosition() => _transform.position;
        public IModifiableStat<int> GetSpeed() => _speed;
        
        public void Move()
        {
            if (_isMoving)
            {
                _velocity = _strategy.Execute(_currentDelta, _speed.Get(), 5) * Time.deltaTime;
                _transform.position += _velocity;
            }
            _transform.up = _velocity;
        }

    }
}