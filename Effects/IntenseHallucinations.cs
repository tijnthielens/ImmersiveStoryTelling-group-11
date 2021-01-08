using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class IntenseHallucinations : TripStageBase
{
    Bloom bloom;
    DepthOfField depthOfField;

    [SerializeField]
    float DoFFocusDistance = 6;
    [SerializeField]
    KernelSize DoFKernelSize = KernelSize.Small;
    [SerializeField]
    float DoFAperture = 0.1f;
    [SerializeField]
    float DoFFocalLength = 20;

    [SerializeField]
    Texture[] BloomTextures;
    [SerializeField]
    float BloomIntensity = 30;
    [SerializeField]
    float BloomSoftKnee = .2f;
    [SerializeField]
    float BloomDirtIntensity = 7;
    [SerializeField]
    float BloomClamp = 20;
    [SerializeField]
    float BloomDiffusion = 8.39f;
    [SerializeField]
    float BloomAnamorphicRatio = 0.38f;
    private float deltaT = 0f;


    void OnEnable()
    {
        Debug.Log("Intense phase START");

        depthOfField = ScriptableObject.CreateInstance<DepthOfField>();
        bloom = ScriptableObject.CreateInstance<Bloom>();

        depthOfField.enabled.Override(true);
        bloom.enabled.Override(true);

        depthOfField.focusDistance.Override(DoFFocusDistance);
        depthOfField.kernelSize.Override(DoFKernelSize);
        depthOfField.aperture.Override(DoFAperture);
        depthOfField.focalLength.Override(DoFFocalLength);

        bloom.intensity.Override(BloomIntensity);
        bloom.softKnee.Override(BloomSoftKnee);
        bloom.dirtTexture.Override(BloomTextures[0]);
        bloom.dirtIntensity.Override(BloomDirtIntensity);
        bloom.clamp.Override(BloomClamp);
        bloom.diffusion.Override(BloomDiffusion);
        bloom.anamorphicRatio.Override(BloomAnamorphicRatio);

        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, depthOfField, bloom);
    }

    void Update()
    {
        deltaT += Time.deltaTime;
        if (deltaT > 5)
        {
            bloom.dirtTexture.value = BloomTextures[Random.Range(0, BloomTextures.Length - 1)];
            deltaT = 0;
        }

        bloom.dirtIntensity.value = Random.Range(7, 20);
    }
}
