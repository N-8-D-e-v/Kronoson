using UnityEngine;
using Game.Inputs.Mic;

namespace Game.General
{
    public class GameManager : MonoBehaviour
    {
        //Singleton
        private static GameManager Instance;

        //Global Fields
        public static GameState GameState = GameState.Play;

        //Assignables
        private Animator animator;

        //Time Scale
        [Header("Time Scale")]
        [Range(0.01f, 1f)] [SerializeField] private float timeScaleSmoothing = 0.2f;
        private float velocity = 0f;

        //Slow Motion
        [Header("Slow Motion")]
        [SerializeField] private float slowMotionThreshold = 0.4f;
        [SerializeField] private float slowMotionExitThreshold = 0.7f;

        //Animations
        private const string SLOW_MOTION = "slow_motion";

        private void Awake()
        {
            if (!Instance)
                Instance = this;
            else if (Instance != this)
                Destroy(gameObject);
            DontDestroyOnLoad(gameObject);

            animator = GetComponentInChildren<Animator>();
        }
        
        private void Update()
        {
            if (GameState == GameState.Play)
                UpdateTimeScale();
        }

        private void UpdateTimeScale()
        {
            float _timeScale = MicrophoneLevelToTimeScale.GetTimeScaleFromMicLevel(MicrophoneData.MicrophoneLevel);
            float _smoothTimeScale = Mathf.SmoothDamp(Time.timeScale, _timeScale, ref velocity, timeScaleSmoothing);
            Time.timeScale = _smoothTimeScale;
            UpdatePostProcessing();
        }

        private void UpdatePostProcessing()
        {
            if (Time.timeScale <= slowMotionThreshold)
                animator.SetBool(SLOW_MOTION, true);
            else if (Time.timeScale >= slowMotionExitThreshold)
                animator.SetBool(SLOW_MOTION, false);
        }
    }

    public enum GameState
    {
        Play,
        Pause
    }
}
