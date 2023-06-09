using System;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent;

        private void Start()
        {
            _healthComponent.OnHealthEqualsZero += EnemyDieCallback;
        }

        private void EnemyDieCallback()
        {
            
        }
    }
}