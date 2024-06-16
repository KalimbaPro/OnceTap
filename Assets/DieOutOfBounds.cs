using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.Lobbies.Models;
using UnityEngine;

public class DieOutOfBounds : MonoBehaviour
{
    private MapScript map = null;
    private PlayerOwner playerOwner = null;

    // Start is called before the first frame update
    void Start()
    {
        playerOwner = GetComponent<PlayerOwner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (map == null)
        {
            map = GameObject.FindGameObjectWithTag("Map")?.GetComponent<MapScript>();
        }
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.GameStarted)
        {
            return;
        }

        if (playerOwner.playerOwner.GetComponent<ThirdPersonController>().IsDead)
        {
            return;
        }

        if (map != null && map.GetComponent<MapScript>())
        {
            if (!map.Boundaries.GetComponent<BoxCollider>().bounds.Contains(transform.position))
            {
                playerOwner.playerOwner.GetComponent<RagdollTrigger>().DisableRagdoll();
                playerOwner.playerOwner.GetComponent<GameRespawn>().UpdateScores();
                playerOwner.playerOwner.GetComponent<GameRespawn>().UpdateLife();
                playerOwner.playerOwner.GetComponent<GameRespawn>().UpdateKills();
                playerOwner.playerOwner.GetComponent<PlayerStats>().Deaths++;
                playerOwner.playerOwner.GetComponent<GameRespawn>().CheckRespawn();
            }
        }
    }
}
