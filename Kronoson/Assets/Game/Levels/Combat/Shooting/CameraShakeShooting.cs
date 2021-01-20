using Game.Levels.CameraControls;
using UnityEngine;

namespace Game.Levels.Combat.Shooting
{
    public class CameraShakeShooting : Shooting
    {
        //Assignables
        private CameraShake cameraShake;
        
        //Camera Shake
        [Header("Camera Shake")] 
        [SerializeField] private CameraShakeSettings cameraShakeSettings;

        protected override void Awake()
        {
            base.Awake();
            cameraShake = Camera.main.GetComponent<CameraShake>();
        }

        protected override void Shoot()
        {
            base.Shoot();
            cameraShake.ShakeCamera(cameraShakeSettings);
        }
    }
}