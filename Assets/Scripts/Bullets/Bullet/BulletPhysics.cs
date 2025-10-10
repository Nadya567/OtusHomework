using UnityEngine;

namespace ShootEmUp
{
    public class BulletPhysics : MonoBehaviour, IBulletPhysics
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        public void SetPhysicsLayer(int physicsLayer)
        {            
            gameObject.layer = physicsLayer;
        }

        public void SetPosition(Vector3 position)
        {           
            transform.position = position;
        }

        public void SetVelocity(Vector2 velocity)
        {
            _rigidbody2D.linearVelocity = velocity;
        }
    }
}