using UnityEngine;

namespace ShootEmUp
{
    public class SpawnEnemy : MonoBehaviour, IEnemySpawn
    {
        public void InitializeEnemy(GameObject enemy, Transform spawnPosition, Transform attackPosition, GameObject target)
        {
            enemy.transform.position = spawnPosition.position;
            enemy.GetComponent<EnemyMoveAgent>().SetDestination(attackPosition.position);
            enemy.GetComponent<EnemyAttackAgent>().SetTarget(target);
        }
    }
}