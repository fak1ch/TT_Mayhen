using System;
using System.Collections.Generic;
using App.Scripts.General.ObjectPool;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.Enemies
{
    public class EnemyContainer : MonoBehaviour
    {
        [SerializeField] private PoolData<Enemy> _enemyPoolData;
        [SerializeField] private List<Enemy> _activeEnemies;

        private ObjectPool<Enemy> _enemyPool;

        private void Start()
        {
            _enemyPool = new ObjectPool<Enemy>(_enemyPoolData);
        }

        public Enemy GetEnemy()
        {
            Enemy enemy = _enemyPool.GetElement();
            _activeEnemies.Add(enemy);
            enemy.Initialize(this);

            return enemy;
        }

        public void ReturnEnemy(Enemy enemy)
        {
            _activeEnemies.Remove(enemy);
            _enemyPool.ReturnElementToPool(enemy);
        }
    }
}