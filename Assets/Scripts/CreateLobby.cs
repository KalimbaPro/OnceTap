//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;

//public class CreateLobby : MonoBehaviour
//{
//    [SerializeField]
//    private GameObject loadingScreen;
//    [SerializeField]
//    private TMP_InputField playerName;
//    [SerializeField]
//    private TMP_InputField lobbyName;
//    [SerializeField]
//    private Toggle isPrivate;
//    [SerializeField]
//    private string lobbyScene;

//    private bool creatingLobby = false;

//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (creatingLobby && LobbyScript.Instance.hostLobby != null)
//        {
//            SceneManager.LoadScene(lobbyScene, LoadSceneMode.Single);
//        }
//    }

//    public void CreateLobbyAndJoin()
//    {
//        loadingScreen.SetActive(true);
//        creatingLobby = true;
//        LobbyScript.Instance.CreateLobby(playerName.text, isPrivate.isOn, lobbyName.text);
//    }
//}
