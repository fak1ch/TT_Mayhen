using System;
using App.Scripts.General.PatternState;
using App.Scripts.Scenes.MainScene.Entities.MovementSystem;
using App.Scripts.Scenes.MainScene.Entities.Player.PlayerStates;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.Player
{
    public class PlayerStateMachine : MonoBehaviour
    {
        [SerializeField] private MovableComponent _movableComponent;
        
        private StateMachine _stateMachine;
        private RunToRight _runToRightState;
        private TakeCover _takeCoverState;

        private void Start()
        {
            _runToRightState = new RunToRight(_movableComponent);
            _takeCoverState = new TakeCover(_movableComponent);
            _stateMachine = new StateMachine(_takeCoverState);
        }

        public void RunToRight()
        {
            _stateMachine.ChangeState(_runToRightState);
        }

        public void TakeCover()
        {
            _stateMachine.ChangeState(_takeCoverState);
        }
    }
}