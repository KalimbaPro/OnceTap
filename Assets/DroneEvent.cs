using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DroneEvent : randomEvent
{
    public List<Transform> SpawnPoints;
    public GameObject DronePrefab;
    private GameObject Drone;

    protected override void CustomEndEvent()
    {
        //throw new System.NotImplementedException();
    }

    protected override void CustomStartEvent()
    {
        var randomSpawnPoint = SpawnPoints.ElementAt(Random.Range(0, SpawnPoints.Count));
        Drone = Instantiate(DronePrefab);
        Drone.transform.position = randomSpawnPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        HandleEventTime();
    }
}
