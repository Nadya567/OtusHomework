using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour, IGameStartListener, IGamePauseListener, IGameResumeListener
    {
        [SerializeField] private EnemyPool _enemyPool;

        [SerializeField] private IEnemyAttack _enemyAttack;
        [SerializeField] private IEnemyCycle _enemyCycle;

        private Coroutine _coroutine;

        private readonly HashSet<GameObject> m_activeEnemies = new();

        private float _startTime = 1;
        private float _currentTime;
        private bool _isUpdate;

        public void StartGame()
        {
            _isUpdate = true;
            _currentTime = _startTime;
            _coroutine = StartCoroutine(StartS());
        }

        public void ResumeGame()
        {
            Debug.Log("–≈«ﬁÃ≈");

            _isUpdate = true;
            _coroutine = StartCoroutine(StartS());
        }

        public void PauseGame()
        {
            Debug.Log("œ¿”«¿  " + _currentTime);

            _isUpdate = false;
            _startTime = _currentTime;
            StopCoroutine(_coroutine);
        }

        private IEnumerator StartS()
        {
            _enemyAttack = FindObjectOfType<EnemyAttack>(); //Zenject
            _enemyCycle = FindObjectOfType<EnemyCycle>();

            yield return new WaitForSeconds(_startTime);

            while (true)
            {
                //_enemyCycle.AddEnemyListener();
                var enemy = _enemyPool.SpawnEnemy();
                if (enemy != null)
                {
                    if (m_activeEnemies.Add(enemy))
                    {
                        enemy.GetComponent<HitPointsComponent>().HpEmpty += OnDestroyed;
                        _enemyAttack.AddAttackToEnemy(enemy);
                    }
                }

                _currentTime = 1;
                yield return new WaitForSeconds(1);
            }      
        }

        private void Update()
        {
            if(_isUpdate)
                _currentTime -= Time.deltaTime;
        }

        private void OnDestroyed(GameObject enemy)
        {
            //_enemyCycle.RemoveEnemyListener(enemy);
            if (m_activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().HpEmpty -= OnDestroyed;
                _enemyAttack.RemoveAttackFromEnemy(enemy);
                _enemyPool.UnspawnEnemy(enemy);
            }
        }


    }

    public interface IEnemyAttack
    {
        void OnFire(GameObject enemy, Vector2 position, Vector2 direction);
        void AddAttackToEnemy(GameObject enemy);
        void RemoveAttackFromEnemy(GameObject enemy);
    }

    public interface IEnemyCycle
    {
        void AddEnemyListener();
        void RemoveEnemyListener(GameObject enemy);
    }

    public class EnemyCycle : MonoBehaviour, IEnemyCycle
    {
        [SerializeField] private EnemyPool _enemyPool;
        private readonly HashSet<GameObject> m_activeEnemies = new();
        public void AddEnemyListener()
        {
            var enemy = _enemyPool.SpawnEnemy();
            if (enemy != null)
            {
                if (m_activeEnemies.Add(enemy))
                {
                    enemy.GetComponent<HitPointsComponent>().HpEmpty += RemoveEnemyListener;
                }
            }
        }

        public void RemoveEnemyListener(GameObject enemy)
        {
            if (m_activeEnemies.Remove(enemy))
            {
                enemy.GetComponent<HitPointsComponent>().HpEmpty -= RemoveEnemyListener;

                _enemyPool.UnspawnEnemy(enemy);
            }
        }
    }
}