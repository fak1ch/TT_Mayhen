using System;
using App.Scripts.Scenes.MainScene.Entities.MovementSystem;
using App.Scripts.Scenes.MainScene.Inputs;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.Player
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private InputSystem _inputSystem;
        [SerializeField] private GunSlot _gunSlot;
        [SerializeField] private MovableComponent _movableComponent;

        private void OnEnable()
        {
            _inputSystem.OnShootButtonClicked += _gunSlot.Shoot;
            _inputSystem.OnJumpButtonClicked += _movableComponent.Jump;
        }

        private void OnDisable()
        {
            _inputSystem.OnShootButtonClicked -= _gunSlot.Shoot;
            _inputSystem.OnJumpButtonClicked -= _movableComponent.Jump;
        }

        private void Update()
        {
            _movableComponent.SetMoveInput(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        }
    }
}