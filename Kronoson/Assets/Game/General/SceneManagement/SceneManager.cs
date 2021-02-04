using UnityEngine;

namespace Game.General.SceneManagement
{
    [RequireComponent(typeof(Animator))]
    public class SceneManager : MonoBehaviour
    {
        //Singleton
        private static SceneManager instance;
        
        //Assignables
        private static Animator animator;

        //Scene Transitions
        private static int targetScene;

        //Animation
        private static readonly int TRANSITION = Animator.StringToHash("transition");

        private void Awake()
        {
            transform.parent = null;

            if (!instance)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);

            animator = GetComponent<Animator>();
        }

        private static void LoadScene(int _sceneIndex)
        {
            targetScene = _sceneIndex;
            animator.SetTrigger(TRANSITION);
        }

        public static void LoadCurrentScene() => LoadScene(GetCurrentScene());

        public static void LoadNextScene() => LoadScene(GetCurrentScene() + 1);

        public static void LoadPreviousScene() => LoadScene(GetCurrentScene() - 1);

        private void ChangeScene() => 
            UnityEngine.SceneManagement.SceneManager.LoadScene(targetScene);
        
        private static int GetCurrentScene() => UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
    }
}