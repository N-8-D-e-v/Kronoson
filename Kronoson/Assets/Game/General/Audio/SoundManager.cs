using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.General.Audio
{
    public class SoundManager : MonoBehaviour
    {
            //Singleton
            private static SoundManager instance;

            //Audio Sources
            [SerializeField] private int maxAudioSources = 20;
            private static Queue<AudioSource> audioSources;

            //Sounds
            [SerializeField] private Sound[] sounds = new Sound[1]
            {
                new Sound(0.9f, 1.1f, 1f, 1f)
            };

            private void Awake()
            {
                transform.parent = null;
                
                if (!instance)
                    instance = this;
                else if (instance != this)
                    Destroy(gameObject);
                DontDestroyOnLoad(gameObject);

                InitAudioSources();
            }

            private void InitAudioSources()
            {
                audioSources = new Queue<AudioSource>(maxAudioSources);
                
                for (int _i = 0; _i < maxAudioSources; _i++)
                {
                    GameObject _g = new GameObject($"AudioSource_{_i}");
                    AudioSource _audioSource = _g.AddComponent<AudioSource>();
                    _audioSource.transform.parent = transform;
                    _audioSource.playOnAwake = false;
                    _audioSource.loop = false;
                    audioSources.Enqueue(_audioSource);
                }
            }

            public static void PlaySound(SoundType _soundType)
            {
                if (audioSources.Count == 0)
                    return;
                AudioSource _audioSource = audioSources.Dequeue();
                Sound _sound = instance.sounds[(int) _soundType];
                _audioSource.volume = _sound.GetVolume();
                _audioSource.pitch = _sound.GetPitch();

                _audioSource.PlayOneShot(_sound.GetClip());
                instance.StartCoroutine(EnqueueAudioSource(_sound.GetClip().length, _audioSource));
            }

            private static IEnumerator EnqueueAudioSource(float _time, AudioSource _audioSource)
            {
                yield return new WaitForSeconds(_time);
                audioSources.Enqueue(_audioSource);
            }
        }

        [System.Serializable]
        public class Sound
        {
            //Name
            [SerializeField] private string name = "New Sound";
            
            //Sounds
            [SerializeField] private AudioClip[] sounds;

            //Modulation
            [Header("Modulation")]
            [Range(0f, 3f)] [SerializeField] private float minPitch;
            [Range(0f, 3f)] [SerializeField] private float maxPitch;
            [Range(0f, 1f)] [SerializeField] private float minVolume;
            [Range(0f, 1f)] [SerializeField] private float maxVolume;

            public Sound(float _minPitch, float _maxPitch, float _minVolume, float _maxVolume)
            {
                minPitch = _minPitch;
                maxPitch = _maxPitch;
                minVolume = _minVolume;
                maxVolume = _maxVolume;
            }

            public AudioClip GetClip() => sounds[Random.Range(0, sounds.Length)];

            public float GetPitch() => Random.Range(minPitch, maxPitch);

            public float GetVolume() => Random.Range(minVolume, maxVolume);
        }

        public enum SoundType
        {
            SemiAutoGunShoot,
            ShotgunGunShoot,
            AutoGunShoot,
            GrenadeLauncherGunShoot,
            GrenadeLauncherGunExplode,
            PlayerHurt,
            EnemyHurt,
            PlayerDeath,
            EnemyDeath,
            PickUp,
            Drop,
            Portal,
            Bullet,
            Spring
        }
}
