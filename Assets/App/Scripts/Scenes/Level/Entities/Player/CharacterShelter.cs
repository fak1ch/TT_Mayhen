using System;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.Player
{
    public class CharacterShelter : MonoBehaviour
    {
        public event Action OnCharacterSitInShelter;
        
        [SerializeField] private Transform _characterPlace;

        private Character _character;

        private void OnTriggerEnter(Collider other)
        {
            if(_character != null) return;
            
            if (other.attachedRigidbody.TryGetComponent(out Character character))
            {
                TakeShelter(character);
            }
        }

        private void TakeShelter(Character character)
        {
            _character = character;
            _character.PlayerStateMachine.TakeCover();
            _character.transform.SetParent(_characterPlace);
            _character.transform.localPosition = Vector3.zero;
            _character.transform.localScale = Vector3.one;
            OnCharacterSitInShelter?.Invoke();
        }

        public void ClearShelter()
        {
            if(_character == null) return;
            
            _character.PlayerStateMachine.RunToRight();
        }
    }
}