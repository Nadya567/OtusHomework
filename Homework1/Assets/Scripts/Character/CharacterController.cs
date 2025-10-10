using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour
    {
        [SerializeField] private ICharacterShoot _characterShoot;

        [SerializeField] private GameObject _character; 
        [SerializeField] private IGameManager _gameManager;
        [SerializeField] private InputManager _inputManager;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>(); //Zenject
            _characterShoot = FindObjectOfType<CharacterShoot>();
        }

        private void OnEnable()
        {
            _inputManager.InputMove.Fire += _characterShoot.OnFlyBullet;
            _character.GetComponent<HitPointsComponent>().HpEmpty += OnCharacterDeath;
        }
            
        private void OnDisable()
        {
            _inputManager.InputMove.Fire -= _characterShoot.OnFlyBullet;
            _character.GetComponent<HitPointsComponent>().HpEmpty -= OnCharacterDeath;
        }
            
        private void OnCharacterDeath(GameObject _) =>
            _gameManager.FinishGame();
    }
}