using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MapSelectorGrid : MonoBehaviour
{
    private List<Button> Maps;
    private GameObject ActiveMap;

    // Start is called before the first frame update
    void Awake()
    {
        Maps = GetComponentsInChildren<Button>().ToList();
        Maps.ForEach(map =>
        {
            map.GetComponent<Button>().onClick.AddListener(() => SelectMap(map.gameObject));
        });
        SelectMap(Maps.First().gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectMap(GameObject map)
    {
        //if (NetworkManager.Singleton.IsHost)
        //{
            foreach (var item in Maps)
            {
                item.GetComponent<MenuItemSelection>().BorderSetActive(false);
            }
            map.GetComponent<MenuItemSelection>().BorderSetActive(true);
            ActiveMap = map;
            LobbyScript.Instance.UpdateLobbyMap(ActiveMap.GetComponent<MenuItemSelection>().MenuItem);
        //}
    }
}
