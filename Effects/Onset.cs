using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Onset : TripStageBase
{
    Vignette m_Vignette;
    DepthOfField m_DepthOfField;

    [SerializeField]
    bool VignetteRounded = true;
    [SerializeField]
    float VignetteSmoothness = 1f;
    [SerializeField]
    float VignetteRoundness = 1f;
    [SerializeField]
    Vector2 VignetteCenter = new Vector2(0.5f, 0.5f);
    [SerializeField]
    VignetteMode VignetteMode = VignetteMode.Classic;
    [SerializeField]
    float VignetteIntensity = 0.6f;

    [SerializeField]
    float DoFFocusDistance = 6;
    [SerializeField]
    KernelSize DoFKernelSize = KernelSize.Small;
    [SerializeField]
    float DoFAperture = 0.1f;
    [SerializeField]
    float DoFFocalLength= 50;


    void OnEnable()
    {
        Debug.Log("Onset phase START");
        m_Vignette = ScriptableObject.CreateInstance<Vignette>();
        m_Vignette.enabled.Override(true);
        
        m_DepthOfField = ScriptableObject.CreateInstance<DepthOfField>();
        m_DepthOfField.enabled.Override(true);



        m_Vignette.rounded.Override(VignetteRounded);
        m_Vignette.roundness.Override(VignetteRoundness);
        m_Vignette.smoothness.Override(VignetteSmoothness);
        m_Vignette.mode.Override(VignetteMode);
        m_Vignette.center.Override(VignetteCenter);
        m_Vignette.intensity.Override(VignetteIntensity);

        
        m_DepthOfField.focusDistance.Override(DoFFocusDistance);
        m_DepthOfField.kernelSize.Override(DoFKernelSize);
        m_DepthOfField.aperture.Override(DoFAperture);
        m_DepthOfField.focalLength.Override(DoFFocalLength);

        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Vignette, m_DepthOfField);
    }

    void Update() { }
}