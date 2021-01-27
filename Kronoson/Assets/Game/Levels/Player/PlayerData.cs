using UnityEngine;
using Game.General.Utilities.Delegates;

namespace Game.Levels.Player
{
    public class PlayerData : MonoBehaviour
    {
        //Singleton
        private static PlayerData instance;
        
        //Event
        public static event VoidDelegate OnPlayerDeath;

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

        public static Vector3 GetPlayerPosition() => transform.position;

        public void PlayerDeath() => OnPlayerDeath?.Invoke();
    }
}