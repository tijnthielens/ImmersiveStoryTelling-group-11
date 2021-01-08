# ImmersiveStoryTelling-group-11

# LSD Effects 

## LSD Effect Manager - Effects/LSDEffectManager.cs
This script is the core of the LSD trip logic. It configures the trip stage lengths, activates the necessary scripts with the post processing effects, initiates the LSDEffects class and assigns an event listener to the TripStageStartEvent, it also initializes the SelectLSDCharacterEvent and assigns a listener that starts the trip coroutine when the SelectLSDCharacterEvent triggers. It loads the Bad Trip Scene after the other stages.

## LSD Effects - Effects/LSDEffects.cs
Enumerates the stages and invokes the next stage after waiting for the previous one to complete. It acts as a timer with respect to the stage durations defined in the LSD Effect Manager class.

## Effect Scripts
### TripStageBase
The base class for each trip stage post processing effect script. 
`
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
`
Each effect inherits from this base class and has a postprocessing volume and destroys the volume on disable. The effect manager enables/disables any effect by simply enabling/disabling the relevant script. (see LSDEffectManager.cs:StartEffect)

`
    gameObject.GetComponent<IntenseHallucinations>().enabled = true;
    gameObject.GetComponent<IntenseHallucinations>().enabled = false;
`
