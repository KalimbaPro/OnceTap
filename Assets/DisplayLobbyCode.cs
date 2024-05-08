using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayLobbyCode : MonoBehaviour
{
    [SerializeField] private TMP_Text codeField;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        StartCoroutine(UpdateLobbyCode());
    }

    private void OnDisable()
    {
        StopCoroutine(UpdateLobbyCode());
    }

    private IEnumerator UpdateLobbyCode()
    {
        if (LobbyScript.Instance != null && LobbyScript.Instance.joinedLobby != null)
        {
            codeField.text = LobbyScript.Instance.joinedLobby.LobbyCode;
        }

        yield return new WaitForSeconds(1);

        StartCoroutine(UpdateLobbyCode());
    }
}
