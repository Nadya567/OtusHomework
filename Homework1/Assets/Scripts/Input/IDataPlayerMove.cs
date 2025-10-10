using UnityEngine;

namespace ShootEmUp
{
    public interface IDataPlayerMove
    {
        Rigidbody2D Rigidbody2D { get; }
        float Speed { get; }
    }
}