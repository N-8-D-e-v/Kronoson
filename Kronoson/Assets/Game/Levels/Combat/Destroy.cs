using UnityEngine;

namespace Game.Levels.Combat
{
    public class Destroy : MonoBehaviour
    {
        private void DestroyGameObject(float _time) => Destroy(gameObject, _time);
    }
}
