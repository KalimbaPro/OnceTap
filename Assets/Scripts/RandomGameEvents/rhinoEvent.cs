using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhinoEvent : randomEvent
{
    public Transform[] spawnPoints;
    public GameObject rhinoPrefab;
    private GameObject[] rhinoCopies;

    protected override void CustomStartEvent()
    {
        rhinoCopies = new GameObject[spawnPoints.Length];
        for (int i = 0; i < spawnPoints.Length; i+=1) {
            rhinoCopies[i] = Instantiate(rhinoPrefab, spawnPoints[i].position, Quaternion.identity);
        }
    }

    protected override void CustomEndEvent()
    {
        foreach (GameObject rhinoCopy in rhinoCopies) {
            Destroy(rhinoCopy);
        }
    }

    void Update()
    {
        HandleEventTime();
    }
}