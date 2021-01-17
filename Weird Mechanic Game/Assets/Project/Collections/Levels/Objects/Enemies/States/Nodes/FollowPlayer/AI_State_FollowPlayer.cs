using UnityEngine;
using Utilities.GameObjectf;

public class AI_State_FollowPlayer : AI_State
{
    //Assignables
    [Header("Assignables")]
    [SerializeField] private ObstacleCheck obstacleCheck;
    [SerializeField] private ObstacleCheck floorCheck;
    private Movement movement;
    private Jumping jumping;

    //Stopping
    [Header("Stopping")]
    [SerializeField] private float stopRadius = 3f;

    //Direction
    private Vector2 direction;

    void Reset()
    {
        gameObject.RequireComponents<ObstacleCheck>(2);
    }

    public override void LateAwake()
    {
        movement = GetComponentInParent<Movement>();
        jumping = GetComponentInParent<Jumping>();
        direction.x = transform.parent.localScale.x;
    }

    public override bool Condition()
    {
        return true;
    }

    public override void Behaviour()
    {
        if (transform.parent.position.x < Player.Transform.position.x - stopRadius)
            direction = Vector2.right;
        else if (transform.parent.position.x > Player.Transform.position.x + stopRadius)
            direction = Vector2.left;
        else
            direction = Vector2.zero;

        movement.Input_Axis = direction.x;

        bool _obstacle = obstacleCheck.CheckObstacle(direction);
        bool _floor = floorCheck.CheckObstacle(Vector2.down);

        if (_obstacle || _floor)
            jumping.Input_Up = true;
        else
            jumping.Input_Up = false;
    }
}
