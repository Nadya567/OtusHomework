using UnityEngine;

namespace ShootEmUp
{
    public interface IEnemySpawn
    {
        void InitializeEnemy(GameObject enemy, Transform spawnPosition, Transform attackPosition, GameObject target);
    }
}