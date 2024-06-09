using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerPrefab;
    private void Start()
    {
        PlayerInputManager.instance.playerPrefab = playerPrefab;
    }

    private void OnPlayerJoined(PlayerInput playerInput)
    {
        // This is called when a player joins
        AssignDevice(playerInput);
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
