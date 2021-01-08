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
