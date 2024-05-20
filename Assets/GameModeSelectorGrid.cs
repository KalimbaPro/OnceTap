using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameModeSelectorGrid : MonoBehaviour
{
    public List<GameObject> GameModes;
    private GameObject ActiveMap;

    // Start is called before the first frame update
    void Awake()
    {
        GameModes.ForEach(map =>
        {
            map.GetComponent<Button>().onClick.AddListener(() => SelectMap(map));
        });
        SelectMap(GameModes.First());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelectMap(GameObject gameMode)
    {
        foreach (var item in GameModes)
        {
            item.GetComponent<MenuItemSelection>().BorderSetActive(false);
        }
        gameMode.GetComponent<MenuItemSelection>().BorderSetActive(true);
        ActiveMap = gameMode;
        LobbyScript.Instance.UpdateLobbyGamemode(ActiveMap.GetComponent<MenuItemSelection>().MenuItem);
    }
}
