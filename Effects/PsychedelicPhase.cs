using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PsychedelicPhase : TripStageBase
{
    DepthOfField depthOfField;
    ColorGrading colorGrading;
    Bloom bloom;
    
    

    [SerializeField]
    float ColorGradingTint = -5;
    [SerializeField]
    float ColorGradingHueShift = 180;
    [SerializeField]
    float ColorGradingSaturation = 100;
    [SerializeField]
    float ColorGradingPostExposure = 0f;

    [SerializeField]
    float DoFFocusDistance = 12f;
    [SerializeField]
    KernelSize DoFKernelSize = KernelSize.Small;
    [SerializeField]
    float DoFAperture = 0.1f;
    [SerializeField]
    float DoFFocalLength = 20;

    [SerializeField]
    Texture2D BloomTexture;
    [SerializeField]
    float BloomIntensity = 30;
    [SerializeField]
    float BloomSoftKnee = 0.2f;
    [SerializeField]
    float BloomDirtIntensity = 7;
    [SerializeField]
    float BloomClamp = 20;
    [SerializeField]
    float BloomThreshold = .39f;
    [SerializeField]
    float BloomDiffusion = 8.39f;
    [SerializeField]
    float BloomAnamorphicRatio = 0.38f;


    void OnEnable()
    {
        Debug.Log("Psychedelic phase START");
        depthOfField = ScriptableObject.CreateInstance<DepthOfField>();
        colorGrading = ScriptableObject.CreateInstance<ColorGrading>();
        bloom = ScriptableObject.CreateInstance<Bloom>();

        depthOfField.enabled.Override(true);
        colorGrading.enabled.Override(true);
        bloom.enabled.Override(true);

        colorGrading.tint.Override(ColorGradingTint);
        colorGrading.hueShift.Override(ColorGradingHueShift);
        colorGrading.saturation.Override(ColorGradingSaturation);
        colorGrading.postExposure.Override(ColorGradingPostExposure);

        bloom.intensity.Override(BloomIntensity);
        bloom.softKnee.Override(BloomSoftKnee);
        bloom.dirtTexture.Override(BloomTexture);

        bloom.dirtIntensity.Override(BloomDirtIntensity);
        bloom.clamp.Override(BloomClamp);
        bloom.diffusion.Override(BloomDiffusion);
        bloom.anamorphicRatio.Override(BloomAnamorphicRatio);

        depthOfField.focusDistance.Override(DoFFocusDistance);
        depthOfField.kernelSize.Override(DoFKernelSize);
        depthOfField.aperture.Override(DoFAperture);
        depthOfField.focalLength.Override(DoFFocalLength);

        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, depthOfField, bloom, colorGrading);
    }

    void Update()
    {
        
    }
}
