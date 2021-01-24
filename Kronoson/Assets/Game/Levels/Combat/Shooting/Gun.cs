using UnityEngine;

namespace Game.Levels.Combat.Shooting
{
    [CreateAssetMenu(fileName = "NewGun", menuName = "Weapons/Gun", order = 0)]
    public class Gun : ScriptableObject
    {
        public bool IsAutomatic = false;
        public Rigidbody2D Bullet;
        [Range(0, 100)] public float Range = 15f;
        [Range(0, 100)] public float FireRate = 0.2f;
        [Range(0, 100)] public int Shots = 1;
        [HideInInspector] public float Spread = 45f;
    }
}