using Game.General.SceneManagement;
using UnityEngine;

namespace Game.Levels.World
{
    public class Portal : MonoBehaviour
    {
        //Triggered
        private bool isTriggered = false;
        
        private void OnTriggerEnter2D(Collider2D _col)
        {
            if (isTriggered)
                return;
            isTriggered = true;
            SceneManager.LoadNextScene();
        }
    }
}