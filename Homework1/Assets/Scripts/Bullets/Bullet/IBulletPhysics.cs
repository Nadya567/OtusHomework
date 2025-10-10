using UnityEngine;

namespace ShootEmUp
{
    public interface IBulletPhysics
    {
        void SetVelocity(Vector2 velocity);
        void SetPhysicsLayer(int physicsLayer);
        void SetPosition(Vector3 position);
    }
}