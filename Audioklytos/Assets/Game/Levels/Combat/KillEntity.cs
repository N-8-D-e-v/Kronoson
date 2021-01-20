using UnityEngine;

namespace Game.Levels.Combat
{
    [RequireComponent(typeof(Animator))]
    public class KillEntity : MonoBehaviour, IKillable
    {
        //Assignables
        private Animator animator;
        
        //Animation
        private static readonly int KILL = Animator.StringToHash("kill");

        private void Awake() => animator = GetComponent<Animator>();
        
        public void Kill() => animator.Play(KILL);
    }
}