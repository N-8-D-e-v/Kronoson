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

        public override bool Condition()
        {
            return true;
        }

        public override void Behaviour()
        {   
            //Move
            movement.Input_Axis = direction.x;

            //Check if there is a wall in front of us, or if we are about to walk off of the ground
            bool _floor = floorCheck.CheckObstacle(Vector2.down);
            bool _wall = wallCheck.CheckObstacle(direction);

            //if there is no floor or there is a wall, turn around
            if (!_floor || _wall)
            {
                direction *= -1;
                Vector3 _scale = transform.parent.localScale;
                _scale.x = direction.x;
                transform.parent.localScale = _scale;
            }
        }
    }
}
