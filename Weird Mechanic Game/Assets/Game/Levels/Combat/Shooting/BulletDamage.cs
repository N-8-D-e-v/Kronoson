﻿using UnityEngine;

namespace Game.Levels.Combat.Shooting
{
    public class BulletDamage : Damage
    {
        protected override void OnCollisionEnter2D(Collision2D _col)
        {
            base.OnCollisionEnter2D(_col);
            Destroy(gameObject);
        }
    }
}