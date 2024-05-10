using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyPlayerScript : MonoBehaviour
{
    public string PlayerId;
    public Image PlayerIcon;
    public TMP_Text PlayerName;
    public Button MakeHostButton;
    public Button KickButton;

    // Start is called before the first frame update
    void Start()
    {
        MakeHostButton.onClick.AddListener(OnClickMakeHost);
        KickButton.onClick.AddListener(OnClickKickPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        var hasPlayer = PlayerId.Length != 0;

        MakeHostButton.gameObject.SetActive(hasPlayer);
        KickButton.gameObject.SetActive(hasPlayer);
        PlayerIcon.gameObject.SetActive(hasPlayer);
        PlayerName.gameObject.SetActive(hasPlayer);
    }

    void OnClickMakeHost()
    {
        Debug.Log("Making player " +  PlayerId + " host");

        LobbyScript.Instance.SetNewHost(PlayerId);
    }

    void OnClickKickPlayer()
    {
        Debug.Log("Kicking player " +  PlayerId);

        LobbyScript.Instance.KickPlayer(PlayerId);
    }
}
