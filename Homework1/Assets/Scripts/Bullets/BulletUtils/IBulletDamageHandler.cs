using UnityEngine;

namespace ShootEmUp
{
    public interface IBulletDamageHandler
    {
        void DealDamage(Bullet bullet, GameObject other);
    }
} 