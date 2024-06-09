using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerPrefab;

    [SerializeField]
    private List<Transform> lobbySpawnPoints = new List<Transform>();

    private void Start()
    {
        PlayerInputManager.instance.playerPrefab = playerPrefab;
    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        // This is called when a player joins
        AssignDevice(playerInput);

        //foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        //{
        //    player.transform.position = lobbySpawnPoints.First().position;
        //}
        //GameObject.FindGameObjectsWithTag("Player").Last().transform.position = lobbySpawnPoints.First().position;
        //playerInput.gameObject.transform.position = lobbySpawnPoints.First().position;
    }

    private void AssignDevice(PlayerInput playerInput)
    {
        var user = playerInput.user;
        var devices = user.pairedDevices;

        // This assigns each device to a player input
        foreach (var device in devices)
        {
            if (device is Gamepad)
            {
                InputUser.PerformPairingWithDevice(device, user, InputUserPairingOptions.UnpairCurrentDevicesFromUser);
            }
        }
    }
}
