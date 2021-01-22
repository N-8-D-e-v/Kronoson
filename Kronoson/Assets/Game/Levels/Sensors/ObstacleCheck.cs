using UnityEngine;

namespace Game.Levels.Sensors
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

        public bool CheckObstacle(Vector2 _dir) => 
            Physics2D.Raycast(raycastCheck.position, _dir, obstacleDistance, obstacleLayer);
    }
}