using UnityEngine;

namespace ShootEmUp
{
    public class RandomTransform : MonoBehaviour, IRandomable
    {
        public Transform GetRandomTransform(Transform[] transforms)
        {
            var index = Random.Range(0, transforms.Length);
            return transforms[index];
        }
    }
}