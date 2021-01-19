using UnityEngine;

namespace Game.Levels.CameraControls
{
    [RequireComponent(typeof(Camera))]
    public class CameraShake : MonoBehaviour
    {
        //Shaking
        private float duration = 0;
        private float intensity = 0.5f;
        private float damping = 1;
        private float decay = 0.8f;

        //Defaults
        private const float DEFAULT_INTENSITY = 0.5f;
        private const float DEFAULT_DAMPING = 1f;
        private const float DEFAULT_DECAY = 0.8f;

        private void Update()
        {
            if (duration > 0)
            {
                Vector2 _shake = Random.insideUnitCircle * intensity;
                transform.localPosition = _shake;

                intensity *= decay;
                duration -= Time.deltaTime * damping;
            }
            else
            {
                duration = 0;
                transform.localPosition = Vector3.zero;
            }
        }

        public void ShakeCamera(CameraShakeSettings _cameraShake)
        {
            duration = _cameraShake.duration;
            intensity = _cameraShake.intensity;
            damping = _cameraShake.damping;
            decay = _cameraShake.decay;
        }
    }

    [System.Serializable]
    public class CameraShakeSettings
    {
        [Range(0.001f, 1f)] public float duration = 0.1f;
        [Range(0.001f, 5f)] public float intensity = 0.2f;
        [Range(0.001f, 5f)] public float damping = 1f;
        [Range(0.001f, 1f)] public float decay = 0.8f;
    }
}
