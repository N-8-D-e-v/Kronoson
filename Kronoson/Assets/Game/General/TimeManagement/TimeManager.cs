using UnityEngine;
using Game.Inputs.Mic;
using Game.Levels.Player;

namespace Game.General.TimeManagement
{
    public class TimeManager : MonoBehaviour
    {
        //Singleton
        private static TimeManager instance;

        //Assignables
        private Animator animator;

        //Time Scale
        [Header("Time Scales")] 
        [SerializeField] private float normalTimeScale = 1f;
        [SerializeField] private float slowMotionTimeScale = 0.2f;
        private float targetTimeScale = 1f;

        //Smoothing
        [Header("Smoothing")] 
        [SerializeField] private float timeScaleSmoothing = 0.2f;
        private float velocity = 0f;

        //Microphone
        [Header("Microphone")] 
        [SerializeField] private float slowMotionMicThreshold = -75f;
        private bool useMicrophone = true;

        //Animations
        private static readonly int SLOW_MOTION = Animator.StringToHash("slow_motion");

        private void Awake()
        {
            transform.parent = null;
            if (!instance)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
            DontDestroyOnLoad(gameObject);

            animator = GetComponentInChildren<Animator>();

            PlayerData.OnPlayerDeath += StopMicrophone;
            //TODO when the player starts the game, turn on the microphone
        }

        private void Update()
        {
            //TODO uncomment the line below
            //Time.timeScale = Mathf.SmoothDamp(Time.timeScale, targetTimeScale, ref velocity, timeScaleSmoothing);
            if (useMicrophone)
                UpdateTimeScale();
            else
                targetTimeScale = 1f;
        }

        private void UpdateTimeScale()
        {
            bool _slowMotion = MicrophoneData.MicrophoneLevel <= slowMotionMicThreshold;
            //TODO also uncomment the line below this one
            //animator.SetBool(SLOW_MOTION, _slowMotion);
            targetTimeScale = _slowMotion ? slowMotionTimeScale : normalTimeScale;
        }

        private void StopMicrophone() => useMicrophone = false;
    }
}