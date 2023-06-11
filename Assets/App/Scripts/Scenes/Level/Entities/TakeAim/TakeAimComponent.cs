using DG.Tweening;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace App.Scripts.Scenes.MainScene.Entities.TakeAim
{
    public class TakeAimComponent : MonoBehaviour
    {
        [SerializeField] private Transform _aimSphere;
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private AnimationController _animationController;
        [SerializeField] private Rig _rig;
        [SerializeField] private LevelConfigScriptableObject _levelConfig;

        private bool _isTakeAim;
        private Tween _rigWeightTween;
        private Sequence _takeAimSequence;
        private Vector3 _startLocalPosition;
        private Vector3 _startLocalEulerAngles;
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

            _rigWeightTween?.Kill();

            if (value == false)
            {
                _rigWeightTween = DOTween.To(() => _rig.weight, x => _rig.weight = x,
                    0f, _config.ChangeWeightDuration);
            }
            else
            {
                _rig.weight = 1;
                _startLocalPosition = transform.localPosition;
                _startLocalEulerAngles = transform.localEulerAngles;
            }
            
            _takeAimSequence?.Kill();
            _takeAimSequence = DOTween.Sequence();
            Vector3 targetLocalPosition = value ? _config.LocalMoveOffset + _startLocalPosition : _startLocalPosition;
            Vector3 targetEulerAngles = value ? _config.LocalEulerAnglesEnd : _startLocalEulerAngles;
            _takeAimSequence.Append(transform.DOLocalMove(targetLocalPosition, _config.TakeAimMoveDuration));
            _takeAimSequence.Append(transform.DOLocalRotate(targetEulerAngles, _config.TakeAimMoveDuration));
            
            _animationController.SetTakeAimBool(value);
        }
    }
}