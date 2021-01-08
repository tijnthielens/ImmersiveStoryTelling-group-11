using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class MildHallucinations : TripStageBase
{
    DepthOfField depthOfField;
    Grain grain;


    [SerializeField]
    float DoFFocusDistance = 10;
    [SerializeField]
    KernelSize DoFKernelSize = KernelSize.Small;
    [SerializeField]
    float DoFAperture = 0.1f;
    [SerializeField]
    float DoFFocalLength = 50;

    [SerializeField]
    bool GrainIsColored = true;
    [SerializeField]
    float GrainIntensity = 0.5f;
    [SerializeField]
    float GrainSize = 3;
    [SerializeField]
    float GrainLumContrib = 0.1f;

    [SerializeField]
    float MaxGrainSize = 3f;
    [SerializeField]
    float MinGrainSize = 0.1f;

    [SerializeField]
    float MaxGrainLumContrib = 1f;
    [SerializeField]
    float MinGrainLumContrib = 0.1f;

    void OnEnable()
    {
        Debug.Log("Mild phase START");
        depthOfField = ScriptableObject.CreateInstance<DepthOfField>();
        grain = ScriptableObject.CreateInstance<Grain>();

        depthOfField.enabled.Override(true);
        grain.enabled.Override(true);

        depthOfField.focusDistance.Override(DoFFocusDistance);
        depthOfField.kernelSize.Override(DoFKernelSize);
        depthOfField.aperture.Override(DoFAperture);
        depthOfField.focalLength.Override(DoFFocalLength);

        grain.colored.Override(GrainIsColored);
        grain.intensity.Override(GrainIntensity);
        grain.size.Override(GrainSize);
        grain.lumContrib.Override(GrainLumContrib);

        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, grain, depthOfField);
    }

    void Update()
    {
        grain.size.value = Random.Range(MinGrainSize, MaxGrainSize);
        grain.lumContrib.value = Random.Range(MinGrainLumContrib, MaxGrainLumContrib);
    }
}
