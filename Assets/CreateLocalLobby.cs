using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateLocalLobby : MonoBehaviour
{
    [SerializeField]
    private string lobbyScene = "GameScene";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(lobbyScene, LoadSceneMode.Single);
    }
}
