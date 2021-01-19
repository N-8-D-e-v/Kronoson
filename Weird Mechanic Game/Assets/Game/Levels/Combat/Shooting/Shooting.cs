using UnityEngine;
using Game.Levels.Sensors;
using Game.Levels.CameraControls;

namespace Game.Levels.Combat.Shooting
{
    [RequireComponent(typeof(Animator))]
    public class Shooting : CollisionSensor, IAttack
    {
        //Input
        public bool InputAttack { set; get; } = false;

        //Assignables
        private new Transform transform;
        private Animator animator;

        //Gun
        [SerializeField] private Gun gun;
        [SerializeField] private Transform gunTip;
        private bool canShoot = true;

        //Animation
        private const string SHOOT = "shoot";

        protected virtual void Awake()
        {
            transform = GetComponent<Transform>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (CanShoot())
                Shoot();
        }

        private bool CanShoot()
        {
            return InputAttack && canShoot && !Colliding();
        }

        protected virtual void Shoot()
        {
            animator.Play(SHOOT);
            for (int _i = 0; _i < gun.Shots; _i++)
            {
                Rigidbody2D _bullet = Instantiate(gun.Bullet, gunTip.position, Quaternion.identity);
                _bullet.AddForce(transform.up * gun.Range, ForceMode2D.Impulse);
            }
            canShoot = false;
            Invoke(nameof(Reload), gun.FireRate);
        }

        private void Reload()
        {
            canShoot = true;
        }
    }
    
}