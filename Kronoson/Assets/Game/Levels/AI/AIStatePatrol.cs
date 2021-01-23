using UnityEngine;
using Game.General.Utilities.Transformf;
using Game.Levels.Movement;
using Game.Levels.Sensors;

namespace Game.Levels.AI
{
    public class AIStatePatrol : AIState
    {
        //Assignables
        private Transform parent;
        private SmoothMovement movement;
        private IFlippable flippable;

        //Raycasts
        [Header("Raycasts")] 
        [SerializeField] private ObstacleCheck wallCheck;
        [SerializeField] private ObstacleCheck floorCheck;

        //Direction
        private Vector2 direction;

        public override void LateAwake()
        {
            movement = GetComponentInParent<SmoothMovement>();
            flippable = GetComponentInParent<IFlippable>();
            parent = transform.parent;
            direction.x = Mathf.Clamp(parent.localScale.x, -1f, 1f);
        }

        protected override void OnDisable() => movement.InputAxis = 0f;

        public override void OnStateEnter() => flippable.Enabled = true;
        
        public override void OnStateExit() => flippable.Enabled = false;

        public override bool Condition() => true;

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