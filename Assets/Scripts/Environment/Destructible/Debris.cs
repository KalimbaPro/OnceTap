using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Debris : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Disappear());
    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
