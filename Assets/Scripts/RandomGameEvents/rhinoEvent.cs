using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhinoEvent : randomEvent
{
    protected override void CustomStartEvent()
    {
        Debug.Log("Rhino event start !");
    }

    protected override void CustomEndEvent()
    {
        Debug.Log("Rhino event stop !");
    }

    void Update()
    {
        HandleEventTime();
    }
}