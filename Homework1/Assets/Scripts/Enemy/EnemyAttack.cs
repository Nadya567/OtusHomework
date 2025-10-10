using UnityEngine;

namespace ShootEmUp
{
    public class EnemyAttack : MonoBehaviour, IEnemyAttack
    {
        [SerializeField] private BulletSystem _bulletSystem;

        public void OnFire(GameObject enemy, Vector2 position, Vector2 direction)
        {
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
            enemy.GetComponent<EnemyAttackAgent>().OnFire += OnFire;
        }

        public void RemoveAttackFromEnemy(GameObject enemy)
        {
            enemy.GetComponent<EnemyAttackAgent>().OnFire -= OnFire;
        }
    }
}