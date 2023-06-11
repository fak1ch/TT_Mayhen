using App.Scripts.General.PatternState;
using App.Scripts.Scenes.MainScene.Entities.MovementSystem;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.Player.PlayerStates
{
    public class RunToRight : State
    {
        private readonly MovableComponent _movableComponent;

        public RunToRight(MovableComponent movableComponent)
        {
            _movableComponent = movableComponent;
        }

        public override void Enter()
        {
            _movableComponent.SetMoveInput(Vector3.right);
        }
    }
}