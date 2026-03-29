using UnityEngine;

namespace ShootEmUp
{
    public class BoundsData : MonoBehaviour, IBoundsData
    {
        public float Left => _leftBorder.position.x;
        public float Right => _rightBorder.position.x;
        public float Top => _topBorder.position.y;
        public float Down => _downBorder.position.y;

        [SerializeField] private Transform _leftBorder;
        [SerializeField] private Transform _rightBorder;
        [SerializeField] private Transform _downBorder;
        [SerializeField] private Transform _topBorder;
    }
}