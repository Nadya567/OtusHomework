using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemyAttack : MonoBehaviour, IEnemyAttack, IGameStartListener, IGameResumeListener, IGamePauseListener
    {
        [SerializeField] private BulletSystem _bulletSystem;
        public event Action EnemyFire;
        private List<EnemyAttackAgent> _activeEnemies = new List<EnemyAttackAgent>();

        public void OnFire(GameObject enemy, Vector2 position, Vector2 direction)
        {
            Debug.Log("Fire");
            _bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                isPlayer = false,
                physicsLayer = (int)PhysicsLayer.ENEMY,
                color = Color.red,
                damage = 1,
                position = position,
                velocity = direction * 2.0f
            });
        }

        public void AddAttackToEnemy(GameObject enemy)
        {
            //enemy.GetComponent<EnemyAttackAgent>().OnFire += OnFire;

            var agent = enemy.GetComponent<EnemyAttackAgent>();
            agent.OnFire += OnFire;//
            _activeEnemies.Add(agent);

            EnemyFire?.Invoke();
        }

        public void RemoveAttackFromEnemy(GameObject enemy)
        {
            //enemy.GetComponent<EnemyAttackAgent>().OnFire -= OnFire;

            var agent = enemy.GetComponent<EnemyAttackAgent>();
            _activeEnemies.Remove(agent);

            EnemyFire?.Invoke();
        }

        public void StartGame()
        {
            foreach(var agent in _activeEnemies)
            {
                agent.OnFire += OnFire;
            }
        }

        public void ResumeGame()
        {
            foreach (var agent in _activeEnemies)
            {
                agent.OnFire += OnFire;
            }
        }

        public void PauseGame()
        {
            foreach (var agent in _activeEnemies)
            {
                agent.OnFire -= OnFire;
            }
        }
    }
}