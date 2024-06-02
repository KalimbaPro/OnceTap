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
        float projectionForce = this.GetComponent<MeleeWeaponStats>().projectionForce;
        player.GetComponent<RagdollTrigger>().EnableRagdoll();
        player.GetComponent<Rigidbody>().AddForce(projectionOrigin.transform.forward * projectionForce, ForceMode.Impulse);
    }
}
