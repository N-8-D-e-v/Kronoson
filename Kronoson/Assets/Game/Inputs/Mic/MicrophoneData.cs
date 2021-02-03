using UnityEngine;

namespace Game.Inputs.Mic
{
    public class MicrophoneData : MonoBehaviour
    {
        //Singleton
        private static MicrophoneData instance;

        //Global Fields
        public static float MicrophoneLevel = 0f;

        //Mic Info
        private AudioClip micRecord;
        private string device;
        private float[] waveData;
        private bool initialized = false;

        private void Awake()
        {
            if (!instance)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);

            InitMic();
        }

        private void FixedUpdate() => UpdateMicLevel();

            private void OnApplicationFocus(bool _focusStatus)
        {
            switch (_focusStatus)
            {
                case true when !initialized:
                    InitMic();
                    break;
                case false:
                    StopMic();
                    break;
            }
        }

        private void OnApplicationQuit() => StopMic();

        private void InitMic()
        {
            initialized = true;
            device ??= Microphone.devices[0];
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
            const int _sampleWindow = 64;
            int _micPos = Microphone.GetPosition(null) - (_sampleWindow + 1);
            
            waveData = new float[_sampleWindow];
            micRecord.GetData(waveData, _micPos);

            for (int _i = 0; _i < _sampleWindow; _i++)
            {
                float _peak = waveData[_i] * waveData[_i];

                if (_levelMax < _peak)
                    _levelMax = _peak;
            }

            float _decibels = 20 * Mathf.Log10(Mathf.Sqrt(_levelMax));
            return Mathf.Clamp(_decibels, -100f, 100f);
        }

        private void UpdateMicLevel() => MicrophoneLevel = GetMicLevel();
    }
}