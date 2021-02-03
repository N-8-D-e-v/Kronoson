using Game.General.Audio;
using UnityEngine;

namespace Game.Levels.Combat
{
    [RequireComponent(typeof(Animator), typeof(IKillable))]
    public class TakeDamage : MonoBehaviour, IDamageable
    {
        //Assignables
        private Animator animator;
        private IKillable killable;

        //Health
        [SerializeField] private int startHealth = 100;
        private int health = 0;
        
        //Sound
        [SerializeField] private SoundType hurtSound = SoundType.EnemyHurt;

        //Animation
        private static readonly int HURT = Animator.StringToHash("hurt");

        private void Awake()
        {
            animator = GetComponent<Animator>();
            killable = GetComponent<IKillable>();
            health = startHealth;
        }

        public int GetHealth() => health;

        public void Damage(int _damage)
        {
            if (killable.IsDead())
                return;
            
            health = Mathf.Max(0, health - _damage);
            if (health <= 0)
            {
                killable.Kill();
            }
            else
            {
                animator.Play(HURT);
                SoundManager.PlaySound(hurtSound);
            }
        }
    }
}