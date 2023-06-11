using App.Scripts.General.PatternState;
using App.Scripts.Scenes.MainScene.Entities.MovementSystem;

namespace App.Scripts.Scenes.MainScene.Entities.Player.PlayerStates
{
    public class TakeCover : State
    {
        private readonly MovableComponent _movableComponent;

        public TakeCover(MovableComponent movableComponent)
        {
            _movableComponent = movableComponent;
        }

        public override void Enter()
        {
            _movableComponent.SetCanMove(false);
        }

        public override void Exit()
        {
            _movableComponent.SetCanMove(true);
        }
    }
}