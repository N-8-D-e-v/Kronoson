using Game.Levels.CameraControls;
using UnityEngine;

namespace Game.Levels.Combat.Shooting
{
    [RequireComponent(typeof(Collider2D))]
    public class Bullet : Damage
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

        protected virtual void OnTriggerEnter2D(Collider2D _col)
        {
            DealDamage(_col);
            cameraShake.ShakeCamera(cameraShakeSettings);
            Destroy();
        }

        protected virtual void Destroy() => Destroy(gameObject);
    }
}