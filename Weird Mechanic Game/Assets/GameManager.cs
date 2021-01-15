using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton
    private static GameManager Instance;

    //Global Fields
    public static GameState GameState = GameState.Play;
    public static float TimeScale = 1f;

    //Time Scale
    [Header("Time Scale")]
    [Range(0.01f, 1f)] [SerializeField] private float timeScaleSmoothing = 0.2f;
    private float velocity;

    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    
    private void Update()
    {
        if (GameState == GameState.Play)
            UpdateTimeScale();
    }

    private void UpdateTimeScale()
    {
        float _timeScale = MicrophoneLevelToTimeScale.GetTimeScaleFromMicLevel(MicrophoneData.MicrophoneLevel);
        Time.timeScale = Mathf.SmoothDamp(Time.timeScale, _timeScale, ref velocity, timeScaleSmoothing);
    }
}

public enum GameState
{
    Play,
    Pause
}
