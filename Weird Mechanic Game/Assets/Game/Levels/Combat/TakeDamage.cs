using Game.Levels.Animation;
using UnityEngine;

namespace Game.Levels.Combat
{
    [RequireComponent(typeof(IKillable), typeof(IAnimation))]
    public class TakeDamage : MonoBehaviour, IDamageable
    {
        //Assignables
        private IKillable killable;
        private IAnimation hurtAnimation;
        
        //Health
        [SerializeField] private int startHealth = 100;
        private int health = 0;

        private void Awake()
        {
            killable = GetComponent<IKillable>();
            hurtAnimation = GetComponent<IAnimation>();
            health = startHealth;
        }

        public int GetHealth() => health;

        public void Damage(int _damage)
        {
            health = Mathf.Max(0, health - _damage);
            hurtAnimation.Play();
            if (health <= 0)
                killable.Kill();
        }
    }
}