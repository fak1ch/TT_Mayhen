using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace App.Scripts.Scenes.MainScene.Entities.TakeAim
{
    public class TakeAimComponent : MonoBehaviour
    {
        public event Action<bool> OnIsTakeAimChanged;
        
        [SerializeField] private Transform _aimSphere;
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private AnimationController _animationController;
        [SerializeField] private Rig _rig;
        [SerializeField] private LevelConfigScriptableObject _levelConfig;

        private bool _isTakeAim = false;
        private Tween _rigWeightTween;
        private TakeAimConfig _config => _levelConfig.TakeAimConfig;

        private void Update()
        {
            ChangeAimSpherePosition();
        }

        private void ChangeAimSpherePosition()
        {
            if (_isTakeAim)
            {
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit raycastHit))
                {
                    _aimSphere.transform.position = raycastHit.point;
                }
                else
                {
                    Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _config.AimSphereZ);
                    _aimSphere.transform.position = _mainCamera.ScreenToWorldPoint(mousePosition);
                }
            }
        }
        
        public void SetTakeAim(bool value)
        {
            _isTakeAim = value;
            OnIsTakeAimChanged?.Invoke(_isTakeAim);

            float weightEndValue = _isTakeAim ? 1 : 0;
            float changeWeightDuration = _isTakeAim ? 0 : _config.ChangeWeightDuration;
            
            _rigWeightTween?.Kill();
            _rigWeightTween = DOTween.To(() => _rig.weight, x => _rig.weight = x,
                weightEndValue, changeWeightDuration);

            _animationController.SetTakeAimBool(value);
        }
    }
}