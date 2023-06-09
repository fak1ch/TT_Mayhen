using System;
using App.Scripts.General.LoadScene;
using App.Scripts.Scenes.MainScene.Entities.MovementSystem;
using App.Scripts.Scenes.MainScene.Entities.Player;
using App.Scripts.Scenes.ParticleConfig;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities
{
    public class Character : MonoBehaviour
    {
        public EffectsPoolContainer EffectsPoolContainer => _effectsPoolContainer;
        public AnimationController AnimationController => _animationController;

        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private AnimationController _animationController;
        [SerializeField] private EffectsPoolContainer _effectsPoolContainer;

        private void Start()
        {
            _healthComponent.OnHealthEqualsZero += CharacterDieCallback;
        }

        private void CharacterDieCallback()
        {
            
        }
    }
}