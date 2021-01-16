using UnityEngine;

namespace Utilities
{
    namespace Transformf
    {
        public static class Transformf
        { 
            public static Vector3 Flip(this Transform _transform, float _dir, bool _isLocal)
            {
                Vector3 _rot = _isLocal ? _transform.localEulerAngles : _transform.eulerAngles;
                if (_dir > 0)
                    _rot.y = 0f;
                else if (_dir < 0)
                    _rot.y = 180f;
                _transform.eulerAngles = _rot;
                return _rot;
            }

            public static Vector3 Flip(this Transform _transform, float _dir)
            {
                Vector3 _scale = _transform.localScale;

                if (_dir > 0)
                    _scale.x = 1f;
                else if (_dir < 0)
                    _scale.x = -1f;

                _transform.localScale = _scale;
                return _scale;
            }
        }
    }
}
