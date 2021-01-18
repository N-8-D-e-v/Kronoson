using UnityEngine;

namespace Game.Levels.Objects.Player
{
    public class PlayerData : MonoBehaviour
    {
        //Singleton
        private static PlayerData Instance;

        //Assignables
        private new static Transform transform;

        private void Awake()
        {
            if (!Instance)
                Instance = this;
            else if (Instance != this)
                Destroy(gameObject);

            transform = GetComponent<Transform>();
        }

        public static Vector3 GetPlayerPosition() => transform.position;
    }
}
