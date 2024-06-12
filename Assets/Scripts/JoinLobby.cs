//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;

//public class JoinLobby : MonoBehaviour
//{
//    [SerializeField]
//    private TMP_InputField playerName;
//    [SerializeField]
//    private TMP_InputField lobbyCode;
//    [SerializeField]
//    private string lobbyScene;

//    public void JoinLobbyAndConnect()
//    {
//        Debug.Log("Joining code " + lobbyCode.text);
//        LobbyScript.Instance.JoinLobbyByCode(lobbyCode.text, playerName.text);

//        SceneManager.LoadScene(lobbyScene, LoadSceneMode.Single);
//    }
//}
