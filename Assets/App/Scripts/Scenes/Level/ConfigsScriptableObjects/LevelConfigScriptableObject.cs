using App.Scripts.Scenes.MainScene.Inputs;
using UnityEngine;

namespace App.Scripts.Scenes
{
    [CreateAssetMenu(menuName = "App/LevelSceneConfig", fileName = "LevelSceneConfig")]
    public class LevelConfigScriptableObject : ScriptableObject
    {
        public InputSystemConfig InputSystemConfig;
    }
}