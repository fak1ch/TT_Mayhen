using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.MovementSystem
{
    public class RotatorByInput : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 1;
        
        public void Rotate(Transform target, Vector3 input)
        {
            Quaternion toRotation = Quaternion.LookRotation(input, Vector3.up);

            target.rotation = Quaternion.RotateTowards(target.rotation, toRotation,
                _rotationSpeed * Time.deltaTime);
        }
    }
}