using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotHammer : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform projectionOrigin;

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

    void HitPlayer(Collider player)
    {
        player.gameObject.GetComponent<PlayerStats>().bully = gameObject.GetComponent<PlayerOwner>().playerOwner;
        gameObject.GetComponent<PlayerOwner>().playerOwner.GetComponent<PlayerStats>().target = player.gameObject;
        RagdollTrigger ragdollTrigger = player.GetComponent<RagdollTrigger>();
        float projectionForce = this.GetComponentInParent<MeleeWeaponStats>().projectionForce;
        ragdollTrigger.EnableRagdoll();
        ragdollTrigger.ApplyForce(projectionForce, projectionOrigin.transform.right, ForceMode.Impulse);
        ragdollTrigger.StartRecoveryTime();
        var holder = GetComponentInParent<WeaponHolder>();
        if (holder != null)
        {
            holder.Drop();
        }
        Destroy(transform.parent.gameObject, 0.5f);
    }

}