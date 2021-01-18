using UnityEngine;

namespace Game.Levels.Movement
{
    [RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
    public class MovementAnimations : MonoBehaviour
    {
        //Assignables
        private Animator animator;
        private Rigidbody2D rb;

        //Animation Deltas
        [SerializeField] private float movingAnimDelta = 2f;

        //Animations
        private const string MOVE = "move";
        
        private void Awake()
        {
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate() => animator.SetBool(MOVE, Mathf.Abs(rb.velocity.x) > movingAnimDelta);
    }
}
