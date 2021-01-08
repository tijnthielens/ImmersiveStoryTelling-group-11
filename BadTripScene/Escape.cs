using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour
{
    public GameObject Player;
    [SerializeField]
    public int BadTripDurationSeconds = 225;
    bool isEscaping = false;
    void Update()
    {
        if ((Time.timeSinceLevelLoad >= BadTripDurationSeconds) && !isEscaping)
        {
            if(Player != null)
            {
                Debug.Log("BadTrip destroy player");
                GameObject.Destroy(Player);
            }
            SceneManager.LoadScene("project");
            isEscaping = true;
        }
    }
}
