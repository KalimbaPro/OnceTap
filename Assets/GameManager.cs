using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ItemSelectorGrid mapSelector;
    [SerializeField] private ItemSelectorGrid gamemodeSelector;
    [SerializeField] private GameObject lobbyContainer;
    [SerializeField] private GameObject gameContainer;

    [SerializeField] private GameObject playGroundMap;
    [SerializeField] private GameObject playGroundMap2;
    [SerializeField] private GameObject playGroundMap3;

    public bool GameStarted = false;
    public GameObject InstantiatedMap;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length < 2 )
        {
            return;
        }

        lobbyContainer.SetActive(false);
        gameContainer.SetActive(true);

        switch (mapSelector.ActiveItem.GetComponent<MenuItemSelection>().MenuItem)
        {
            case MenuItemEnum.PlaygroundMap: InstantiatedMap = Instantiate(playGroundMap); break;
            case MenuItemEnum.SecondMap: InstantiatedMap = Instantiate(playGroundMap2); break;
            case MenuItemEnum.ThirdMap: InstantiatedMap = Instantiate(playGroundMap3); break;
            default: Instantiate(playGroundMap); break;
        }

        switch (gamemodeSelector.ActiveItem.GetComponent<MenuItemSelection>().MenuItem)
        {
            case MenuItemEnum.LifeMode: ; break;
            case MenuItemEnum.TimeMode: ; break;
            case MenuItemEnum.ScoreMode: ; break;
            default: ; break;
        }

        GameStarted = true;

        foreach (var player in players)
        {
            player.GetComponent<LobbyGameSelector>().SetupPlayer();
        }
        //var players = GameObject.FindGameObjectsWithTag("Player").ToList();

        //for (int i = 0; i < new List<GameObject>(players).Count; i++)
        //{
        //    players.ElementAt(i).GetComponent<LobbyGameSelector>().SetupPlayer();
        //}
    }
}
