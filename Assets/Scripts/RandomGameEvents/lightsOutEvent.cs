using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class lightsOutEvent : randomEvent
{
    public List<Light> lightsToDisable;

    public void ToggleLights(bool alight)
    {
        for (int i = 0; i < lightsToDisable.Count; i++) {
            lightsToDisable[i].enabled = alight;
        }
    }

    protected override void CustomStartEvent()
    {
        ToggleLights(false);
    }

    protected override void CustomEndEvent()
    {
        ToggleLights(true);
    }


    void Update()
    {
        lightsToDisable = GameObject.FindObjectsByType<Light>(FindObjectsSortMode.None).ToList();
        HandleEventTime();
    }
}
