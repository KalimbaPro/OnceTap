using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform projectionOrigin;

    public float projectionForce;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HitPlayer(other);
            Destroy(gameObject);
        }
        else if (!other.CompareTag("Weapon"))
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    void HitPlayer(Collider player)
    {
        if (gameObject.GetComponent<PlayerOwner>() != null)
        {
            player.gameObject.GetComponent<PlayerStats>().bully = gameObject.GetComponent<PlayerOwner>()?.playerOwner;
            gameObject.GetComponent<PlayerOwner>().playerOwner.GetComponent<PlayerStats>().target = player.gameObject;
        }
        else
        {
            player.gameObject.GetComponent<PlayerStats>().bully = null;
        }
        RagdollTrigger ragdollTrigger = player.GetComponent<RagdollTrigger>();
        ragdollTrigger.EnableRagdoll();
        ragdollTrigger.ApplyForce(projectionForce, projectionOrigin.transform.right, ForceMode.Impulse);
        ragdollTrigger.StartRecoveryTime();
    }
}
