using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using System.Linq;
using static MoreMountains.Feedbacks.MMFeedbacks;

public class GameRespawn : MonoBehaviour
{
    public float threshold;
    public float time = 180;
    //public bool isLifeMode;

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
        if (GameManager.Instance.GameMode == MenuItemEnum.ScoreMode)
        {
            StartCoroutine(StartTimer());
        }
        //isLifeMode = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().GameMode == MenuItemEnum.LifeMode;
        //if (!isLifeMode)
        //{
        //    score = GameObject.FindGameObjectWithTag("Score").GetComponent<Scoresystem>();
        //}
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(time);
        EndGame("MainMenuScene");
    }

    void FixedUpdate()
    {
        if (transform.position.y < threshold && player.IsDead == false)
        {
            UpdateLife();
            UpdateKills();
            UpdateScores();
            playerStats.Deaths++;
        }
    }

    private void UpdateScores()
    {
        playerStats.Score -= 25;
        if (playerStats.bully)
        {
            playerStats.bully.GetComponent<PlayerStats>().Score += 50;
        }
    }

    private void UpdateKills()
    {
        if (playerStats.bully)
        {
            playerStats.bully.GetComponent<PlayerStats>().Kills += 1;
            if (playerStats.bully.GetComponent<PlayerStats>().Kills < 10)
            {
                Respawn();
            }
            else
            {
                EndGame("MainMenuScene");
            }
        }
    }

    private void UpdateLife()
    {
        playerStats.Lives--;
        if (playerStats.Lives > 0)
        {
            Respawn();
        }
        else
        {
            player.IsDead = true;
            GetComponent<PlayerStats>().DeadAt = System.DateTime.Now;
            EndGame("MainMenuScene");
        }
    }

    private void Respawn()
    {
        var safeZones = GameObject.FindGameObjectWithTag("Map").GetComponent<MapScript>().SafeZones;
        characterController.transform.position = safeZones.ElementAt(Random.Range(0, safeZones.Count)).transform.position;
    }

    private void EndGame(string sceneName)
    {
        GameLoop.Instance.EndGame(sceneName);
    }
}
