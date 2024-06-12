using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class randomEvent : MonoBehaviour
{
    private triggerRandomEvents eventHandler;
    private float timer = 0f;
    public float eventTime = 30f;
    public string eventAnnoucementString;
    private float textTimeToAppear = 2f;

    private void Awake()
    {
        eventHandler = GetComponent<triggerRandomEvents>();
    }

    private void HandleAnnouncementAnimation()
    {
        if (timer <= 0.5) {
            eventHandler.eventAnnouncement.fontSize = timer * 72;
        }
    }

    private void DisplayAnnouncement()
    {
        eventHandler.eventAnnouncement.text = eventAnnoucementString;
        eventHandler.eventAnnouncement.CrossFadeAlpha(1, 0.25f, false);
    }
    
    public void StartEvent()
    {
        this.enabled = true;
        timer = 0f;
        eventHandler.eventAnnouncement.fontSize = 0;
        DisplayAnnouncement();
        CustomStartEvent();
        eventHandler.eventInProgress = true;
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
        if (timer >= textTimeToAppear)
            eventHandler.eventAnnouncement.CrossFadeAlpha(0, 0.25f, false);
        if (timer >= eventTime)
            EndEvent();
        HandleAnnouncementAnimation();
    }
}