using System;
using App.Scripts.General.Utils;
using App.Scripts.Scenes.MainScene.Entities.MovementSystem;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.AI
{
    public class AIComponent : MonoBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent;

        private void Start()
        {
            _healthComponent.OnTakeDamage += TakeDamageCallback;
        }

        private void TakeDamageCallback(int damage, Transform attacker)
        {
            
        }
    }
}