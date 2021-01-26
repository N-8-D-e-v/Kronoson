using UnityEngine;

namespace Game.Levels.Player
{
    public class PlayerData : MonoBehaviour
    {
        //Singleton
        private static PlayerData instance;

        //Assignables
        private new static Transform transform;
        
        //Constants
        public const string PLAYER_TAG = "Player";

        private void Awake()
        {
            if (!instance)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);

            transform = GetComponent<Transform>();
        }

        public static Vector3 GetPlayerPosition()
        {
            return transform.position;
        }
    }
}