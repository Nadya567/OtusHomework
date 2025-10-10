using UnityEngine;

namespace ShootEmUp
{
    public interface IRandomable
    {
        Transform GetRandomTransform(Transform[] transforms);
    }
}