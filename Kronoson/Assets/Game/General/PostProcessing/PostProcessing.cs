using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Game.General.PostProcessing
{
    public class PostProcessing : MonoBehaviour
    {
        //Assignables
        private Volume volume;
        private Vignette vignette;
        private ChromaticAberration chromaticAberration;
        private LensDistortion lensDistortion;
        private ColorAdjustments colorAdjustments;

        //Values
        [SerializeField] private float vignetteIntensity = 0.2f;
        [SerializeField] private float chromaticAberrationIntensity = 0f;
        [SerializeField] private float lensDistortionIntensity = 0f;
        [SerializeField] private float colorAdjustmentsContrast = 0f;
        [SerializeField] private float colorAdjustmentsSaturation = 0f;

        private void Awake()
        {
            volume = GetComponent<Volume>();
            volume.profile.TryGet<Vignette>(out vignette);
            volume.profile.TryGet<ChromaticAberration>(out chromaticAberration);
            volume.profile.TryGet<LensDistortion>(out lensDistortion);
            volume.profile.TryGet<ColorAdjustments>(out colorAdjustments);
        }

        private void Update()
        {
            vignette.intensity.value = vignetteIntensity;
            chromaticAberration.intensity.value = chromaticAberrationIntensity;
            lensDistortion.intensity.value = lensDistortionIntensity;
            colorAdjustments.contrast.value = colorAdjustmentsContrast;
            colorAdjustments.saturation.value = colorAdjustmentsSaturation;
        }
    }
}