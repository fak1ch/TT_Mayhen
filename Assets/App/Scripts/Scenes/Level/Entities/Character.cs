using System;
using App.Scripts.General.LoadScene;
using App.Scripts.Scenes.MainScene.Entities.MovementSystem;
using App.Scripts.Scenes.MainScene.Entities.Player;
using App.Scripts.Scenes.MainScene.Entities.TakeAim;
using App.Scripts.Scenes.MainScene.Map;
using App.Scripts.Scenes.ParticleConfig;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities
{
    public class Character : MonoBehaviour
    {
        public EffectsPoolContainer EffectsPoolContainer => _effectsPoolContainer;
        public PlayerStateMachine PlayerStateMachine => _playerStateMachine;
        public TakeAimComponent TakeAimComponent => _takeAimComponent;
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private EffectsPoolContainer _effectsPoolContainer;
        [SerializeField] private PlayerStateMachine _playerStateMachine;
        [SerializeField] private TakeAimComponent _takeAimComponent;

        private void Start()
        {
            _healthComponent.OnHealthEqualsZero += CharacterDieCallback;
        }

        private void CharacterDieCallback()
        {
            
        }
    }
}