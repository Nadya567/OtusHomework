using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPositions : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPositions;
        [SerializeField] private Transform[] _attackPositions;
        [SerializeField] private IRandomable _randomTransform;

        private void Start()
        {
            _randomTransform = FindObjectOfType<RandomTransform>(); //Zenject
        }

        public Transform RandomSpawnPosition()
        {
            return _randomTransform.GetRandomTransform(_spawnPositions);
        }

        public Transform RandomAttackPosition()
        {
            return _randomTransform.GetRandomTransform(_attackPositions);
        }
    }
}