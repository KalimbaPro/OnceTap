using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teamModeEvent : randomEvent
{
    protected override void CustomStartEvent()
    {
        Debug.Log("Team mode event start !");
    }

    protected override void CustomEndEvent()
    {
        Debug.Log("Team mode event stop !");
    }

    void Update()
    {
        HandleEventTime();
    }
}