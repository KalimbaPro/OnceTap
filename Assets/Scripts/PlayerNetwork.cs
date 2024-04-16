using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    private NetworkVariable<Vector2> direction = new NetworkVariable<Vector2>(new(), NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    [SerializeField] private Transform bulletPrefab;

    void Update()
    {
        if (!IsOwner) return;

        if (Input.GetMouseButtonDown((int)MouseButton.Left))
        {
            ShootServerRpc();
        }

        Vector2 movement = new();

        if (Input.GetKey(KeyCode.W)) movement.y = +1f;
        if (Input.GetKey(KeyCode.S)) movement.y = -1f;
        if (Input.GetKey(KeyCode.A)) movement.x = -1f;
        if (Input.GetKey(KeyCode.D)) movement.x = +1f;

        if (direction.Value != movement)
            direction.Value = movement;
    }

    private void FixedUpdate()
    {
        float moveSpeed = 3f;
        transform.position += moveSpeed * Time.deltaTime * new Vector3(direction.Value.x, 0, direction.Value.y);
    }

    [ServerRpc]
    private void ShootServerRpc()
    {
        if (!IsOwner) return;

        Transform spawnedBullet = Instantiate(bulletPrefab);
        spawnedBullet.GetComponent<NetworkObject>().Spawn();
    }
}
