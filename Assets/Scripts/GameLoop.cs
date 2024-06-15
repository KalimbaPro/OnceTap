using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{
    private static GameLoop _instance;
    public static GameLoop Instance { get { return _instance; } }
    private GameObject[] players;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void GetAllPlayers()
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        Debug.Log("Number of Players found: " + players.Length);
        if (players.Length == 1) {
            Debug.Log("End Game");
        }
    }

    public void EndGame(string sceneName)
    {
        DisablePlayers();
        //players = null;
        GameManager.Instance.Reset();
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }

    private void DisablePlayers()
    {
        foreach (var player in players)
        {
            MonoBehaviour[] components = player.GetComponents<MonoBehaviour>();

            foreach (MonoBehaviour component in components)
            {
                component.enabled = false;
            }

            player.GetComponent<PlayerStats>().enabled = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
