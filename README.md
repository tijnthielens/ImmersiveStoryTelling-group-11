# ImmersiveStoryTelling-group-11

# LSD Effects 

## LSD Effect Manager - Effects/LSDEffectManager.cs
This script is the core of the LSD trip logic. It configures the trip stage lengths, activates the necessary scripts with the post processing effects, initiates the LSDEffects class and assigns an event listener to the TripStageStartEvent, it also initializes the SelectLSDCharacterEvent and assigns a listener that starts the trip coroutine when the SelectLSDCharacterEvent triggers. It loads the Bad Trip Scene after the other stages.

## LSD Effects - Effects/LSDEffects.cs
Enumerates the stages and invokes the next stage after waiting for the previous one to complete. It acts as a timer with respect to the stage durations defined in the LSD Effect Manager class.

## Effect Scripts
### TripStageBase
The base class for each trip stage post processing effect script. 
```
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TripStageBase : MonoBehaviour
{
    protected PostProcessVolume m_Volume;
    private void OnDisable()
    {
        RuntimeUtilities.DestroyVolume(m_Volume, true, true);
    }
}
```
Each effect inherits from this base class and has a postprocessing volume and destroys the volume on disable. The effect manager enables/disables any effect by simply enabling/disabling the relevant script. (see LSDEffectManager.cs:StartEffect)

```
    gameObject.GetComponent<IntenseHallucinations>().enabled = true;
    gameObject.GetComponent<IntenseHallucinations>().enabled = false;
```
A stage script looks something like this...
```
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
```
OnEnable is used to easily switch effects on and off. When this lifecycle hook is called, the effects are initiated as  
ScriptableObjects and the initial values are overwritten. Then a PostProcessingVolume is created with the overriden effects.
The Update method can be used to dynamically change the parameters of the post processing effects during a stage.
OnDisable is handled by parent class TripStageBase (see above).

# Spawning Dancers
## Generate People Script - GeneratePeople.cs
A script that takes dancer prefabs as input from the editor and the number of dancers to spawn. We defined the spawning area with min and max values for the X and Z positions. The script keeps track of the positions of the spawned characters and makes sure other characters are spawned at a certain distance with respect to the ones that exist (see GetValidRandomPosition()). We noticed performance degrades when spawning too many dancers.


# Dynamic Lights
