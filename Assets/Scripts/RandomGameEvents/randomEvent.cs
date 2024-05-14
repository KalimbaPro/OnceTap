using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class randomEvent : MonoBehaviour
{
    private triggerRandomEvents eventHandler;
    private float timer = 0f;
    public float eventTime = 30f;
    protected TextMeshProUGUI eventAnnouncerText;
    public string eventTitle = "Event basic starting !";
    
    public void StartEvent()
    {
        this.enabled = true;
        CustomStartEvent();
        timer = 0f;
        eventHandler = GetComponent<triggerRandomEvents>();
        eventHandler.eventInProgress = true;
        eventHandler.eventAnnouncerText.text = eventTitle;
    }

    protected abstract void CustomStartEvent();
    protected abstract void CustomEndEvent();

    private void EndEvent()
    {
        CustomEndEvent();
        this.enabled = false;
        eventHandler.eventInProgress = false;
    }

    protected void HandleEventTime()
    {
        timer += Time.deltaTime;
        if (timer >= eventTime)
            EndEvent();
    }
}