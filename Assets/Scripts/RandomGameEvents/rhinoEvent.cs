using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhinoEvent : randomEvent
{
    public Vector3 spawnPoint = new Vector3(0,1,3);
    public GameObject rhinoPrefab;
    private GameObject rhinoCopy;

    protected override void CustomStartEvent()
    {
        Debug.Log("Rhino event start !");
        rhinoCopy = Instantiate(rhinoPrefab, spawnPoint, Quaternion.identity);
    }

    protected override void CustomEndEvent()
    {
        Debug.Log("Rhino event stop !");
        Destroy(rhinoCopy);
    }

    void Update()
    {
        HandleEventTime();
    }
}