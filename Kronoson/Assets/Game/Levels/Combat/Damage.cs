using UnityEngine;

namespace Game.Levels.Combat
{
    [RequireComponent(typeof(Collider2D))]
    public class Damage : MonoBehaviour
    {
        //Damage
        [SerializeField] private int damage = 5;
        
        protected virtual void OnCollisionEnter2D(Collision2D _col)
        {
            if (!_col.collider.TryGetComponent<IDamageable>(out IDamageable _damageable))
                return;
            _damageable.Damage(damage);
        }
    }
}