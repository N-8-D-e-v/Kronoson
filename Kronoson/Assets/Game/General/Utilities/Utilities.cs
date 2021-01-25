using UnityEngine;
using System;
using System.Threading.Tasks;
using Game.General.Utilities.Mouse;
using Object = UnityEngine.Object;

namespace Game.General.Utilities
{
    namespace Transform
    {
        public static class TransformF
        {
            public static T[] InitializeHierarchy<T>(this UnityEngine.Transform _root) where T : Component
            {
                int _numberOfComponents = _root.GetComponentsInChildren<T>().Length;
                T[] _components = new T[_numberOfComponents];
                int _c = 0;

                for (int _i = 0; _i < _root.childCount; _i++)
                    if (_root.GetChild(_i).TryGetComponent<T>(out T _component))
                    {
                        _components[_c] = _component;
                        _c++;
                    }

                return _components;
            }

            public static void Flip(this UnityEngine.Transform _transform, float _dir, bool _isLocal)
            {
                Vector3 _rot = _isLocal ? _transform.localEulerAngles : _transform.eulerAngles;
                if (_dir > 0)
                    _rot.y = 0f;
                else if (_dir < 0)
                    _rot.y = 180f;
                _transform.eulerAngles = _rot;
            }

            public static void Flip(this UnityEngine.Transform _transform, float _dir, float _xScale)
            {
                Vector3 _scale = _transform.localScale;

                if (_dir > 0)
                    _scale.x = _xScale;
                else if (_dir < 0)
                    _scale.x = -_xScale;

                _transform.localScale = _scale;
            }
        }
    }

    namespace Vectors
    {
        public static class Vector3F
        {
            public static Vector3 GetDirectionToTarget(this Vector3 _pos, Vector3 _targetPos)
            {
                Vector2 _dir = _targetPos - _pos;
                _dir = _dir.normalized;
                return _dir;
            }
            
            public static float GetAngleToMouse(this Vector3 _pos, float _cameraZ)
            {
                Vector3 _dir = Camera.main.ScreenToWorldPoint(MouseF.GetMousePosition()) - _pos;
                float _angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
                return _angle;
            }
            
            public static float GetAngleToMouse(this Vector2 _pos, float _cameraZ)
            {
                Vector3 _dir = Camera.main.ScreenToWorldPoint(MouseF.GetMousePosition()) - (Vector3) _pos;
                float _angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
                return _angle;
            }
        }
    }

    namespace Delegates
    {
        public delegate void VoidDelegate();

        public static class DelegateF
        {
            public static async void Invoke(Object _caller, VoidDelegate _delegate, float _time)
            {
                await Task.Delay(TimeSpan.FromSeconds(_time));
                if (_caller)
                    _delegate.Invoke();
            }
        }
    }

    namespace Mouse
    {
        public static class MouseF
        {
            public const int MAINCAMERA_Z = -10;

            public static Vector3 GetMousePosition() => 
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, MAINCAMERA_Z);
        }
    }
}