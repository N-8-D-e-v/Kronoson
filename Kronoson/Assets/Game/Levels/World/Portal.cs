using Game.General.Audio;
using Game.General.SceneManagement;
using Game.Levels.Player;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Levels.World
{
    public class Portal : MonoBehaviour
    {
        //Event
        [SerializeField] private UnityEvent onPortalReached;
        
        //Triggered
        private bool isTriggered = false;
        
        private void OnTriggerEnter2D(Collider2D _col)
        {
            if (isTriggered || !_col.CompareTag(PlayerData.PLAYER_TAG))
                return;
            SoundManager.PlaySound(SoundType.Portal);
            isTriggered = true;
            onPortalReached?.Invoke();
            SceneManager.LoadNextScene();
            LevelData.NextLevel();
        }
    }
}