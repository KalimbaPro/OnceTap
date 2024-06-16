using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelectorGrid : MonoBehaviour
{
    private List<Button> Items;
    public GameObject ActiveItem;

    // Start is called before the first frame update
    void Awake()
    {
        Items = GetComponentsInChildren<Button>().ToList();
        Items.ForEach(map =>
        {
            map.GetComponent<Button>().onClick.AddListener(() => SelectMap(map.gameObject));
        });
        SelectMap(Items.First().gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectMap(GameObject map)
    {
        //if (NetworkManager.Singleton.IsHost)
        //{
            foreach (var item in Items)
            {
                item.GetComponent<MenuItemSelection>().BorderSetActive(false);
            }
            map.GetComponent<MenuItemSelection>().BorderSetActive(true);
            ActiveItem = map;
            //LobbyScript.Instance.UpdateLobbyMap(ActiveMap.GetComponent<MenuItemSelection>().MenuItem);
        //}
    }
}
