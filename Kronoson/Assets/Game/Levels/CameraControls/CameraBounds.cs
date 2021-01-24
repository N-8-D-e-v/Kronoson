using UnityEngine;

namespace Game.Levels.CameraControls
{
    [CreateAssetMenu(fileName = "NewCameraBounds", menuName = "Camera/Bounds", order = 0)]
    public class CameraBounds : ScriptableObject
    {
        public bool UseBounds = false;
        [HideInInspector] public float MinX;
        [HideInInspector] public float MaxX;
        [HideInInspector] public float MinY;
        [HideInInspector] public float MaxY;
    }
}