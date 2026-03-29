using UnityEngine;

namespace ShootEmUp
{
    public class BulletUtils : MonoBehaviour, IBulletDamageHandler
    {
        public void DealDamage(Bullet bullet, GameObject other)
        {
            if (!other.TryGetComponent<ITeam>(out ITeam team))
                return;

            if (bullet.BulletData.IsPlayer == team.IsPlayer)
                return;

            if (other.TryGetComponent<IHitPoints>(out IHitPoints hitPoints))
                hitPoints.TakeDamage(bullet.BulletData.Damage);
        }
    }
} 