using UnityEngine;

namespace ShootEmUp
{
    public interface IParamsBackground
    {
        Transform Move { get; }
        Vector2 StartPosition { get; }
        float EndPositionY { get; }
        float Speed { get; }
    }
}