using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{
    public static GameLoop Instance { get { return _instance; } }
    
    private static GameLoop _instance;
    private bool endGame = false;
    private GameObject[] players;
    private float timer = 180f;
    private GameObject map;

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

        map = GameObject.FindGameObjectWithTag("Map");
    }

    public void GetAllPlayers()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    public void EndGame(string sceneName)
    {
        DisablePlayers();
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
            player.GetComponent<GameRespawn>().geometry.SetActive(false);
            player.GetComponent<GameRespawn>().skeleton.SetActive(false);
            player.GetComponent<Animator>().enabled = false;
            player.GetComponent<PlayerStats>().enabled = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GetAllPlayers();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GameMode == MenuItemEnum.ScoreMode)
        {
            map.GetComponent<MapScript>().timerText.enabled = true;
            UpdateTimer();   
        }
        CheckEndGame();
    }

    void UpdateTimer()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            map.GetComponent<MapScript>().timerText.text = "Time: " + Mathf.FloorToInt(timer / 60) + ":" + Mathf.FloorToInt(timer % 60);
        } else
        {
            endGame = true;
        }
    }

    void CheckEndGame()
    {
        switch (GameManager.Instance.GameMode)
        {
            case MenuItemEnum.LifeMode: CheckLives(); break;
            case MenuItemEnum.KillsMode: CheckKills(); break;
            case MenuItemEnum.ScoreMode: if (endGame == true) EndGame("EndOfTheGame"); break;
        }
    }

    void CheckKills()
    {
        foreach (var player in players)
        {
            if (player.GetComponent<PlayerStats>().Kills >= 10)
            {
                EndGame("EndOfTheGame");
            }
        }
    }

    void CheckLives()
    {
        var numberOfLoosers = 0;

        foreach (var player in players)
        {
            if (player.GetComponent<PlayerStats>().Lives <= 0)
            {
                numberOfLoosers++;
            }
        }

        if (numberOfLoosers == players.Length - 1)
        {
            EndGame("EndOfTheGame");
        }
    }
}
