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
        private readonly float[] waveData = new float[SAMPLE_WINDOW];

        //Constants
        private const int SAMPLE_WINDOW = 64;

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

            InitMic();
        }

        private void FixedUpdate() => UpdateMicLevel();

        private void OnApplicationQuit() => StopMic();

        private void InitMic()
        {
            device ??= Microphone.devices[0];
            micRecord = Microphone.Start(device, true, 999, 44100);
        }

        private void StopMic() => Microphone.End(device);

        private float GetMicLevel()
        {
            float _levelMax = 0f;
            int _micPos = Microphone.GetPosition(null) - (SAMPLE_WINDOW + 1);
            micRecord.GetData(waveData, _micPos);

            for (int _i = 0; _i < SAMPLE_WINDOW; _i++)
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