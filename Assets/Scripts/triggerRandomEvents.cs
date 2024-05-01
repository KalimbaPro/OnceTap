using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerRandomEvents : MonoBehaviour
{
    private float nextActionTime = 0.0f;
    public float tickEventTime = 1f;
    private int totalProbabilities = 0;
    private Dictionary<string, int> eventsProbabilities = new Dictionary<string, int>();

    public void TriggerEventByRandomNum()
    {
        int randomNum = Random.Range(0, totalProbabilities);
        int currentEventNum = 0;

        foreach(KeyValuePair<string, int> entry in eventsProbabilities)
        {
            currentEventNum += entry.Value;
            if (currentEventNum >= randomNum) {
                Debug.Log("Random event is " + entry.Key);
                return;
            }
        }
    }

    void Start()
    {
        eventsProbabilities["Nothing"] = 100;
        eventsProbabilities["TeamMode"] = 75;
        eventsProbabilities["LightsOut"] = 50;
        eventsProbabilities["GodMode"] = 10;
        eventsProbabilities["Rhino"] = 50;

        foreach(KeyValuePair<string, int> entry in eventsProbabilities)
        {
            totalProbabilities += entry.Value;
        }
    }

    void Update()
    {

        if (Time.time > nextActionTime ) {
            nextActionTime += tickEventTime;
            TriggerEventByRandomNum();
        }
    }
}