using System;

namespace App.Scripts.Scenes.MainScene.Entities
{
    [Serializable]
    public class AnimationControllerConfig
    {
        public string SpeedPercentKey = "SpeedPercent";
        public string IsTakeAimKey = "IsTakeAim";
        public string IsGroundKey = "IsGround";
        public string JumpTriggerKey = "JumpTrigger";
    }
}