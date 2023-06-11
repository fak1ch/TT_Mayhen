using App.Scripts.Scenes.MainScene.Entities.TakeAim;
using UnityEngine;

namespace App.Scripts.Scenes
{
    [CreateAssetMenu(menuName = "App/LevelSceneConfig", fileName = "LevelSceneConfig")]
    public class LevelConfigScriptableObject : ScriptableObject
    {
        public TakeAimConfig TakeAimConfig;
    }
}