using UnityEngine;

namespace Game.Levels.Combat
{
    [RequireComponent(typeof(Animator))]
    public class KillEntity : MonoBehaviour, IKillable
    {
        //Assignables
        private Animator animator;
        
        //Death
        private bool isDead = false;
        
        //Animation
        private static readonly int KILL = Animator.StringToHash("kill");

        private void Awake() => animator = GetComponent<Animator>();

        public void Kill()
        {
            if (IsDead())
                return;
            isDead = true;
            animator.Play(KILL);
        }

        public bool IsDead() => isDead;
    }
}