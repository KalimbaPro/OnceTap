using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoAI : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    private GameObject playerToTarget;

    void Start ()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        playerToTarget = players[Random.Range(0, players.Length)];
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        if (agent != null && playerToTarget != null)
        {
            agent.destination = playerToTarget.transform.position;
        }
    }    
}