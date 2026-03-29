using System;
using UnityEngine;

namespace ShootEmUp
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField] private GameCycle _gameCycle;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private BackgroundMove _backgroundMove;
        [SerializeField] private InputKeyboard _inputKeyboard;
        [SerializeField] private EnemyAttack _enemyAttack;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private EnemyManager _enemyManager;
        [SerializeField] private BulletSystem _bulletSystem;


        private void Awake()
        {
            _gameCycle.AddGameListener(_characterController);
            _gameCycle.AddGameListener(_backgroundMove);
            _gameCycle.AddGameListener(_inputKeyboard);
            _gameCycle.AddGameListener(_enemyAttack);
            _gameCycle.AddGameListener(_moveComponent);
            _gameCycle.AddGameListener(_enemyManager);
            _gameCycle.AddGameListener(_bulletSystem);

            _enemyPool.OnInitialized += AddMoveComponents;
        }

        private void AddMoveComponents()
        {
            for(int i = 0; i < _enemyPool.AllMoveComponents.Length; i++)
            {
                int j = i;
                _gameCycle.AddGameListener(_enemyPool.AllMoveComponents[j]);
            }
        }
    }
}