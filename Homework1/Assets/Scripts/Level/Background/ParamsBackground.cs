using UnityEngine;

namespace ShootEmUp
{
    public sealed class ParamsBackground : MonoBehaviour, IParamsBackground
    {
        [field: SerializeField] public Transform Move { get; private set; }
        [field: SerializeField] public Vector2 StartPosition { get; private set; }
        [field: SerializeField] public float EndPositionY { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
    }
}