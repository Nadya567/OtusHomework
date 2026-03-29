using System;
using UnityEngine;

namespace ShootEmUp
{
    public class InputKeyboard : MonoBehaviour, IInput, IGameStartListener, IGameResumeListener, IGamePauseListener
    {
        public event Action<int> RightLeftMovement;
        public event Action Fire;
        public event Action KeybordInputCame;

        private void Update()
        {
            KeybordInputCame?.Invoke();
        }

        private void ReadInputs()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fire?.Invoke();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                RightLeftMovement?.Invoke(-1);
            }

            else if (Input.GetKey(KeyCode.RightArrow))
            {
                RightLeftMovement?.Invoke(1);
            }
        }

        public void StartGame()
        {
            KeybordInputCame += ReadInputs;
        }

        public void ResumeGame()
        {
            KeybordInputCame += ReadInputs;
        }

        public void PauseGame()
        {
            KeybordInputCame -= ReadInputs;
        }
    }
}