using UnityEngine;
using Game.General.Utilities.Vectors;

namespace Game.Levels.Combat
{
    public class Damage : MonoBehaviour
    {
        //Assignables
        protected new Transform transform;
        
        //Damage
        [Header("Damage")]
        [SerializeField] private int damage = 5;
        [SerializeField] private float knockback = 25f;

        protected virtual void Awake() => transform = GetComponent<Transform>();

        protected void DealDamage(Collider2D _col)
        {
            if (_col.TryGetComponent<IDamageable>(out IDamageable _damageable))
                _damageable.Damage(damage);
            
            if (_col.TryGetComponent<Rigidbody2D>(out Rigidbody2D _rb))
                Knockback(_rb);
        }

        private void Knockback(Rigidbody2D _rb)
        {
            Vector2 _dir = transform.position.GetDirectionToTarget(_rb.position).normalized;
            _rb.AddForce(_dir * knockback);
        }
    }
}