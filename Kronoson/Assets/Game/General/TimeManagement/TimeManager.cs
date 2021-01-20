using UnityEngine;
using Game.Inputs.Mic;

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

        //Mic Level
        [Header("Mic Level")] 
        [SerializeField] private float slowMotionMicThreshold = -75f;

        //Animations
        private static readonly int SLOW_MOTION = Animator.StringToHash("slow_motion");

        private void Awake()
        {
            if (!instance)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
            DontDestroyOnLoad(gameObject);

            animator = GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            //Time.timeScale = Mathf.SmoothDamp(Time.timeScale, targetTimeScale, ref velocity, timeScaleSmoothing);
            UpdateTimeScale();
        }

        private void UpdateTimeScale()
        {
            bool _slowMotion = MicrophoneData.MicrophoneLevel <= slowMotionMicThreshold;
            //animator.SetBool(SLOW_MOTION, _slowMotion);
            targetTimeScale = _slowMotion ? slowMotionTimeScale : normalTimeScale;
        }
    }
}