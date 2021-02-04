using UnityEngine;
using Game.Levels.Player;
using UnityEngine.Audio;

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
        private bool isSlowMotion = false;
        
        //Audio
        [Header("Audio")]
        [SerializeField] private AudioMixer audioMixer;

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
            Time.timeScale = Mathf.SmoothDamp(Time.timeScale, targetTimeScale, ref velocity, timeScaleSmoothing);
            UpdateTimeScale();
        }

        private void UpdateTimeScale()
        {
            //bool _slowMotion = MicrophoneData.MicrophoneLevel <= slowMotionMicThreshold;
            if (Input.GetKeyDown(KeyCode.Space))
                isSlowMotion = !isSlowMotion;
            bool _slowMotion = isSlowMotion;
            if (useMicrophone)
                targetTimeScale = _slowMotion ? slowMotionTimeScale : normalTimeScale;
            else
                targetTimeScale = 1f;
            
            animator.SetBool(SLOW_MOTION, _slowMotion);
            audioMixer.SetFloat("pitch", Time.timeScale);
        }

        private void StopMicrophone() => useMicrophone = false;
    }
}