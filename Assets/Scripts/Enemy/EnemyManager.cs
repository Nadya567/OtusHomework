using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    //public sealed class EnemyManager : MonoBehaviour
    //{
    //    [SerializeField] private EnemyPool _enemyPool;
    //    [SerializeField] private BulletSystem _bulletSystem;

    //    private readonly HashSet<GameObject> m_activeEnemies = new();

    //    private IEnumerator Start()
    //    {
    //        while (true)
    //        {
    //            yield return new WaitForSeconds(1);
    //            var enemy = _enemyPool.SpawnEnemy();
    //            if (enemy != null)
    //            {
    //                if (m_activeEnemies.Add(enemy))
    //                {
    //                    enemy.GetComponent<HitPointsComponent>().HpEmpty += OnDestroyed;
    //                    enemy.GetComponent<EnemyAttackAgent>().OnFire += OnFire;
    //                }
    //            }
    //        }
    //    }

    //    private void OnDestroyed(GameObject enemy)
    //    {
    //        if (m_activeEnemies.Remove(enemy))
    //        {
    //            enemy.GetComponent<HitPointsComponent>().HpEmpty -= OnDestroyed;
    //            enemy.GetComponent<EnemyAttackAgent>().OnFire -= OnFire;

    //            _enemyPool.UnspawnEnemy(enemy);
    //        }
    //    }

    //    private void OnFire(GameObject enemy, Vector2 position, Vector2 direction)
    //    {
    //        _bulletSystem.FlyBulletByArgs(new BulletSystem.Args
    //        {
    //            isPlayer = false,
    //            physicsLayer = (int)PhysicsLayer.ENEMY,
    //            color = Color.red,
    //            damage = 1,
    //            position = position,
    //            velocity = direction * 2.0f
    //        });
    //    }
    //}


    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField] private EnemyPool _enemyPool;

        [SerializeField] private IEnemyAttack _enemyAttack;
        [SerializeField] private IEnemyCycle _enemyCycle;
        
        private readonly HashSet<GameObject> m_activeEnemies = new();

        private IEnumerator Start()
        {
            _enemyAttack = FindObjectOfType<EnemyAttack>(); //Zenject
            _enemyCycle = FindObjectOfType<EnemyCycle>();

            while(true)
            {
                yield return new WaitForSeconds(1);
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
            }      
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