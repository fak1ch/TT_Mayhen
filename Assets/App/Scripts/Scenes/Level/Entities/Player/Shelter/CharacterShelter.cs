using System;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.Player
{
    public class CharacterShelter : MonoBehaviour
    {
        public event Action OnCharacterSitInShelter;
        
        [SerializeField] private Transform _characterPlace;
        [SerializeField] private CinemachineVirtualCamera _shelterVirtualCamera;
        [SerializeField]private CharacterShelterConfig _config;
        
        private Character _character;
        private Sequence _takeAimSequence;
        
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
            _character.TakeAimComponent.OnIsTakeAimChanged += IsTakeAimChangedCallback;
            _character.PlayerStateMachine.TakeCover();
            _character.transform.SetParent(_characterPlace);
            _character.transform.localPosition = Vector3.zero;
            _character.transform.localEulerAngles = Vector3.zero;
            _character.transform.localScale = Vector3.one;
            _shelterVirtualCamera.gameObject.SetActive(true);
            OnCharacterSitInShelter?.Invoke();
        }

        private void IsTakeAimChangedCallback(bool isTakeAim)
        {
            _takeAimSequence?.Kill();
            _takeAimSequence = DOTween.Sequence();
            Vector3 targetLocalPosition = isTakeAim ? _config.TakeAimPoint.position : _characterPlace.position;
            Vector3 targetEulerAngles = isTakeAim ? _config.TakeAimPoint.eulerAngles : _characterPlace.eulerAngles;
            float duration = isTakeAim ? _config.StartTakeAimDuration : _config.EndTakeAimDuration;
            _takeAimSequence.Insert(0,_character.transform.DOMove(targetLocalPosition, duration)
                .SetEase(_config.Ease).SetUpdate(UpdateType.Fixed));
            _takeAimSequence.Insert(0,_character.transform.DORotate(targetEulerAngles, duration)
                .SetEase(_config.Ease).SetUpdate(UpdateType.Fixed));
        }

        public void ClearShelter()
        {
            if(_character == null) return;
            
            _character.TakeAimComponent.OnIsTakeAimChanged -= IsTakeAimChangedCallback;
            _character.PlayerStateMachine.RunToRight();
            _shelterVirtualCamera.gameObject.SetActive(false);
            _character.transform.SetParent(null);
        }
    }
}