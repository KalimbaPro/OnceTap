using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> SkinList = new List<GameObject>();
    public static Dictionary<int, GameObject> SkinDictionary = new Dictionary<int, GameObject>();

    private void Start()
    {
        for (int i = 0; i < SkinList.Count; i++)
        {
            SkinList.ElementAt(i).GetComponent<SkinData>().SkinId = i.ToString();
            SkinDictionary.Add(i, SkinList.ElementAt(i));
        }
    }
}
