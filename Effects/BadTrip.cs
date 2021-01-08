using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class BadTrip : TripStageBase
{
    Grain grain;

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

    // Start is called before the first frame update
    void Start()
    {
        grain = ScriptableObject.CreateInstance<Grain>();
        grain.enabled.Override(true);

        grain.colored.Override(GrainIsColored);
        grain.intensity.Override(GrainIntensity);
        grain.size.Override(GrainSize);
        grain.lumContrib.Override(GrainLumContrib);

        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, grain);
    }

    // Update is called once per frame
    void Update()
    {
       // grain.size.value = Random.Range(MinGrainSize, MaxGrainSize);

    }
}
