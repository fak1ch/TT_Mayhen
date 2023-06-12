using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using App.Scripts.Scenes.MainScene.Entities.Player;
using UnityEngine;

namespace App.Scripts.Scenes.MainScene.Entities.Enemies
{
    public class EnemyWave : MonoBehaviour
    {
        [SerializeField] private CharacterShelter _characterShelter;
        [SerializeField] private EnemyContainer _enemyContainer;
        [SerializeField] private EnemyWaveConfig _config;
        [SerializeField] private List<EnemyPlace> _enemyPlaces;

        private int _enemiesCountKilled;
        
        private void Start()
        {
            _characterShelter.OnCharacterSitInShelter += StartWave;
        }

        private void StartWave()
        {
            StartCoroutine(SpawnEnemiesRoutine());
        }

        private IEnumerator SpawnEnemiesRoutine()
        {
            _enemiesCountKilled = _config.EnemiesCount;
            int enemiesCountSpawned = 0;

            while (_enemiesCountKilled > 0)
            { 
                EnemyPlace enemyPlace = GetEmptyEnemyPlace();

                if (enemyPlace != null && enemiesCountSpawned < _config.EnemiesCount)
                {
                    SpawnEnemyAtEnemyPlace(_enemyContainer.GetEnemy(), enemyPlace);
                    enemiesCountSpawned++;
                }

                yield return new WaitForSeconds(_config.DelayBetweenSpawns);
            }

            _characterShelter.ClearShelter();
        }

        private void SpawnEnemyAtEnemyPlace(Enemy enemy, EnemyPlace enemyPlace)
        {
            enemy.OnDie += DieEnemyCallback;
            enemyPlace.SetEnemyToPlace(enemy);
        }

        private void DieEnemyCallback(Enemy enemy)
        {
            _enemiesCountKilled--;
        }

        private EnemyPlace GetEmptyEnemyPlace()
        {
            return _enemyPlaces.FirstOrDefault(x => x.IsEmpty);
        }
    }
}