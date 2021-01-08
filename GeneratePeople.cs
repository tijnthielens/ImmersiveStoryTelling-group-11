using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePeople : MonoBehaviour
{
    public GameObject[] Mensen = new GameObject[3];
    private float xpos;
    private float zpos;
    private int AantalMensen = 0;
    private Vector3[] usedPositions;
    
    public int NumberOfClones = 30;
    public float MinDistance = 0.5f;
    void Start()
    {
        usedPositions = new Vector3[NumberOfClones];
        StartCoroutine(DropMens());
    }
    IEnumerator DropMens()
    {
        while (AantalMensen < NumberOfClones)
        {
            Vector3 position = GetValidRandomPosition();
            var instance = Instantiate(Mensen[Random.Range(0, 2)], position, Quaternion.identity);
            instance.transform.Rotate(0f, Random.Range(0, 359) , 0f, Space.Self);
            yield return new WaitForSeconds(0.1f);
            AantalMensen += 1;
        }
    }
    private Vector3 GetValidRandomPosition()
    {
        Vector3 position = Vector3.zero;
        while (!IsValidPosition(position))
        {
            xpos = Random.Range(-9, 11);
            zpos = Random.Range(-10, 11);
            position = new Vector3(xpos, 0, zpos);
        }
        return position;
    }
    private bool IsValidPosition(Vector3 position)
    {
        return (!position.Equals(Vector3.zero) && IsRespectingDistance(position));
    }
    private bool IsRespectingDistance(Vector3 position)
    {
        for (int i = 0; i < usedPositions.Length; i++)
        {
            if (Vector3.Distance(usedPositions[i], position) < MinDistance)
            {
                return false;
            }
        }
        return true;
    }
}
