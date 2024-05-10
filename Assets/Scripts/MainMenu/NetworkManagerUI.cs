using System;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private Button serverBtn;
    [SerializeField] private Button hostBtn;
    [SerializeField] private Button clientBtn;
    [SerializeField] private Button connectBtn;
    [SerializeField] private GameObject joinServerPopin;
    [SerializeField] private TMP_InputField ipField;

    private void Awake()
    {
        serverBtn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartServer();
            NetworkManager.Singleton.SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        });
        hostBtn.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
            NetworkManager.Singleton.SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        });
        clientBtn.onClick.AddListener(() =>
        {
            joinServerPopin.gameObject.SetActive(true);
        });
        connectBtn.onClick.AddListener(() =>
        {
            string ip = "127.0.0.1";
            ushort port = 7777;

            try
            {
                string[] split = ipField.text.Split(':');
                if (split.Length > 0 && split[0] != null)
                    ip = split[0];
                if (split.Length > 1 && split[1] != null)
                    port = Convert.ToUInt16(split[1]);
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }

            NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(ip, port);
            NetworkManager.Singleton.StartClient();
            NetworkManager.Singleton.SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        });
    }
}
