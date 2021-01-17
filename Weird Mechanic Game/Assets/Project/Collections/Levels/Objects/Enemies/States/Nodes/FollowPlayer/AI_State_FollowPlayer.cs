using UnityEngine;

public class AI_State_FollowPlayer : AI_State
{
    //Raycasts
    [Header("Raycasts")]
    [SerializeField] private float floorDistance;
    [SerializeField] private float obstacleDistance;

    public override bool Condition()
    {
        return true;
    }

    public override void Behaviour()
    {
        
    }
}
