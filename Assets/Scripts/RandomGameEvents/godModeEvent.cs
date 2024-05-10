using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class godModeEvent : randomEvent
{
    protected override void CustomStartEvent()
    {
        Debug.Log("god mode event start !");
    }

    protected override void CustomEndEvent()
    {
        Debug.Log("god mode event stop !");
    }

    void Update()
    {
        HandleEventTime();
    }
}
