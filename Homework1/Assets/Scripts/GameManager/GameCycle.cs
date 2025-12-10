using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class GameCycle : MonoBehaviour
    {
        private List<IGameListener> _gameListeners = new List<IGameListener>();
        private List<IGameUpdateListener> _updateListeners = new List<IGameUpdateListener>();
        [SerializeField] private CanvasManager _canvasManager;

        private void Start()
        {
            //_canvasManager.StartButton.onClick.AddListener(StartGame);
            _canvasManager.PauseButton.onClick.AddListener(PauseGame);
            _canvasManager.ResumeButton.onClick.AddListener(ResumeGame);
        }

        public void CanStartGame()
        {
            StartGame();
        }
        public void StartGame()
        {
            Debug.Log("Game started");
            foreach (var listener in _gameListeners)
            {                
                if (listener is IGameStartListener gameStartListener)
                {
                    gameStartListener.StartGame();                
                }
            }
        }

        public void FinishGame()
        {
            foreach (var listener in _gameListeners)
            {
                if (listener is IGameFinishListener gameFinishListener)
                {
                    gameFinishListener.FinishGame();
                }
            }
        }

        public void PauseGame()
        {
            Debug.Log("Game paused");
            foreach (var listener in _gameListeners)
            {
                if (listener is IGamePauseListener gamePauseListener)
                {
                    gamePauseListener.PauseGame();
                }
            }
        }

        public void ResumeGame()
        {
            Debug.Log("Game resumed");
            foreach (var listener in _gameListeners)
            {
                if (listener is IGameResumeListener gameResumeListener)
                {
                    gameResumeListener.ResumeGame();
                }
            }
        }

        private void Update()
        {
            var delta = Time.deltaTime;
            foreach(var updateListener in _updateListeners)
            {
                updateListener.UpdateGame(delta);
            }
        }

        public void AddGameListener(IGameListener gameListener)
        {
            _gameListeners.Add(gameListener);
            if (gameListener is IGameUpdateListener gameUpdateListener)
            {
                _updateListeners.Add(gameUpdateListener);
            }
        }
    }
}