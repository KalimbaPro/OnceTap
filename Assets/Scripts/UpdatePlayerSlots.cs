using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePlayerSlots : MonoBehaviour
{
    [SerializeField] private List<GameObject> slots = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LobbyRefresh());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator LobbyRefresh()
    {
        foreach(GameObject slot in slots)
        {
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(LobbyRefresh());
    }
}
