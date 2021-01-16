using UnityEngine;
using Utilities.Transformf;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    //Input
    public float Input_Axis {set; private get;} = 0f;

    //Assignables
    private Rigidbody2D rb;
    private Animator animator;

    //Stats
    [Header("Stats")]
    [SerializeField] private float speed = 8f;
    [SerializeField] private float acceleration = 0.09f;
    private Vector2 velocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Input_Axis = Input.GetAxisRaw("Horizontal");
        transform.Flip(Input_Axis);
    }

    private void FixedUpdate() => Move();

    private void Move()
    {
        Vector2 _move = Vector2.right * Input_Axis * speed;
        _move.y = rb.velocity.y;
        Vector2 _smoothMove = Vector2.SmoothDamp(rb.velocity, _move, ref velocity, acceleration);
        rb.velocity = _smoothMove;    
    }
}