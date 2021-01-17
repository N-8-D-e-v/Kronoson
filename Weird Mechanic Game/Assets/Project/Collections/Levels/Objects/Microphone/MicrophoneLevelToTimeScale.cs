using UnityEngine;

public static class MicrophoneLevelToTimeScale
{
    //Constants
    private const float MIN_DECIBELS = -90f;
    private const float COMPLETE_DECIBELS = -30f;
    private const float MAX_DECIBELS = 0f;
    private const float MIN_TIMESCALE = 0.2f;

    public static float GetTimeScaleFromMicLevel(float _micLevel)
    {
        _micLevel = Mathf.Clamp(_micLevel, MIN_DECIBELS, MAX_DECIBELS);

        float _add = 0 - MIN_DECIBELS;
        float _complete = COMPLETE_DECIBELS + _add;
        float _percentage = Mathf.Abs(_micLevel / _complete);
        float _negate = Mathf.Abs(MIN_DECIBELS) / (COMPLETE_DECIBELS - MIN_DECIBELS);

        float _timeScale = _negate - _percentage;
        _timeScale = Mathf.Clamp(_timeScale, MIN_TIMESCALE, _negate);
        return _timeScale;
    }
}
