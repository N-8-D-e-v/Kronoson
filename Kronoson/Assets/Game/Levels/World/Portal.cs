using Game.General.SceneManagement;
using Game.Levels.Player;
using UnityEngine;

namespace Game.Levels.World
{
    public class Portal : MonoBehaviour
    {
        //Triggered
        private bool isTriggered = false;
        
        private void OnTriggerEnter2D(Collider2D _col)
        {
            if (isTriggered || !_col.CompareTag(PlayerData.PLAYER_TAG))
                return;
            isTriggered = true;
            SceneManager.LoadNextScene();
        }
    }
}