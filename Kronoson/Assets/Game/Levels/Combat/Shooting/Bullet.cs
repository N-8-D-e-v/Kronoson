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
        private Rigidbody2D rb;

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
            rb = GetComponent<Rigidbody2D>();
        }

        protected virtual void OnTriggerEnter2D(Collider2D _col)
        {
            DealDamage(_col);
            cameraShake.ShakeCamera(cameraShakeSettings);
            Destroy();
        }

        protected virtual void Destroy()
        {
            rb.velocity = Vector2.zero;
            sprite.DOFade(0f, destroyTime);
            Destroy(gameObject, destroyTime);
        }
    }
}