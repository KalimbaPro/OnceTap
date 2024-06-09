using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using System.Linq;
using static MoreMountains.Feedbacks.MMFeedbacks;

public class GameRespawn : MonoBehaviour
{
    public float threshold;
    public bool isLifeMode = true;

    private StarterAssets.ThirdPersonController player = null;
    private Scoresystem score;
    private PlayerStats playerStats = null;
    private CharacterController characterController = null;

    void Start()
    {
        GameLoop.Instance.GetAllPlayers();

        player = GetComponent<ThirdPersonController>();
        playerStats = GetComponent<PlayerStats>();
        characterController = GetComponent<CharacterController>();
        if (!isLifeMode)
        {
            score = GameObject.FindGameObjectWithTag("Score").GetComponent<Scoresystem>();
        }
    }
    void FixedUpdate()
    {
        if (transform.position.y < threshold && player.IsDead == false)
        {
            if (isLifeMode)
            {
            }
            else
            {
            }
            playerStats.Lives--;
            if (playerStats.Lives > 0) {
                var safeZones = GameObject.FindGameObjectWithTag("Map").GetComponent<MapScript>().SafeZones;
                characterController.transform.position = safeZones.ElementAt(Random.Range(0, safeZones.Count)).transform.position;
            } else {
                player.IsDead = true;
                GameLoop.Instance.GetAllPlayers();
            }
        }
    }
}
