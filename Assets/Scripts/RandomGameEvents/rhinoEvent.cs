using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhinoEvent : randomEvent
{
    public Transform[] spawnPoints;
    public GameObject rhinoPrefab;
    private List<GameObject> rhinoCopies = new();

    protected override void CustomStartEvent()
    {
        for (int i = 0; i < spawnPoints.Length; i+=1) {
            rhinoCopies.Add(Instantiate(rhinoPrefab, spawnPoints[i].position, Quaternion.identity));
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