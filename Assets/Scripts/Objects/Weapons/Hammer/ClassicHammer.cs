using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassicHammer : MonoBehaviour
{
    public Transform projectionOrigin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HitPlayer(other);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void HitPlayer(Collider player)
    {
        player.gameObject.GetComponent<PlayerStats>().bully = gameObject.GetComponent<PlayerOwner>().playerOwner;
        gameObject.GetComponent<PlayerOwner>().playerOwner.GetComponent<PlayerStats>().target = player.gameObject;
        RagdollTrigger ragdollTrigger = player.GetComponent<RagdollTrigger>();
        float projectionForce = this.GetComponentInParent<MeleeWeaponStats>().projectionForce;
        ragdollTrigger.EnableRagdoll();
        ragdollTrigger.ApplyForce(projectionForce, projectionOrigin.transform.right, ForceMode.Impulse);
        ragdollTrigger.StartRecoveryTime();
    }
}
