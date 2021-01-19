using UnityEngine;

namespace Game.Levels.CameraControls
{
    public class CameraShakeOnDestroy : MonoBehaviour
    {
        //Assignables
        private CameraShake cameraShake;
        
        //Camera Shake
        [SerializeField] private CameraShakeSettings cameraShakeSettings;

        private void Awake() => cameraShake = Camera.main.GetComponent<CameraShake>();

        private void OnDestroy() => cameraShake.ShakeCamera(cameraShakeSettings);
    }
}