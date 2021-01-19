using UnityEngine;

namespace Game.Levels.Movement
{
    [RequireComponent(typeof(Rigidbody2D), typeof(GroundCheck))]
    public class Jumping : MonoBehaviour, IJumping
    {
        //Input
        public bool InputUp { set; get; } = false;

        //Assignables
        private Rigidbody2D rb;
        private GroundCheck groundCheck;

        //Jump Stats
        [Header("Jump Stats")] [SerializeField]
        private float jumpForce = 6f;

        //Jump Forgiveness
        [Header("Jump Forgiveness")] [SerializeField]
        private float jumpForgiveness = 0.2f;

        private float jumpTimer = 0f;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            groundCheck = GetComponent<GroundCheck>();
        }

        private void Update()
        {
            CheckInput();
            if (jumpTimer > 0 && groundCheck.IsGrounded)
                Jump();
        }

        private void CheckInput() => jumpTimer = InputUp ? jumpForgiveness : jumpTimer -= Time.deltaTime;

        private void Jump()
        {
            Vector2 _jump = rb.velocity;
            _jump.y = jumpForce;
            rb.velocity = _jump;
            groundCheck.SetGroundCheck();
            jumpTimer = 0f;
        }
    }
}