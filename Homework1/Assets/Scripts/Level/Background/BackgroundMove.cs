using UnityEngine;

namespace ShootEmUp
{
    public class BackgroundMove : IBackgroundMovable
    {
        private IParamsBackground _params;

        public BackgroundMove(IParamsBackground moveParams)
        {
            _params = moveParams;
        }

        public void Move()
        {
            if (_params.Move.position.y <= _params.EndPositionY)
            {
                _params.Move.position = _params.StartPosition;
            }

            _params.Move.position -= Vector3.down * Time.fixedDeltaTime * _params.Speed;
        }
    }
}