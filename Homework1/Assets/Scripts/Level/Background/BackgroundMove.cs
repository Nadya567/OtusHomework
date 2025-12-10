using System;
using UnityEngine;

namespace ShootEmUp
{
    public class BackgroundMove : MonoBehaviour, IBackgroundMovable, IGameStartListener, IGameFinishListener, IGamePauseListener, IGameResumeListener
    {
        private IParamsBackground _params;
        public event Action OnScreenMove;

        //public BackgroundMove(IParamsBackground moveParams)
        //{
        //    _params = moveParams;
        //}

        public void Init(IParamsBackground moveParams)
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

        public void MoveScreen()
        {
            OnScreenMove?.Invoke();
        }

        public void StartGame()
        {
            OnScreenMove += Move;
        }

        public void FinishGame()
        {
            OnScreenMove -= Move;
        }

        public void PauseGame()
        {
            OnScreenMove -= Move;
        }

        public void ResumeGame()
        {
            OnScreenMove += Move;
        }
    }
}