using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ClientSetIpAddress : MonoBehaviour
{
    private TMP_InputField ipField;

    private void Start()
    {
        ipField = GetComponent<TMP_InputField>();
    }

    public void SetIpAddress()
    {
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(ipField.text, 7777);
    }
}
