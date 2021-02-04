using Game.General.SceneManagement;
using UnityEngine;

namespace Game.Levels.UI
{
    public class UI_SceneActions : MonoBehaviour
    {
        public void LoadNextScene() => SceneManager.LoadNextScene();

        public void LoadPreviousScene() => SceneManager.LoadPreviousScene();
    }
}
