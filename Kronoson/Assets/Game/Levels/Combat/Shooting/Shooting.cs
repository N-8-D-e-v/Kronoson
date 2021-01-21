using UnityEngine;
using Game.Levels.Sensors;
using Game.General.TimeManagement;

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

        private bool CanShoot() => InputAttack && !Colliding() && fireRateTimer.Time == 0;

        protected virtual void Shoot()
        {
            animator.Play(SHOOT);
            float[] _spread = ShootingSpread.GetSpreadFromShots
                (gun.Shots, gun.Spread, transform.eulerAngles.z);

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

    public static class ShootingSpread
    {
        public static float[] GetSpreadFromShots(int _shots, float _spreadAngle, float _lookAngle)
        {
            float[] _spread = new float[_shots];
            float _centerAngle = GetCenterAngle(_spreadAngle);
            float _incrementAngle = GetIncrementAngle(_spreadAngle, _shots - 1);

            if (_shots == 1)
            {
                _spread[0] = _lookAngle;
                return _spread;
            }

            for (int _i = 0; _i < _shots; _i++)
            {
                float _angle = GetAngleFromIncrement(_i, _incrementAngle);
                float _offsetAngle = GetOffsetFromCenterAngle(_angle, _centerAngle);
                _spread[_i] = ConvertToLocalAngle(_offsetAngle, _lookAngle);
            }

            return _spread;
        }
        
        #region Getters
        
        private static float GetCenterAngle(float _spreadAngle) => 
            _spreadAngle / 2;
        
        private static float GetIncrementAngle(float _spreadAngle, int _shots) => 
            _spreadAngle / _shots;

        private static float GetAngleFromIncrement(int _i, float _incrementAngle) => 
            _i * _incrementAngle;

        private static float GetOffsetFromCenterAngle(float _angle, float _centerAngle) => 
            _angle - _centerAngle;

        private static float ConvertToLocalAngle(float _offsetAngle, float _lookAngle) => 
            _lookAngle + _offsetAngle;

        #endregion
    }
}