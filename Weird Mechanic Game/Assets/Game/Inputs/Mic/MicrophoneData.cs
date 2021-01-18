using UnityEngine;

namespace Game.Inputs.Mic
{
    public class MicrophoneData : MonoBehaviour
    {
        //Singleton
        private static MicrophoneData Instance;
        
        //Global Fields
        public static float MicrophoneLevel = 0f;
        
        //Mic Info
        private AudioClip micRecord;
        private string device;
        private float[] waveData = new float[SAMPLE_WINDOW];
        private bool initialized = false;

        //Constants
        private const int SAMPLE_WINDOW = 64;

        private void Awake()
        {
            if (!Instance)  
                Instance = this;
            else if (Instance != this)
                Destroy(gameObject);
                
            InitMic();
        }

        private void FixedUpdate() => UpdateMicLevel();

        private void OnApplicationFocus(bool _focusStatus)
        {
            if (_focusStatus && !initialized)
                InitMic();
            else if (!_focusStatus)
                StopMic();
        }

        private void InitMic()
        {
            initialized = true;
            if (device == null)
                device = Microphone.devices[0];
            micRecord = Microphone.Start(device, true, 999, 44100);
        }

        private void StopMic()
        {
            initialized = false;
            Microphone.End(device);
        }

        private float GetMicLevel()
        {
            float _levelMax = 0f;
            int _micPos = UnityEngine.Microphone.GetPosition(null) - (SAMPLE_WINDOW + 1);

            micRecord.GetData(waveData, _micPos);

            for (int i = 0; i < SAMPLE_WINDOW; i++)
            {
                float _peak = waveData[i] * waveData[i];

                if (_levelMax < _peak)
                    _levelMax = _peak;
            }
            float _decibels = 20 * Mathf.Log10(Mathf.Sqrt(_levelMax));
            return Mathf.Clamp(_decibels, -100f, 100f);
        }

        private void UpdateMicLevel() => MicrophoneLevel = GetMicLevel();
    }
}
