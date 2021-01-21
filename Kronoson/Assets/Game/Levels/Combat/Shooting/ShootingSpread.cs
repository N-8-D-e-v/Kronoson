namespace Game.Levels.Combat.Shooting
{
    public static class ShootingSpread
    {
        public static float[] GetBulletSpread(this float[] _spread, int _shots, float _spreadAngle, float _lookAngle)
        {
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
    }
}