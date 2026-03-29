using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class CanvasManager : MonoBehaviour
    {
        public Button StartButton;
        public Button PauseButton;
        public Button ResumeButton;
        [SerializeField] private TMP_Text _timeToStartText;
        [SerializeField] private GameCycle _gameCycle;
        private float _timeToStart = 3;

        private void Start()
        {
            StartButton.gameObject.SetActive(true);
            PauseButton.gameObject.SetActive(false);
            ResumeButton.gameObject.SetActive(false);
            _timeToStartText.gameObject.SetActive(false);

            StartButton.onClick.AddListener(StartGame);
            PauseButton.onClick.AddListener(PauseGame);
            ResumeButton.onClick.AddListener(ResumeGame);
        }

        private void StartGame()
        {
            StartButton.gameObject.SetActive(false);
            _timeToStartText.gameObject.SetActive(true);
            StartCoroutine(CountDownCoroutine());
        }

        private void PauseGame()
        {
            PauseButton.gameObject.SetActive(false);
            ResumeButton.gameObject.SetActive(true);
        }

        private void ResumeGame()
        {
            PauseButton.gameObject.SetActive(true);
            ResumeButton.gameObject.SetActive(false);
        }

        private IEnumerator CountDownCoroutine()
        {
            float time = _timeToStart;
            while (time > 0)
            {
                _timeToStartText.text = time.ToString();
                time--;
                yield return new WaitForSeconds(1f);
            }
            _timeToStartText.gameObject.SetActive(false);
            PauseButton.gameObject.SetActive(true);
            _gameCycle.CanStartGame();
        }
    }
}