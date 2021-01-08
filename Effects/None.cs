using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class None : TripStageBase
{
    Vignette m_Vignette;
    float period = 25f;
    float offset = 1f;
    float scale = 1f;
    bool isChecked = true;
    float DeltaT = 0;
    public float blinkTime = 3;

    void OnEnable()
    {
        Debug.Log("None phase START");
        m_Vignette = ScriptableObject.CreateInstance<Vignette>();
        m_Vignette.enabled.Override(true);
        m_Vignette.center.Override(new Vector2(0.5f, 0.5f));
        m_Vignette.color.Override(Color.black);
        m_Vignette.mode.Override(VignetteMode.Classic);
        m_Vignette.rounded.Override(true);
        m_Vignette.roundness.Override(1f);
        m_Vignette.smoothness.Override(1f);

        m_Vignette.intensity.Override(1f);
        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Vignette);  

    }

    void Update()
    {
        DeltaT += Time.deltaTime;
        if(DeltaT < blinkTime)
        {
            m_Vignette.intensity.value = Mathf.Sin(period * Time.realtimeSinceStartup) * scale + offset;
        }
        else
        {
            m_Vignette.intensity.value = 0.60f;
        }

        //m_Vignette.intensity.value = Mathf.PingPong(Time.realtimeSinceStartup, 0.4f)+0.6f;
        /*if (isChecked)
        {
            Debug.Log("vignette intensity: " + m_Vignette.intensity.value);
            isChecked = false;
        }*/
    }
}