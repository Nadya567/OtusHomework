using UnityEngine;

namespace ShootEmUp
{
    public class CharacterShoot : MonoBehaviour, ICharacterShoot
    {
        [SerializeField] private GameObject _character;
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private BulletConfig _bulletConfig;
        [SerializeField] private WeaponComponent _weapon;

        public void OnFlyBullet()
        {
            _bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                isPlayer = true,
                physicsLayer = (int)_bulletConfig.PhysicsLayer,
                color = _bulletConfig.Color,
                damage = _bulletConfig.Damage,
                position = _weapon.Position,
                velocity = _weapon.Rotation * Vector3.up * _bulletConfig.Speed
            });
        }
    }
}