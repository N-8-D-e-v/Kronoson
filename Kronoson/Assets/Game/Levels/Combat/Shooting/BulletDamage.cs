using Game.Levels.CameraControls;
using UnityEngine;

namespace Game.Levels.Combat.Shooting
{
    public class BulletDamage : Damage
    {
        //Assignables
        private CameraShake cameraShake;
        
        //Camera Shake
        [SerializeField] private CameraShakeSettings cameraShakeSettings;
        
        private void Awake() => cameraShake = CameraShake.GetMainCameraShake();
        
        protected override void OnCollisionEnter2D(Collision2D _col)
        {
            base.OnCollisionEnter2D(_col);
            Destroy(gameObject);
            cameraShake.ShakeCamera(cameraShakeSettings);
        }
    }
}