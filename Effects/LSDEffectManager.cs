using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using System;
using UnityEngine.SceneManagement;

[Serializable]
public struct LSDTripStageDurations
{
    public LSDTripStage stage;
    public int duration;
}
public class LSDEffectManager : MonoBehaviour
{
    [SerializeField]
    public Texture2D IntenseHallucinationsTexture;
    [SerializeField]
    private GameObject Player;
    private LSDEffects lsdEffects;

    public SelectLSDCharacterEvent SelectLSDCharacterEvent;
    
    public LSDTripStageDurations[] tripStageDurations;

    /// <summary>
    /// Add lines here for every effect you want to include and deactivate it. Then activate it in the respective update method.
    /// </summary>
    void Start()
    {
        if (SelectLSDCharacterEvent == null) { SelectLSDCharacterEvent = new SelectLSDCharacterEvent(); }
        SelectLSDCharacterEvent.AddListener(InitLSDEffects);

        var dict = new Dictionary<LSDTripStage, int>() {};
        
        for (int i = 0; i < tripStageDurations.Length; i++)
        {
            dict.Add(tripStageDurations[i].stage, tripStageDurations[i].duration);
        }

        // Initialize LSD Effect manager
        lsdEffects = new LSDEffects(dict, IntenseHallucinationsTexture);
        lsdEffects.TripStageStartEvent.AddListener(StartEffect);
    }
    void StartEffect(LSDTripStage stage)
    {
        switch (stage)
        {
            case LSDTripStage.None:
                gameObject.GetComponent<None>().enabled = true;
                break;
            case LSDTripStage.Onset:
                gameObject.GetComponent<None>().enabled = false;
                gameObject.GetComponent<Onset>().enabled = true;
                break;
            case LSDTripStage.MildHallucinations:
                gameObject.GetComponent<Onset>().enabled = false;
                gameObject.GetComponent<MildHallucinations>().enabled = true;
                break;

            case LSDTripStage.MildIntenseTransition:
                gameObject.GetComponent<MildHallucinations>().enabled = false;
                gameObject.GetComponent<MildIntenseTransition>().enabled = true;
                break;

            case LSDTripStage.IntenseHallucinations:
                gameObject.GetComponent<MildIntenseTransition>().enabled = false;
                gameObject.GetComponent<IntenseHallucinations>().enabled = true;
                break;
            case LSDTripStage.PsychedelicPhase:
                gameObject.GetComponent<IntenseHallucinations>().enabled = false;
                gameObject.GetComponent<PsychedelicPhase>().enabled = true;
                break;
            case LSDTripStage.FractalPhase:
                gameObject.GetComponent<PsychedelicPhase>().enabled = false;
                gameObject.GetComponent<FractalPhase>().enabled = true;
                break;
            
            case LSDTripStage.BadTrip:
                gameObject.GetComponent<FractalPhase>().enabled = false;
                if (Player != null)
                {
                    Debug.Log("Destroying Player");
                    GameObject.Destroy(Player);
                }
                SceneManager.LoadScene("BadTripScene");
                break;

            default:
                break;
        }
    }
    void InitLSDEffects()
    {
        StartCoroutine(lsdEffects.TimedLSDTrip());
    }
}

[Serializable]
public class SelectLSDCharacterEvent: UnityEvent { }

/// <summary>
/// Event to be raised when the trip needs to progress to the next stage
/// </summary>
[Serializable]
public class TripStageStartEvent : UnityEvent<LSDTripStage>
{
    public LSDTripStage StageToActivate;
}

public enum LSDTripStage
{
    None,
    Onset,
    MildHallucinations,
    MildIntenseTransition,
    IntenseHallucinations,
    PsychedelicPhase,
    FractalPhase,
    BadTrip
}