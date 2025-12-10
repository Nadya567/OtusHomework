using UnityEngine;

namespace ShootEmUp
{
    public class LevelBackgroundController : MonoBehaviour
    {
        [SerializeField] private IParamsBackground _params;
        [SerializeField] private IBackgroundMovable _backgroundMovable;

        private void Awake()
        {
            _params = FindObjectOfType<ParamsBackground>();
            _backgroundMovable = FindObjectOfType <BackgroundMove>();
            _backgroundMovable.Init(_params);
        }

        private void FixedUpdate()
        {
            _backgroundMovable.MoveScreen();
        }
    }
}