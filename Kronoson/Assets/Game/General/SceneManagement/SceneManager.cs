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
        
        //Scenes
        [SerializeField] private string[] scenes;
        private static string[] scenesStatic;
        
        //Scene Transitions
        private static int targetScene;

        //Animation
        private static readonly int TRANSITION = Animator.StringToHash("transition");

        private void Awake()
        {
            transform.parent = null;
            
            if (!instance)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
            DontDestroyOnLoad(gameObject);

            animator = GetComponent<Animator>();
            scenesStatic = scenes;
        }

        public static void LoadScene(string _sceneName)
        {
            targetScene = GetSceneByName(_sceneName);
            animator.SetTrigger(TRANSITION);
        }
        
        public static void LoadScene(int _sceneIndex)
        {
            targetScene = _sceneIndex;
            animator.SetTrigger(TRANSITION);
        }

        public static void LoadNextScene()
        {
            int _currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
            int _nextScene = _currentScene + 1;
            LoadScene(_nextScene);
        }

        private static int GetSceneByName(string _name)
        {
            for (int _i = 0; _i < scenesStatic.Length; _i++)
            {
                if (scenesStatic[_i] == _name)
                    return _i;
            }

            return UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        }

        private void ChangeScene() => 
            UnityEngine.SceneManagement.SceneManager.LoadScene(targetScene);
    }
}