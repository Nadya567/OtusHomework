using System;
using UnityEngine;

namespace ShootEmUp
{
    public class InputKeyboard : MonoBehaviour, IInput
    {
        public event Action<int> RightLeftMovement;
        public event Action Fire;

        private void Update()
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
    }
}