using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Pulsate : MonoBehaviour
{
    PostProcessVolume m_Volume;
    Vignette m_Vignette;

    void OnEnable()
    {
        m_Vignette = ScriptableObject.CreateInstance<Vignette>();
        m_Vignette.enabled.Override(true);
        m_Vignette.intensity.Override(1f);
        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Vignette);
    }

    void Update()
    {
        m_Vignette.intensity.value = Mathf.Sin(Time.realtimeSinceStartup);
    }

    void OnDestroy()
    {
        m_Vignette.SetAllOverridesTo(false);

        RuntimeUtilities.DestroyVolume(m_Volume, true, true);
    }
    private void OnDisable()
    {
        m_Vignette.SetAllOverridesTo(false);

        RuntimeUtilities.DestroyVolume(m_Volume, true, true);
    }
}