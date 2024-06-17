using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class triggerRandomEvents : MonoBehaviour
{
    private float nextActionTime = 0.0f;
    public float tickEventTime = 1f;
    public bool eventInProgress = false;
    public TextMeshProUGUI eventAnnouncement;
    private int totalProbabilities = 0;
    private Dictionary<string, int> eventsProbabilities = new Dictionary<string, int>();
    private randomEvent Event;

    public void TriggerEventByRandomNum()
    {
        int randomNum = Random.Range(0, totalProbabilities);
        int currentEventNum = 0;

        foreach(KeyValuePair<string, int> entry in eventsProbabilities)
        {
            currentEventNum += entry.Value;
            if (currentEventNum >= randomNum) {
                Event = GetComponent<DroneEvent>();
                if (entry.Key == "TeamMode")
                    Event = GetComponent<teamModeEvent>();
                if (entry.Key == "LightsOut")
                    Event = GetComponent<lightsOutEvent>();
                if (entry.Key == "GodMode")
                    Event = GetComponent<godModeEvent>();
                if (entry.Key == "Rhino")
                    Event = GetComponent<rhinoEvent>();
                if (entry.Key == "Drone")
                    Event = GetComponent<DroneEvent>();
                Event.StartEvent();
                return;
            }
        }
    }

    void Start()
    {
        StartCoroutine(EventCooldown());
    }

    private IEnumerator EventCooldown()
    {
        yield return new WaitForSeconds(10);
        StartEventSystem();
    }

    private void StartEventSystem()
    {
        eventsProbabilities.Add("Nothing", 100);
        //eventsProbabilities.Add("TeamMode", 50);
        eventsProbabilities.Add("LightsOut", 35);
        //eventsProbabilities.Add("GodMode", 15);
        eventsProbabilities.Add("Rhino", 20);
        eventsProbabilities.Add("Drone", 50);

        foreach (KeyValuePair<string, int> entry in eventsProbabilities)
        {
            totalProbabilities += entry.Value;
        }
    }

    void Update()
    {

        if (!eventInProgress && Time.time > nextActionTime ) {
            nextActionTime += tickEventTime;
            TriggerEventByRandomNum();
        }
    }
}