using Game.Levels.Combat;
using UnityEngine;

namespace Game.Levels.World
{
    public class Spike : Damage
    {
        private void OnCollisionEnter2D(Collision2D _col) => DealDamage(_col.collider);
    }
}