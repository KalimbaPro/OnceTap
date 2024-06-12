using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRhinoAttack : MonoBehaviour
{
    public float ejectionSpeed = 16.0f;
    public float gravity = 20.0f;
    private UnityEngine.AI.NavMeshAgent agent;
    private CharacterController playerToEject;
    private bool isEjectingPlayer = false;
    private bool isPlayerEjected = false;
    private Vector3 _lastPosition;

    void Start ()
    {
        agent = transform.parent.gameObject.GetComponentInParent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update ()
    {
        Vector3 ejectionVector = new Vector3(0, ejectionSpeed, 0);

        if (isPlayerEjected) {
            playerToEject.Move(ejectionVector * Time.deltaTime);
            if (playerToEject.transform.position.y < _lastPosition.y)
                isPlayerEjected = false;
        }
        if (playerToEject)
            _lastPosition = playerToEject.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isEjectingPlayer && other.CompareTag("Player"))
        {
            isEjectingPlayer = true;
            playerToEject = other.GetComponent<CharacterController>();
            agent.isStopped = true;
            Invoke("EjectPlayer", 1);
        }
    }

    public void EjectPlayer()
    {
        isPlayerEjected = true;
        agent.isStopped = false;
        isEjectingPlayer = false;
    }
}
