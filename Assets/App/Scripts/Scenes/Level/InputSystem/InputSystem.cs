using System;
using App.Scripts.General.UI.ButtonSpace;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Inputs
{
    public class InputSystem : MonoBehaviour
    {
        public event Action OnJumpButtonClicked;
        public event Action OnShootButtonDown;
        public event Action OnShootButtonUp;

        public bool IsShootButtonHold => _shootButton.IsButtonHold;
        
        [SerializeField] private CustomButton _jumpButton;
        [SerializeField] private CustomButton _shootButton;
        [SerializeField] private LevelConfigScriptableObject _levelConfig;

        #region Events

        private void OnEnable()
        {
            _jumpButton.OnClickOccurred.AddListener(SendJumpButtonClickedEvent);
            _shootButton.OnMouseDown.AddListener(SendShootButtonDownEvent);
            _shootButton.OnMouseUp.AddListener(SendShootButtonUpEvent);
        }

        private void OnDisable()
        {
            _jumpButton.OnClickOccurred.RemoveListener(SendJumpButtonClickedEvent);
            _shootButton.OnMouseDown.RemoveListener(SendShootButtonDownEvent);
            _shootButton.OnMouseUp.RemoveListener(SendShootButtonUpEvent);
        }

        #endregion

        private void SendJumpButtonClickedEvent()
        {
            OnJumpButtonClicked?.Invoke();
        }
        
        private void SendShootButtonDownEvent()
        {
            OnShootButtonDown?.Invoke();
        }
        
        private void SendShootButtonUpEvent()
        {
            OnShootButtonUp?.Invoke();
        }
    }
}