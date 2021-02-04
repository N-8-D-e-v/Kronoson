using UnityEngine;
using UnityEngine.UI;

namespace Game.Inputs.Mic
{
    [RequireComponent(typeof(Slider))]
    public class MicrophoneLevelSlider : MonoBehaviour
    {
        //Assignables
        private Slider slider;

        private void Awake()
        {
            slider = GetComponent<Slider>();
            slider.minValue = MicrophoneData.MIC_LEVEL_FLOOR;
            slider.maxValue = MicrophoneData.MIC_LEVEL_CEILING;
        }

        private void Update() => slider.value = MicrophoneData.MicrophoneLevel;
    }
}