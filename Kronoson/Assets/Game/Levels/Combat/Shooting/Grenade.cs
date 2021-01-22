using System;
using UnityEngine;

namespace Game.Levels.Combat.Shooting
{
    public class Grenade : Bullet
    {
        //Explosion
        [Header("Explosion")]
        [SerializeField] private Explosion explosion;

        protected override void Destroy()
        {
            Instantiate(explosion, Transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}