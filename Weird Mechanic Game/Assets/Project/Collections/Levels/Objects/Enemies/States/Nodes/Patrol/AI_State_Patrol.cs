using UnityEngine;

public class AI_State_Patrol : AI_State
{   
    //Assignables
    private Movement movement;
    
    //Layers
    [Header("Layers")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    
    //Raycasts
    [Header("Raycasts")]
    [SerializeField] private Transform raycastCheck;
    [SerializeField] private float wallDistance = 2f;
    [SerializeField] private float floorDistance = 2f;

    //Movement
    private Vector2 direction;

    public override void LateAwake()
    {
        movement = GetComponentInParent<Movement>();
        direction.x = Transform.localScale.x;
    }

    public override bool Condition()
    {
        return true;
    }

    public override void Behaviour()
    {   
        //Move
        movement.Input_Axis = direction.x;

        //Check if there is a wall in front of us, or if we are about to walk off of the ground
        bool _floor = Physics2D.Raycast(raycastCheck.position, Vector2.down, floorDistance, groundLayer);
        bool _wall = Physics2D.Raycast(Transform.position, direction, wallDistance, wallLayer + groundLayer);

        //if there is no floor or there is a wall, turn around
        if (!_floor || _wall)
        {
            direction *= -1;
            Vector3 _scale = Transform.localScale;
            _scale.x = direction.x;
            Transform.localScale = _scale;
        }
    }
}
