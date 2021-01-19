using UnityEngine;
using Game.Levels.Movement;
using Game.Levels.Sensors;

namespace Game.Levels.AI
{
    public class AIStatePatrol : AIState
    {
        //Assignables
        private SmoothMovement movement;

        //Raycasts
        [Header("Raycasts")] [SerializeField] private ObstacleCheck wallCheck;
        [SerializeField] private ObstacleCheck floorCheck;

        //SmoothMovement
        private Vector2 direction;

        public override void LateAwake()
        {
            movement = GetComponentInParent<SmoothMovement>();
            direction.x = transform.parent.localScale.x;
        }

        public override bool Condition()
        {
            return true;
        }

        public override void Behaviour()
        {
            movement.InputAxis = direction.x;

            bool _isFloor = floorCheck.CheckObstacle(Vector2.down);
            bool _isWall = wallCheck.CheckObstacle(direction);

            if (!_isFloor || _isWall)
                TurnAround();
        }

        private void TurnAround()
        {
            direction *= -1;
            movement.InputAxis = direction.x;
        }
    }
}