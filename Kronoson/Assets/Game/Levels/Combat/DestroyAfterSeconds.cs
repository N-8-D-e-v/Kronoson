using UnityEngine;

namespace Game.Levels.Combat
{
    public class DestroyAfterSeconds : MonoBehaviour
    {
        //Destroy
        [SerializeField] private float time;

        private void Awake() => Destroy(gameObject, time);
    }
}
