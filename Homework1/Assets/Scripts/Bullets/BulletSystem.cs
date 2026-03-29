using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour, IGameStartListener, IGamePauseListener, IGameResumeListener
    {
        [SerializeField] private IBulletCollisionHandler _bulletCollision;
        [SerializeField] private IBulletPool _bulletPool;

        [SerializeField] private int _initialCount = 50;       
        [SerializeField] private Transform _container;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _worldTransform;
        [SerializeField] private LevelBounds _levelBounds;

        private readonly HashSet<Bullet> _activeBullets = new();
        private readonly List<Bullet> _cache = new();
        public event Action BulletUpdate;
        
        private void Awake()
        {
            _bulletCollision = FindObjectOfType<BulletCollisionHandler>();    //Zenject
            _bulletCollision.BulletRemove += RemoveBullet;
            _bulletPool = new BulletPool(_bulletPrefab, _container, _initialCount);
        }
        
        private void FixedUpdate()
        {
            UpdateBullets();
        }

        private void UpdateBullets()
        {
            _cache.Clear();
            _cache.AddRange(_activeBullets);

            for (int i = 0, count = _cache.Count; i < count; i++)
            {
                var bullet = _cache[i];
                if (!_levelBounds.InBounds(bullet.transform.position))
                {
                    RemoveBullet(bullet);
                }
            }
        }

        public void FlyBulletByArgs(Args args)
        {
            var bullet = _bulletPool.Get();
            bullet.transform.SetParent(_worldTransform);

            bullet.SetPosition(args.position);
            bullet.SetColor(args.color);
            bullet.SetPhysicsLayer(args.physicsLayer);
            bullet.BulletData.Damage = args.damage;
            bullet.BulletData.IsPlayer = args.isPlayer;
            bullet.StartVelocity(args.velocity);
            
            if (_activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += _bulletCollision.CollisionHandle;
            }
        }       

        private void RemoveBullet(Bullet bullet)
        {
            if (_activeBullets.Remove(bullet))
            {
                bullet.OnCollisionEntered -= _bulletCollision.CollisionHandle;
                bullet.transform.SetParent(_container);
                _bulletPool.Return(bullet);
            }
        }

        public void StartGame()
        {
            
        }

        public void PauseGame()
        {
            foreach (var bullet in _activeBullets)
            {
                bullet.ResetVelocity();
            }               
        }

        public void ResumeGame()
        {
            foreach (var bullet in _activeBullets)
            {
                bullet.ReturnToStartVelocity();
            }
        }

        public struct Args
        {
            public Vector2 position;
            public Vector2 velocity;
            public Color color;
            public int physicsLayer;
            public int damage;
            public bool isPlayer;
        }
    }
}