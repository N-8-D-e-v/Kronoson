using UnityEngine;

namespace Game.Levels.General.Player
{
    public class PlayerData : MonoBehaviour
    {
        //Singleton
        private static PlayerData Instance;

        //Components
        public static Transform Transform;

        private void Awake()
        {
            if (!Instance)
                Instance = this;
            else if (Instance != this)
                Destroy(gameObject);

            Transform = transform;
        }
    }
}
