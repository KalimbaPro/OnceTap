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
        RagdollTrigger ragdollTrigger = player.GetComponent<RagdollTrigger>();
        float projectionForce = this.GetComponentInParent<MeleeWeaponStats>().projectionForce;
        ragdollTrigger.EnableRagdoll();
        ragdollTrigger.ApplyForce(projectionForce, projectionOrigin.transform.right, ForceMode.Impulse);
        ragdollTrigger.StartRecoveryTime();
        GetComponentInParent<WeaponHolder>().Drop();
        Destroy(transform.parent.gameObject, 0.5f);
    }

}