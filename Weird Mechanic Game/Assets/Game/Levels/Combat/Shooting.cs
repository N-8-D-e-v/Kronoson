using UnityEngine;
using Game.Levels.Sensors;
using Game.Levels.CameraControls;

namespace Game.Levels.Combat
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
                Rigidbody2D _bullet = Instantiate(gun.Bullet, gun.GunTip.position, Quaternion.identity);
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

    [System.Serializable]
    public struct Gun
    {
        public Rigidbody2D Bullet;
        public Transform GunTip;
        public float Range;
        public float FireRate;
        public int Shots;
    }
}