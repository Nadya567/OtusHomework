using UnityEngine;

namespace ShootEmUp
{
    public class BulletVisual : MonoBehaviour, IBulletVisual
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        public void SetColor(Color color)
        {
            _spriteRenderer.color = color;
        }
    }
}