using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;

        [HideInInspector] public IInput InputMove;
        [SerializeField] private IMovable _move;

        private void Awake()        //Zenject
        {
            InputMove = FindObjectOfType<InputKeyboard>();
            _move = FindObjectOfType<PlayerMove>();
        }

        private void Start()
        {
            InputMove.RightLeftMovement += _move.Move;
        }
    }
}