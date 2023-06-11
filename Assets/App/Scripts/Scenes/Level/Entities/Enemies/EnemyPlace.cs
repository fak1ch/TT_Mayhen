using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.Enemies
{
    public class EnemyPlace : MonoBehaviour
    {
        public bool IsEmpty => _enemy == null;
        
        [SerializeField] private Transform _spawnPoint;

        private Enemy _enemy;

        public void SetEnemyToPlace(Enemy enemy)
        {
            enemy.OnDie += ClearEnemyPlace;
            
            _enemy = enemy;
            _enemy.transform.SetParent(_spawnPoint);
            _enemy.transform.localPosition = Vector3.zero;
            _enemy.transform.localEulerAngles = Vector3.zero;
            _enemy.gameObject.SetActive(true);
        }

        private void ClearEnemyPlace(Enemy enemy)
        {
            _enemy.gameObject.SetActive(false);
            enemy.OnDie -= ClearEnemyPlace;
            _enemy = null;
        }
    }
}