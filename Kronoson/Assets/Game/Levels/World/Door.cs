using UnityEngine;

namespace Game.Levels.World
{
    [RequireComponent(typeof(Animator))]
    public class Door : MonoBehaviour
    {
        //Assignables
        private Animator animator;
        
        //Open Requirements
        [SerializeField] private int requirementsNeeded = 2;
        private int requirementsFulfilled = 0;
        
        //Animation
        private static readonly int OPEN = Animator.StringToHash("open");

        private void Awake() => animator = GetComponent<Animator>();

        public void RequirementFulfilled()
        {
            requirementsFulfilled += 1;
            if (requirementsFulfilled == requirementsNeeded)
                animator.Play(OPEN);
        }
    }
}