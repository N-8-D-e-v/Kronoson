using Game.Levels.CameraControls;
using UnityEngine;

namespace Game.Levels.Combat.Shooting
{
    public class ShootingCameraShake : Shooting
    {
        //Assignables
        private CameraShake cameraShake;
        
        //Camera Shake
        [Header("Camera Shake")] 
        [SerializeField] private CameraShakeSettings cameraShakeSettings;

        protected override void Awake()
        {
            base.Awake();
            cameraShake = CameraShake.GetMainCameraShake();
        }

        protected override void Shoot()
        {
            base.Shoot();
            cameraShake.ShakeCamera(cameraShakeSettings);
        }
    }
}