using UnityEngine;

namespace Game.Levels.General.Physics_2D.Raycasts
{
    [System.Serializable]
    public class ObstacleCheck
    { 
        //Layers
        [Header("Layers")]
        [SerializeField] private LayerMask obstacleLayer;

        //Raycasts
        [Header("Raycasts")]
        [SerializeField] private Transform raycastCheck;
        [SerializeField] private float obstacleDistance = 2f;

        public bool CheckObstacle(Vector2 _dir)
        {
            return Physics2D.Raycast(raycastCheck.position, _dir, obstacleDistance, obstacleLayer);
        }
    }
}
