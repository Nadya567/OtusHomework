using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class MoveComponent : MonoBehaviour, IMovableComponent, IGameStartListener, IGameResumeListener, IGamePauseListener
    {
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private float speed = 5.0f;

        public event Action<Vector2> OnEnemyMovable;
        private bool _isReady;

        public void Move(Vector2 vector)
        {
            var nextPosition = rigidbody2D.position + vector * speed;
            rigidbody2D.MovePosition(nextPosition);
        }

        public void StartGame()
        {
            OnEnemyMovable += Move;
            _isReady = true;
            Debug.Log("Start 111111" + _isReady);
        }

        public void PauseGame()
        {
            OnEnemyMovable -= Move;
            _isReady = false;
            Debug.Log("Pause 111111");
        }

        public void ResumeGame()
        {
            OnEnemyMovable += Move;
            _isReady = true;
            Debug.Log("Resume 111111");
        }

        public void MoveActionStart(Vector2 vector)
        {
            if (!_isReady)
            {
                Debug.LogWarning("MoveComponent ещЄ не инициализирован Ч StartGame() не был вызван!" + _isReady);
                return;
            }

            OnEnemyMovable?.Invoke(vector);

            int count = OnEnemyMovable?.GetInvocationList().Length ?? 0;
            Debug.Log(count);
        }
    }
}