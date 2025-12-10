using UnityEngine;

namespace ShootEmUp
{
    public interface IMovableComponent
    {
        void Move(Vector2 vector);
        void MoveActionStart(Vector2 vector);
    }
}