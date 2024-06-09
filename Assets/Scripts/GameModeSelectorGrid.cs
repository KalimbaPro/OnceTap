using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class GameModeSelectorGrid : NetworkBehaviour
{
    private List<Button> GameModes;
    private GameObject ActiveMap;

    // Start is called before the first frame update
    void Awake()
    {
        GameModes = GetComponentsInChildren<Button>().ToList();
        GameModes.ForEach(map =>
        {
            map.GetComponent<Button>().onClick.AddListener(() => SelectMap(map.gameObject, true));
        });
        SelectMap(GameModes.First().gameObject, true);

        StartCoroutine(UpdateMenuItem());
    }

    // Update is called once per frame
    private IEnumerator UpdateMenuItem()
    {
        if (LobbyScript.Instance != null && LobbyScript.Instance.joinedLobby != null)
        {
            //var newGameMode = GameModes.Find(map => map.GetComponent<MenuItemSelection>().MenuItem == LobbyScript.Instance.joinedLobby.Data["GameMode"].Value);
            //SelectMap(newGameMode.gameObject, false);
        }

        yield return new WaitForSeconds(1f);

        StartCoroutine(UpdateMenuItem());
    }

    public void SelectMap(GameObject gameMode, bool sendToNetwork)
    {
        if (LobbyScript.Instance == null)
        {
            return;
        }

        foreach (var item in GameModes)
        {
            item.GetComponent<MenuItemSelection>().BorderSetActive(false);
        }
        gameMode.GetComponent<MenuItemSelection>().BorderSetActive(true);
        ActiveMap = gameMode;

        if (sendToNetwork)
        {
            //LobbyScript.Instance.UpdateLobbyGamemode(ActiveMap.GetComponent<MenuItemSelection>().MenuItem);
        }
    }
}
