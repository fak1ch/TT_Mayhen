using System;
using App.Scripts.Scenes.General;
using App.Scripts.Scenes.MainScene.Entities.MovementSystem;
using App.Scripts.Scenes.MainScene.Entities.TakeAim;
using App.Scripts.Scenes.MainScene.Inputs;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.Player
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private InputSystem _inputSystem;
        [SerializeField] private GunSlot _gunSlot;
        [SerializeField] private TakeAimComponent _takeAimComponent;
        [SerializeField] private MovableComponent _movableComponent;
        [SerializeField] private PlayerStateMachine _playerStateMachine;
        [SerializeField] private float _delayBeforeShoot = 0.01f;

        private CustomTimer _shootTimer;
        
        private void OnEnable()
        {
            _inputSystem.OnShootButtonDown += ShootButtonDownCallback;
            _inputSystem.OnShootButtonUp += ShootButtonUpCallback;
            _inputSystem.OnJumpButtonClicked += _movableComponent.Jump;
        }

        private void OnDisable()
        {
            _inputSystem.OnShootButtonDown -= ShootButtonDownCallback;
            _inputSystem.OnShootButtonUp -= ShootButtonUpCallback;
            _inputSystem.OnJumpButtonClicked -= _movableComponent.Jump;
        }

        private void Start()
        {
            _shootTimer = new CustomTimer();
            _shootTimer.OnEnd += _gunSlot.Shoot;
        }

        private void Update()
        {
            _shootTimer.Tick(Time.deltaTime);
            
            if (Input.GetKeyDown(KeyCode.G))
            {
                _playerStateMachine.RunToRight();
            }
            
                        
            if (Input.GetKeyDown(KeyCode.T))
            {
                _playerStateMachine.TakeCover();
            }
        }

        private void ShootButtonDownCallback()
        {
            _takeAimComponent.SetTakeAim(true);
            _shootTimer.StartTimer(_delayBeforeShoot);
        }
        
        private void ShootButtonUpCallback()
        {
            _takeAimComponent.SetTakeAim(false);
        }
    }
}