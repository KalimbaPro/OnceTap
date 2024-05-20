using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpdatePlayerLobbyCanvas : MonoBehaviour
{
    [SerializeField] private List<GameObject> Slots = new();
    [SerializeField] private Button LeaveLobbyButton;
    [SerializeField] private Button StartButton;

    // Start is called before the first frame update
    private void OnEnable()
    {
        foreach (var slot in Slots)
        {
            slot.GetComponent<LobbyPlayerScript>().PlayerId = "";
        }
        LeaveLobbyButton.onClick.AddListener(LeaveLobby);
        StartButton.onClick.AddListener(StartGame);
        StartCoroutine(UpdatePlayerLobby());
    }

    private void OnDisable()
    {
        StopCoroutine(UpdatePlayerLobby());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator UpdatePlayerLobby()
    {
        if (LobbyScript.Instance && LobbyScript.Instance.joinedLobby != null)
        {
            int slotIndex = 0;

            foreach (Player player in LobbyScript.Instance.joinedLobby.Players)
            {
                Slots[slotIndex].GetComponent<LobbyPlayerScript>().PlayerId = player.Id;
                Slots[slotIndex].GetComponent<LobbyPlayerScript>().PlayerName.text = player.Data["PlayerName"].Value;

                slotIndex++;
            }

            for (; slotIndex < Slots.Count; slotIndex++)
            {
                Slots[slotIndex].GetComponent<LobbyPlayerScript>().PlayerId = "";
            }
        }

        yield return new WaitForSeconds(1);

        StartCoroutine(UpdatePlayerLobby());
    }

    public void LeaveLobby()
    {
        if (LobbyScript.Instance && LobbyScript.Instance.joinedLobby != null)
            LobbyScript.Instance.LeaveLobby();
        SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
    }

    public void StartGame()
    {
        //NetworkManager.Singleton.SceneManager.LoadScene("GameScene", LoadSceneMode.Single);

        if (LobbyScript.Instance && LobbyScript.Instance.joinedLobby != null)
            LobbyScript.Instance.StartGame();
    }
}
