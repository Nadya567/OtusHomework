using System;
using UnityEngine;

namespace ShootEmUp
{
    public interface IBulletCollisionHandler
    {
        void CollisionHandle(Bullet bullet, Collision2D collision2D);
        event Action<Bullet> BulletRemove;
    }
}