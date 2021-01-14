using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    //Input
    public float InputAxis {set; get;} = 0f;

    //Assignables
    private Rigidbody2D rb;

    //Stats
    [Header("Stats")]
    [SerializeField] private float speed = 8f;
    [SerializeField] private float acceleration = 0.07f;
    private Vector2 velocity;

    private void Awake() => rb = GetComponent<Rigidbody2D>();

    private void Update()
    {
        InputAxis = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate() => Move();

    private void Move()
    {
        Vector2 _move = Vector2.right * InputAxis * speed;
        _move.y = rb.velocity.y;
        Vector2 _smoothMove = Vector2.SmoothDamp(rb.velocity, _move, ref velocity, acceleration);
        rb.velocity = _smoothMove;    
    }
}
