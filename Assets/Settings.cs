using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    private static Settings _instance;

    public static Settings Instance { get { return _instance; } }

    public float musicVolume = 1.0f;
    public float soundVolume = 1.0f;
    public bool fullscreenMode = false;

    //public bool preparedLobbyIsHost = true;
    //public bool preparedLobbyIsPrivate = true;
    //public string preparedLobbyPlayerName = "Player";
    //public string preparedLobbyName = "Lobby";

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

    public void SetScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
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
