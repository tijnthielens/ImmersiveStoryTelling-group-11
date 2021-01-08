using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class LSDEffects: MonoBehaviour
{
    public Dictionary<LSDTripStage, int> TripStageDurations; // in seconds
    public Dictionary<LSDTripStage, GameObject> TripStages; // in seconds

    public TripStageStartEvent TripStageStartEvent;

    public Texture2D IntenseHallucinationsTexture;

    const float VIGNETTE_INTENSITY_DELTA = 0.05f;
    private GameObject activeObject;
    LSDTripStage current = LSDTripStage.None;
    bool isRunning = true;
    public LSDEffects(Dictionary<LSDTripStage, int> tripStageDurations, Texture2D intenseHallucinationsTexture)
    {
        IntenseHallucinationsTexture = intenseHallucinationsTexture;
        if (TripStageStartEvent == null) { TripStageStartEvent = new TripStageStartEvent(); }        
        // TripStageStartEvent.AddListener(InitState);
        TripStageDurations = tripStageDurations;
    }
    /// <summary>
    /// Invokes TripStageStartEvent after the duration for that trip stage is passed.
    /// </summary>
    /// <param name="currentStage"></param>
    /// <returns></returns>
    public IEnumerator TimedLSDTrip()
    {
        while(isRunning)
        {
            Debug.Log("stage: " + current);
            if ((int)current <= (int)LSDTripStage.BadTrip)
            {
                TripStageStartEvent.Invoke(current);
            }
            else
            {
                isRunning = false;
            }

            yield return new WaitForSeconds(TripStageDurations[current]);
            current = NextStage(current);
            
        }
    }

    /// <summary>
    /// Gets next TripStage enum value from current value.
    /// Used to invoke the NextStage event.
    /// </summary>
    /// <param name="currentStage"></param>
    /// <returns></returns>
    private LSDTripStage NextStage(LSDTripStage currentStage)
    {
        Debug.Log("Current Stage: " + currentStage);
        LSDTripStage newStage = (LSDTripStage)((int) currentStage + 1);
        Debug.Log("Next Stage: " + newStage);
        return newStage;
    }
    
    public void InitState(LSDTripStage stage)
    {
        Debug.Log("switching to state: " + stage);
        if (stage != LSDTripStage.BadTrip)
        {
            Destroy(activeObject);
            activeObject = GameObject.Instantiate(TripStages[stage]);
            Debug.Log(activeObject.name);
        } else
        {
            InitBadTrip();
        }
    }
    // BAD TRIP
    public void InitBadTrip()
    {
        SceneManager.LoadScene("BadTripScene");
    }
}
