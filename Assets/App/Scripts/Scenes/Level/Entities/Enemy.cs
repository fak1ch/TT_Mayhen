using System;
using App.Scripts.General.ObjectPool;
using App.Scripts.Scenes.MainScene.Entities.Enemies;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities
{
    public class Enemy : MonoBehaviour
    {
        public event Action<Enemy> OnDie;
        
        [SerializeField] private HealthComponent _healthComponent;

        private EnemyContainer _enemyContainer;

        private void OnEnable()
        {
            _healthComponent.OnHealthEqualsZero += EnemyDieCallback;
        }

        private void OnDisable()
        {
            _healthComponent.OnHealthEqualsZero -= EnemyDieCallback;
        }

        public void Initialize(EnemyContainer enemyContainer)
        {
            _enemyContainer = enemyContainer;
        }

        private void EnemyDieCallback()
        {
            _enemyContainer.ReturnEnemy(this);
            OnDie?.Invoke(this);
        }
    }
}