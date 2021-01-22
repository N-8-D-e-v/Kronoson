using System.Collections;
using Game.Levels.Combat;
using UnityEngine;

namespace Game.Levels.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SmoothMovement : MonoBehaviour, IMovement, IStunnable
    {
        //Input
        public float InputAxis { set; get; } = 0f;

        //Assignables
        private Rigidbody2D rb;

        //Stats
        [Header("Stats")] 
        [SerializeField] private float speed = 8f;
        [SerializeField] private float acceleration = 0.09f;
        private Vector2 velocity;
        
        //Stun
        private bool isStunned = false;

        private void Awake() => rb = GetComponent<Rigidbody2D>();

            private void FixedUpdate()
        {
            if (!isStunned)
                Move();
        }

        private void Move()
        {
            Vector2 _move = Vector2.right * (InputAxis * speed);
            Vector2 _velocity = rb.velocity;
            _move.y = _velocity.y;
            Vector2 _smoothMove = Vector2.SmoothDamp(_velocity, _move, ref velocity, acceleration);
            
            rb.velocity = _smoothMove;
        }

        public IEnumerator Stun(float _stunTime)
        {
            isStunned = true;
            yield return new WaitForSeconds(_stunTime);
            isStunned = false;
        }
    }
}