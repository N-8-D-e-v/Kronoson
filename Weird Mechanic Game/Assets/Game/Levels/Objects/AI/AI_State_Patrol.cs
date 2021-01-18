using UnityEngine;
using Game.General.Utilities.Componentf;
using Game.Levels.Movement;
using Game.Levels.Sensors;

namespace Game.Levels.Objects.AI
{
    public class AI_State_Patrol : AI_State
    {   
        //Assignables
        private SmoothMovement movement;

        //Raycasts
        [Header("Raycasts")]
        [SerializeField] private ObstacleCheck wallCheck;
        [SerializeField] private ObstacleCheck floorCheck;

        //SmoothMovement
        private Vector2 direction;

        private void Reset() => gameObject.RequireComponentsOnParent<SmoothMovement>(1);

        public override void LateAwake()
        {
            movement = GetComponentInParent<SmoothMovement>();
            direction.x = transform.parent.localScale.x;
        }

        public override bool Condition() => true;

        public override void Behaviour()
        {   
            movement.Input_Axis = direction.x;
            print(direction);

            bool _isFloor = floorCheck.CheckObstacle(Vector2.down);
            bool _isWall = wallCheck.CheckObstacle(direction);

            if (!_isFloor || _isWall)
                TurnAround();
        }

        private void TurnAround()
        {
            direction *= -1;
            movement.Input_Axis = direction.x;
        }
    }
}
