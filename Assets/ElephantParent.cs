using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElephantParent : MonoBehaviour
{
    public Animator elephantAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            elephantAnimator.SetBool("IsAttacking", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            elephantAnimator.SetBool("IsAttacking", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
