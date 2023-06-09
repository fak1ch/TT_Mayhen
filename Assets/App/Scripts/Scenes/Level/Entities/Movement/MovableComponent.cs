using System;
using App.Scripts.General.Utils;
using Cinemachine;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.MovementSystem
{
    public class MovableComponent : MonoBehaviour
    {
        public Vector3 MoveInput { get; private set; }
        public float SpeedPercent => MathUtils.GetPercent(0, _config.RunSpeed, _speed);

        [SerializeField] private MovableComponentConfig _config;
        [SerializeField] private AnimationController _animationController;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private GroundChecker _groundChecker;
        
        private bool _canMove = true;
        private float _targetSpeed;
        private float _speed;

        private void Update()
        {
            if(_canMove == false) return;
            
            SmoothSpeed();
        }

        private void SmoothSpeed()
        {
            _speed = Mathf.Lerp(_speed, _targetSpeed, _config.SmoothMultiplier);
        }

        private void FixedUpdate()
        {
            if(_canMove == false) return;

            Move(MoveInput);
        }

        private void Move(Vector3 moveInput)
        {
            Vector3 newVelocity = Time.deltaTime * _speed * moveInput;
            newVelocity = _canMove ? newVelocity : Vector3.zero;

            newVelocity.y = _rigidbody.velocity.y;

            SetVelocity(newVelocity);
        }

        public void Jump()
        {
            if(_groundChecker.IsGround == false) return;

            _rigidbody.velocity += Vector3.up * _config.JumpForce;
            _animationController.PullJumpTrigger();
        }

        public void SetCanMove(bool value)
        {
            _canMove = value;
            _targetSpeed = 0;
            _speed = 0;
        }

        public void SetMoveInput(Vector3 moveInput)
        {
            if (moveInput != Vector3.zero)
            {
                MoveInput = moveInput;
            }
            
            _targetSpeed = moveInput == Vector3.zero ? 0 : _targetSpeed;
        }
        
        private void SetVelocity(Vector3 velocity)
        {
            _rigidbody.velocity = velocity;
        }

        public void SetRigidbody(Rigidbody targetRigidbody)
        {
            _rigidbody = targetRigidbody;
        }
    }
}