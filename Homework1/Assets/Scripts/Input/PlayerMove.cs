using UnityEngine;

namespace ShootEmUp
{
    public class PlayerMove : MonoBehaviour, IMovable
    {
        [SerializeField] private IDataPlayerMove _dataPlayer;  //Zenject

        private void Awake()
        {
            _dataPlayer = FindObjectOfType<DataPlayerMove>();
        }

        public void Move(int horizontalDirection)
        {
            var nextPosition = _dataPlayer.Rigidbody2D.position + horizontalDirection * Vector2.right * _dataPlayer.Speed;
            _dataPlayer.Rigidbody2D.MovePosition(nextPosition);
        }
    }
}