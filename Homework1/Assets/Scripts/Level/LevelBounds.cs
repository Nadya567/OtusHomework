using UnityEngine;

namespace ShootEmUp
{
    public sealed class LevelBounds : MonoBehaviour
    {
        private IBoundsData _boundsData;

        private void Awake()
        {
            _boundsData = FindObjectOfType<BoundsData>();
        }
        public bool InBounds(Vector3 position)
        {
            bool result = position.x > _boundsData.Left
                       && position.x < _boundsData.Right
                       && position.y > _boundsData.Down
                       && position.y < _boundsData.Top;

            return result;
        }
    }
}