using Game.General.Audio;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Levels.Combat
{
    [RequireComponent(typeof(Animator))]
    public class KillEntity : MonoBehaviour, IKillable
    {
        //Assignables
        private Animator animator;
        
        //Death
        [SerializeField] private SoundType deathSound = SoundType.EnemyDeath;
        [SerializeField] private UnityEvent onDeath;
        private bool isDead = false;
        
        //Animation
        private static readonly int KILL = Animator.StringToHash("kill");

        private void Awake() => animator = GetComponent<Animator>();

        public void Kill()
        {
            if (IsDead())
                return;
            SoundManager.PlaySound(deathSound);
            onDeath?.Invoke();
            isDead = true;
            animator.Play(KILL);
        }

        public bool IsDead() => isDead;
    }
}