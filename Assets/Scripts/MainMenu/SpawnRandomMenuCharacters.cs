using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnRandomMenuCharacters : MonoBehaviour
{
    public List<Transform> slots = new();
    public List<GameObject> slotCandidates = new();

    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> tempCandidates = new(slotCandidates);

        foreach (var slot in slots)
        {
            var canditate = tempCandidates.ElementAt(Random.Range(0, tempCandidates.Count - 1));
            Instantiate(canditate, slot);
            tempCandidates.Remove(canditate);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
