using UnityEngine;
using System.Collections;

namespace Game.Levels.Movement
{
    [RequireComponent(typeof(Collider2D))]
    public class GroundCheck : MonoBehaviour
    {
        //Public Fields
        public bool IsGrounded { private set; get; } = false;

        //Assignables
        private new Transform transform;
        private Collider2D col;

        //Grounded
        [Header("Grounded")] 
        [SerializeField] private float groundDistance = 0.085f;
        [SerializeField] private float groundedForgiveness = 0.2f;
        private float groundTimer = 0f;
        private bool canCheckGround = true;

        //Layers
        [Header("Layers")] 
        [SerializeField] private LayerMask groundLayer;

        private void Awake()
        {
            transform = GetComponent<Transform>();
            col = GetComponent<Collider2D>();
        }

        private void Update()
        {
            if (canCheckGround)
                CheckGrounded();
            else
                groundTimer = 0f;
            IsGrounded = groundTimer > 0;
        }

        private void CheckGrounded()
        {
            RaycastHit2D _grounded = Physics2D.Raycast(transform.position, Vector2.down,
                col.bounds.extents.y + groundDistance, groundLayer);
            if (_grounded.collider)
                groundTimer = groundedForgiveness;
            else
                groundTimer = Mathf.Clamp(groundTimer - Time.deltaTime, 0f, groundedForgiveness);
        }

        public void SetGroundCheck()
        {
            if (canCheckGround)
                StartCoroutine(UnGroundRoutine());
        }

        private IEnumerator UnGroundRoutine()
        {
            canCheckGround = false;
            yield return null;
            canCheckGround = true;
        }
    }
}