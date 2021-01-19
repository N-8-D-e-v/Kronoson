using UnityEngine;
using Game.General.Utilities.Vector3f;
using Game.General.Utilities.Componentf;
using Game.Levels.Movement;
using Game.Levels.Player;
using Game.Levels.Sensors;

namespace Game.Levels.AI
{
    public class AI_State_FollowPlayer : AI_State
    {
        //Assignables
        private Transform parent;
        private SmoothMovement movement;
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
            gameObject.RequireComponentsOnParent<SmoothMovement>(1);
            gameObject.RequireComponentsOnParent<Jumping>(1);
        }

        public override void LateAwake()
        {
            parent = GetComponentInParent<Transform>();
            movement = GetComponentInParent<SmoothMovement>();
            jumping = GetComponentInParent<Jumping>();
            direction.x = parent.localScale.x;
        }

        public override bool Condition()
        {
            Vector3 _dir = parent.position.GetDirectionToTarget(PlayerData.GetPlayerPosition());
            return _dir.sqrMagnitude <= sightDistance * sightDistance;
        }

        public override void Behaviour()
        {
            if (parent.position.x < PlayerData.GetPlayerPosition().x - stoppingDistance)
                direction = Vector2.right;
            else if (parent.position.x > PlayerData.GetPlayerPosition().x + stoppingDistance)
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
}
