using UnityEngine;

namespace ShootEmUp
{
    public class BulletData : MonoBehaviour, IBulletData
    {
        public bool IsPlayer { get; set; }
        public int Damage { get; set; }
    }
}