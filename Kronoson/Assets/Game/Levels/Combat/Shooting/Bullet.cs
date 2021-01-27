using DG.Tweening;
using Game.Levels.CameraControls;
using UnityEngine;

namespace Game.Levels.Combat.Shooting
{
    [RequireComponent(typeof(Collider2D), typeof(SpriteRenderer))]
    public class Bullet : Damage
    {
        //Assignables
        private CameraShake cameraShake;
        private SpriteRenderer sprite;

        //Camera Shake
        [Header("Camera Shake")]
        [SerializeField] private CameraShakeSettings cameraShakeSettings;
        
        //Destroy
        [Header("Destroy")]
        [SerializeField] private float destroyTime = 0.2f;

        protected override void Awake()
        {
            base.Awake();
            cameraShake = CameraShake.GetMainCameraShake();
            sprite = GetComponent<SpriteRenderer>();
        }

        protected virtual void OnTriggerEnter2D(Collider2D _col)
        {
            DealDamage(_col);
            cameraShake.ShakeCamera(cameraShakeSettings);
            Destroy();
        }

        protected virtual void Destroy()
        {
            sprite.DOFade(0f, destroyTime);
            Destroy(gameObject, destroyTime);
        }
    }
}