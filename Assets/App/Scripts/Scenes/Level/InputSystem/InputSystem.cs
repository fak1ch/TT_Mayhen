using System;
using App.Scripts.General.UI.ButtonSpace;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Inputs
{
    public class InputSystem : MonoBehaviour
    {
        public event Action OnJumpButtonClicked;
        public event Action<Vector2> OnShootButtonClicked;

        [SerializeField] private CustomButton _jumpButton;
        [SerializeField] private CustomButton _shootButton;
        [SerializeField] private LevelConfigScriptableObject _levelConfig;

        private InputSystemConfig _config => _levelConfig.InputSystemConfig;

        #region Events

        private void OnEnable()
        {
            _jumpButton.OnClickOccurred.AddListener(SendJumpButtonClickedEvent);
            _shootButton.OnClickOccurred.AddListener(SendShootButtonClickedEvent);
        }

        private void OnDisable()
        {
            _jumpButton.OnClickOccurred.RemoveListener(SendJumpButtonClickedEvent);
            _shootButton.OnClickOccurred.RemoveListener(SendShootButtonClickedEvent);
        }

        #endregion

        private void SendJumpButtonClickedEvent()
        {
            OnJumpButtonClicked?.Invoke();
        }
        
        private void SendShootButtonClickedEvent()
        {
            OnShootButtonClicked?.Invoke(_shootButton.LastClickPosition);
        }
    }
}