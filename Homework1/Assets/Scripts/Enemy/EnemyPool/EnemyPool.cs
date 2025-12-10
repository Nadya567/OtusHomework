using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour, IGameStartListener, IGameResumeListener, IGamePauseListener
    {
        public MoveComponent[] AllMoveComponents { get; private set; }
        public event Action OnInitialized;

        [Header("Spawn")]
        [SerializeField] private EnemyPositions _enemyPositions;
        [SerializeField] private GameObject _character;
        [SerializeField] private Transform _worldTransform;

        [SerializeField] private IEnemySpawn _spawnEnemy;

        [Header("Pool")]
        [SerializeField] private Transform _container;
        [SerializeField] private GameObject _prefab;

        private readonly Queue<GameObject> _enemyPool = new();
        private int _maximumEnemyCount = 7;
        //public event Action EnemySpawn;

        private void Start()
        {
            _spawnEnemy = FindObjectOfType<SpawnEnemy>(); //Zenject
            AllMoveComponents = new MoveComponent[_maximumEnemyCount];

            for (var i = 0; i < _maximumEnemyCount; i++)
            {
                var enemy = Instantiate(_prefab, _container);
                MoveComponent moveComponent = enemy.GetComponent<MoveComponent>();
                AllMoveComponents[i] = moveComponent;

                _enemyPool.Enqueue(enemy);
            }

            OnInitialized?.Invoke();
        }

        public GameObject SpawnEnemy()
        {
            if (!_enemyPool.TryDequeue(out var enemy))
            {
                return null;
            }

            enemy.transform.SetParent(_worldTransform);

            var spawnPosition = _enemyPositions.RandomSpawnPosition();
            var attackPosition = _enemyPositions.RandomAttackPosition();
            _spawnEnemy.InitializeEnemy(enemy, spawnPosition, attackPosition, _character);
            return enemy;
        }

        public void UnspawnEnemy(GameObject enemy)
        {
            enemy.transform.SetParent(_container);
            _enemyPool.Enqueue(enemy);
        }

        public void StartGame()
        {
            
        }

        public void ResumeGame()
        {
            
        }

        public void PauseGame()
        {
            
        }
    }
}