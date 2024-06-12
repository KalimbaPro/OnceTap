using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getStrike : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Strike"))
        {
            other.GetComponent<PlayerOwner>().playerOwner.GetComponent<PlayerStats>().target = gameObject;
            gameObject.GetComponent<PlayerStats>().bully = other.GetComponent<PlayerOwner>().playerOwner;
        }
    }
}
