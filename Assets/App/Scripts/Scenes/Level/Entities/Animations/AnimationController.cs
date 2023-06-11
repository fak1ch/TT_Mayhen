using System;
using App.Scripts.Scenes.MainScene.Entities.MovementSystem;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities
{
public class AnimationController : MonoBehaviour
    {
        public event Action OnAnimationEnd;
        
        [SerializeField] private Animator _animator;
        
        [SerializeField] private MovableComponent _movableComponent;
        [SerializeField] private AnimationControllerConfig _config;
        [SerializeField] private GroundChecker _groundChecker;
        
        private int _speedPercentHash;
        private int _isGroundHash;
        private int _jumpTriggerHash;
        private int _isTakeAim;

        private void Start()
        {
            _speedPercentHash = Animator.StringToHash(_config.SpeedPercentKey);
            _isGroundHash = Animator.StringToHash(_config.IsGroundKey);
            _jumpTriggerHash = Animator.StringToHash(_config.JumpTriggerKey);
            _isTakeAim = Animator.StringToHash(_config.IsTakeAimKey);
        }

        private void Update()
        {
            _animator.SetFloat(_speedPercentHash, _movableComponent.SpeedPercent);
            _animator.SetBool(_isGroundHash, _groundChecker.IsGround);
        }

        public void PullJumpTrigger()
        {
            PullAnimationTrigger(_jumpTriggerHash);
        }

        private void PullAnimationTrigger(int hash)
        {
            _animator.SetTrigger(hash);
        }
        
        private void UnityAnimationEndCallback()
        {
            OnAnimationEnd?.Invoke();
        }

        public void SetTakeAimBool(bool value)
        {
            _animator.SetBool(_isTakeAim, value);
        }
    }
}