using System;
using UnityEngine;

namespace ShootEmUp
{
    public class BulletCollisionHandler : MonoBehaviour, IBulletCollisionHandler
    {
        [SerializeField] private IBulletDamageHandler _bulletDamageHandler; //Zenject
        public event Action<Bullet> BulletRemove;

        private void Awake()
        {
            _bulletDamageHandler = FindObjectOfType<BulletUtils>();
        }

        public void CollisionHandle(Bullet bullet, Collision2D collision2D)
        {
            _bulletDamageHandler.DealDamage(bullet, collision2D.gameObject);
            BulletRemove?.Invoke(bullet);
        }
    }
}