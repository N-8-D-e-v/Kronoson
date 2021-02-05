using UnityEngine;

namespace Game.Levels.UI
{
    public class UI_LevelActions : MonoBehaviour
    {
        public void ResetLevel() => LevelData.Reset();

        public void StartGame() => LevelData.StartGame();

        public void StopGame() => LevelData.StopGame();
    }
}