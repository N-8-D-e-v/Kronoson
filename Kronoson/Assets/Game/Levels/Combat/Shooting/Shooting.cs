using UnityEngine;
using Game.Levels.Sensors;
using Game.General.TimeManagement;

namespace Game.Levels.Combat.Shooting
{
    [RequireComponent(typeof(Animator))]
    public class Shooting : MonoBehaviour, IAttack
    {
        //Input
        public bool InputAttack { set; get; } = false;

        //Assignables
        private new Transform transform;
        private Animator animator;
        private readonly Timer fireRateTimer = new Timer(0);

        //Gun
        [SerializeField] private Gun gun;
        [SerializeField] private Transform gunTip;

        //Animation
        private const string SHOOT = "shoot";

        protected virtual void Awake()
        {
            transform = GetComponent<Transform>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            fireRateTimer.Tick(Time.deltaTime);
            if (CanShoot())
                Shoot();
        }

        public bool IsAutomatic() => gun.IsAutomatic;

        private bool CanShoot() => InputAttack && fireRateTimer.Time == 0;

        protected virtual void Shoot()
        {
            animator.Play(SHOOT);
            
            float[] _spread = new float[gun.Shots];
            _spread.GetBulletSpread(gun.Shots, gun.Spread, transform.eulerAngles.z);

            for (int _i = 0; _i < gun.Shots; _i++)
            {
                float _angle = _spread[_i];
                Rigidbody2D _bullet = Instantiate(gun.Bullet, gunTip.position, Quaternion.identity);
                Transform _bulletTransform = _bullet.transform;
                _bulletTransform.eulerAngles = Vector3.forward * _angle;
                _bullet.AddForce(_bulletTransform.up * gun.Range, ForceMode2D.Impulse);
            }

            fireRateTimer.Time = gun.FireRate;
        }
    }
}