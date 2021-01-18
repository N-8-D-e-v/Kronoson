using UnityEngine;

namespace Utilities
{
    namespace Transformf
    {
        public static class Transformf
        { 
            public static T[] InitializeHierarchy<T>(this Transform _root) where T : Component
            {
                int _numberOfComponents = _root.GetComponentsInChildren<T>().Length;
                T[] _components = new T[_numberOfComponents];
                int _c = 0;
                
                for (int i = 0; i < _root.childCount; i++)
                {
                    if (_root.GetChild(i).TryGetComponent<T>(out T _component))
                    {
                        _components[_c] = _component;
                        _c ++;
                    }

                }

                return _components;
            }
            
            public static void Flip(this Transform _transform, float _dir, bool _isLocal)
            {
                Vector3 _rot = _isLocal ? _transform.localEulerAngles : _transform.eulerAngles;
                if (_dir > 0)
                    _rot.y = 0f;
                else if (_dir < 0)
                    _rot.y = 180f;
                _transform.eulerAngles = _rot;
            }

            public static void Flip(this Transform _transform, float _dir)
            {
                Vector3 _scale = _transform.localScale;

                if (_dir > 0)
                    _scale.x = 1f;
                else if (_dir < 0)
                    _scale.x = -1f;

                _transform.localScale = _scale;
            }

            public static float GetAngleToMouse(this Transform _transform, float _cameraZ)
            {
                Vector3 _mousePos = Input.mousePosition;
                _mousePos.z = _cameraZ;
                Vector3 _dir = Camera.main.ScreenToWorldPoint(_mousePos) - _transform.position;
                float _angle = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
                return _angle;
            }

            public static Vector2 GetDirectionToTarget(this Transform _transform, Transform _target)
            {
                Vector2 _dir = _target.position - _transform.position;
                _dir = _dir.normalized;
                return _dir;
            }
        }
    }

    namespace Componentf
    {
        public static class Componentf
        {
            public static void RequireComponents<T>(this GameObject _gameObject, int _components) where T : Component
            {
                int _currentComponents = _gameObject.GetComponents<T>().Length;
                for (int i = 0; i < _components - _currentComponents; i++)
                    _gameObject.AddComponent<T>();
            }

            public static void RequireComponentsOnParent<T>(this GameObject _gameObject, int _components) where T : Component
            {
                GameObject _parent = _gameObject.transform.parent.gameObject;
                RequireComponents<T>(_parent, _components);
            }
        }
    }
}
