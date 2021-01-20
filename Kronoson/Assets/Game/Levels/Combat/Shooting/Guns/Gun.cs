using UnityEngine;

namespace Game.Levels.Combat.Shooting
{
    [CreateAssetMenu(fileName = "NewGun", menuName = "Weapons/Gun", order = 0)]
    public class Gun : ScriptableObject
    {
        public Rigidbody2D Bullet;
        public float Range = 15f;
        public float FireRate = 0.2f;
        public int Shots = 1;
    }
}