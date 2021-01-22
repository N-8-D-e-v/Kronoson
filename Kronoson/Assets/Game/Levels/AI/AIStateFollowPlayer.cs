using UnityEngine;
using Game.General.Utilities.Vector3f;
using Game.Levels.Movement;
using Game.Levels.Player;
using Game.Levels.Sensors;

namespace Game.Levels.AI
{
    public class AIStateFollowPlayer : AIState
    {
        //Assignables
        private Transform parent;
        private IMovement movement;
        private IJumping jumping;

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

        public override void LateAwake()
        {
            parent = GetComponentInParent<Transform>();
            movement = GetComponentInParent<SmoothMovement>();
            jumping = GetComponentInParent<IJumping>();
            direction.x = parent.localScale.x;
        }

        protected override void OnDisable() => movement.InputAxis = 0f;

        public override bool Condition()
        {
            Vector3 _dir = parent.position.GetDirectionToTarget(PlayerData.GetPlayerPosition());
            return _dir.sqrMagnitude <= sightDistance * sightDistance;
        }

        public override void Behaviour()
        {
            float _parentX = parent.position.x;
            float _playerX = PlayerData.GetPlayerPosition().x;
            
            if (_parentX < _playerX - stoppingDistance)
                direction = Vector2.right;
            else if (_parentX > _playerX + stoppingDistance)
                direction = Vector2.left;
            else
                direction = Vector2.zero;

            movement.InputAxis = direction.x;

            bool _obstacle = obstacleCheck.CheckObstacle(direction);
            bool _floor = floorCheck.CheckObstacle(Vector2.down);

            if (_obstacle || !_floor)
                jumping.InputUp = true;
            else
                jumping.InputUp = false;
        }
    }
}