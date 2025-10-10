using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class BulletPool : IBulletPool
    {
        private readonly Queue<Bullet> _pool = new();
        private readonly Bullet _prefab;
        private readonly Transform _container;

        public BulletPool(Bullet prefab, Transform container, int initialCount)
        {
            _prefab = prefab;
            _container = container;

            for(int i =0; i < initialCount; i++)
            {
                var bullet = UnityEngine.Object.Instantiate(prefab, _container);
                _pool.Enqueue(bullet);
            }
        }

        public Bullet Get()
        {
            return _pool.Count > 0 ? _pool.Dequeue() : UnityEngine.Object.Instantiate(_prefab, _container);
        }

        public void Return(Bullet bullet)
        {
            _pool.Enqueue(bullet);
        }
    }
}