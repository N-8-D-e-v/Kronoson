using UnityEngine;
using Game.General.Utilities.Vector3f;

namespace Game.Levels.Combat
{
    public class Damage : MonoBehaviour
    {
        //Assignables
        protected new Transform Transform;
        
        //Damage
        [Header("Damage")]
        [SerializeField] private int damage = 5;
        [SerializeField] private float stunTime = 0.5f;
        [SerializeField] private float knockback = 25f;

        protected virtual void Awake() => Transform = GetComponent<Transform>();

        protected void DealDamage(Component _col)
        {
            if (!_col.TryGetComponent<IDamageable>(out IDamageable _damageable))
                return;
            _damageable.Damage(damage);
            if (!_col.TryGetComponent<Rigidbody2D>(out Rigidbody2D _rb) || 
                !_col.TryGetComponent<IStunnable>(out IStunnable _stunnable))
                return;
            _stunnable.Stun(stunTime);
            Vector2 _dir = Transform.position.GetDirectionToTarget(_rb.position).normalized;
            _rb.AddForce(_dir * knockback);
        }
    }
}