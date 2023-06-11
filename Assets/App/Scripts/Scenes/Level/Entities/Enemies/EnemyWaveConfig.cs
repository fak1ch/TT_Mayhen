using System;

namespace App.Scripts.Scenes.MainScene.Entities.Enemies
{
    [Serializable]
    public class EnemyWaveConfig
    {
        public float DelayBetweenSpawns = 2f;
        public int EnemiesCount = 5;
    }
}