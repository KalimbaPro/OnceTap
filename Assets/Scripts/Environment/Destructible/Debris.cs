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
        yield return new WaitForSeconds(Random.Range(9f, 11f));
        originalElement.SetActive(true);
        originalElement.GetComponent<Break>().MMFPlayer.PlayFeedbacks();
        //yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(Random.Range(4f, 6f));

        foreach (MeshFilter filter in GetComponentsInChildren<MeshFilter>())
        {
            Destroy(filter.gameObject);
        }
        StartCoroutine(Respawn());
    }
}
