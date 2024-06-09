using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Debris : MonoBehaviour
{
    public GameObject originalElement;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Disappear());
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(10);
        originalElement.SetActive(true);
        Destroy(gameObject);
    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(5);

        foreach (MeshFilter filter in GetComponentsInChildren<MeshFilter>())
        {
            Destroy(filter.gameObject);
        }
        StartCoroutine(Respawn());
    }
}