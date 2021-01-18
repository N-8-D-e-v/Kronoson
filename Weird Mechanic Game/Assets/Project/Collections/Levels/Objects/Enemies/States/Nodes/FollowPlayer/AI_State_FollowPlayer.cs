using UnityEngine;
using Utilities.Transformf;
using Utilities.Componentf;

public class AI_State_FollowPlayer : AI_State
{
    //Assignables
    private Movement movement;
    private Jumping jumping;

    //Raycasts
    [Header("Raycasts")]
    [SerializeField] private ObstacleCheck obstacleCheck;
    [SerializeField] private ObstacleCheck floorCheck;

    //Following
    [Header("Following")]
    [SerializeField] private float sightDistance = 10f;
    [SerializeField] private float stoppingDistance = 3f;

    //Direction
    private Vector2 direction;

    private void Reset()
    {
        gameObject.RequireComponentsOnParent<Movement>(1);
        gameObject.RequireComponentsOnParent<Jumping>(1);
    }

    public override void LateAwake()
    {
        movement = GetComponentInParent<Movement>();
        jumping = GetComponentInParent<Jumping>();
        direction.x = transform.parent.localScale.x;
    }

    public override bool Condition()
    {
        return transform.parent.GetDirectionToTarget(Player.Transform).sqrMagnitude <= sightDistance * sightDistance;
    }

    public override void Behaviour()
    {
        if (transform.parent.position.x < Player.Transform.position.x - stoppingDistance)
            direction = Vector2.right;
        else if (transform.parent.position.x > Player.Transform.position.x + stoppingDistance)
            direction = Vector2.left;
        else
            direction = Vector2.zero;

        movement.Input_Axis = direction.x;

        bool _obstacle = obstacleCheck.CheckObstacle(direction);
        bool _floor = floorCheck.CheckObstacle(Vector2.down);

        if (_obstacle || !_floor)
            jumping.Input_Up = true;
        else
            jumping.Input_Up = false;
    }
}
