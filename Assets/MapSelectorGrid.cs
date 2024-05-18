using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MapSelectorGrid : MonoBehaviour
{
    public List<GameObject> Maps;
    private GameObject ActiveMap;

    // Start is called before the first frame update
    void Awake()
    {
        Maps.ForEach(map =>
        {
            map.GetComponent<Button>().onClick.AddListener(() => SelectMap(map));
        });
        SelectMap(Maps.First());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectMap(GameObject map)
    {
        foreach (var item in Maps)
        {
            item.GetComponent<MenuItemSelection>().BorderSetActive(false);
        }
        map.GetComponent<MenuItemSelection>().BorderSetActive(true);
        ActiveMap = map;
        LobbyScript.Instance.UpdateLobbyMap(ActiveMap.GetComponent<MenuItemSelection>().MenuItem);
    }
}
