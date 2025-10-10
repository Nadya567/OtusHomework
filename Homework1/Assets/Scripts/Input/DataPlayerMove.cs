using UnityEngine;

namespace ShootEmUp
{
    public class DataPlayerMove : MonoBehaviour, IDataPlayerMove
    {
        [field: SerializeField] public Rigidbody2D Rigidbody2D { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
    }
}