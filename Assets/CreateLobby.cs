using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateLobby : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField playerName;
    [SerializeField]
    private TMP_InputField lobbyName;
    [SerializeField]
    private Toggle isPrivate;
    [SerializeField]
    private string lobbyScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateLobbyAndJoin()
    {
        LobbyScript.Instance.CreateLobby(playerName.text, isPrivate.isOn, lobbyName.text);

        SceneManager.LoadScene(lobbyScene, LoadSceneMode.Single);
    }
}
