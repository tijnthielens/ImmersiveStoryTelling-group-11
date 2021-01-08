using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class FractalPhase : TripStageBase
{
    DepthOfField depthOfField;
    ColorGrading colorGrading;
    Bloom bloom;

    
    [SerializeField]
    Texture BloomTexture;
    [SerializeField]
    float BloomIntensity = .92f;
    [SerializeField]
    float BloomSoftKnee = .316f;
    [SerializeField]
    float BloomDirtIntensity = 100;
    [SerializeField]
    float BloomClamp = 7.48f;
    [SerializeField]
    float BloomThreshold= .39f;
    [SerializeField]
    float BloomDiffusion = 1.39f;
    [SerializeField]
    float BloomAnamorphicRatio = 0.95f;


    [SerializeField]
    float ColorGradingTint = -5;
    [SerializeField]
    float ColorGradingHueShift = 180;
    [SerializeField]
    float ColorGradingSaturation = 100;
    [SerializeField]
    float ColorGradingPostExposure = 0f;

    [SerializeField]
    float DoFFocusDistance = 12.71f;
    [SerializeField]
    KernelSize DoFKernelSize = KernelSize.Small;
    [SerializeField]
    float DoFAperture = 0.1f;
    [SerializeField]
    float DoFFocalLength = 50;

    void OnEnable()
    {
        Debug.Log("Fractal phase START");

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
        bloom.threshold.Override(BloomThreshold);
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
