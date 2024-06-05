using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

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
            if (playerStats.Lives != 0) {
                characterController.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            } else {
                player.IsDead = true;
                GameLoop.Instance.GetAllPlayers();
            }
        }
    }
}
