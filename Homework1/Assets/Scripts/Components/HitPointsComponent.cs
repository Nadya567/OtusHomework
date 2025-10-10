using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class HitPointsComponent : MonoBehaviour, IHitPoints
    {
        public event Action<GameObject> HpEmpty;
        
        [SerializeField] private int _hitPoints;
        private Vector2 _position;

        public Vector2 Position => _position;

        public bool IsHitPointsExists() 
        {
            return _hitPoints > 0;
        }

        public void TakeDamage(int damage)
        {
            _hitPoints -= damage;
            if (_hitPoints <= 0)
            {
                HpEmpty?.Invoke(gameObject);
            }
        }
    }
}