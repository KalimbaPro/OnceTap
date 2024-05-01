using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightsOutEvent : MonoBehaviour
{
    public Light lightToDisable;
    public float eventTime = 30f;
    private float timer = 0f;
    private triggerRandomEvents eventHandler;

    public void Start()
    {
        eventHandler = GetComponent<triggerRandomEvents>();
        lightToDisable.enabled = false;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= eventTime) {
            lightToDisable.enabled = true;
            this.enabled = false;
            eventHandler.eventInProgress = false;
        }
    }
}
