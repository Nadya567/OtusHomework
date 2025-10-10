using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet, Collision2D> OnCollisionEntered;

        [SerializeField] private IBulletPhysics _bulletPhisics;
        [SerializeField] private IBulletVisual _bulletVisual;   //Zenject
        [HideInInspector] public IBulletData BulletData;

        private void Awake()
        {
            _bulletPhisics = FindObjectOfType<BulletPhysics>();
            _bulletVisual = FindObjectOfType<BulletVisual>();
            BulletData = FindObjectOfType<BulletData>();
        }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEntered?.Invoke(this, collision);
        }

        public void SetVelocity(Vector2 velocity)
        {
            _bulletPhisics.SetVelocity(velocity);
        }

        public void SetPhysicsLayer(int physicsLayer)
        {
            _bulletPhisics.SetPhysicsLayer(physicsLayer);
        }

        public void SetPosition(Vector3 position)
        {
            _bulletPhisics.SetPosition(position);
        }

        public void SetColor(Color color)
        {
            _bulletVisual.SetColor(color);
        }
    }
}