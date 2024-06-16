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
    public GameObject geometry;
    public GameObject skeleton;

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
        var safeZones = GameObject.FindGameObjectWithTag("Map").GetComponent<MapScript>().SafeZones;
        characterController.transform.position = safeZones.ElementAt(Random.Range(0, safeZones.Count)).transform.position;
        //if (GameManager.Instance.GameMode == MenuItemEnum.ScoreMode)
        //{
        //    StartCoroutine(StartTimer());
        //}
        //isLifeMode = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().GameMode == MenuItemEnum.LifeMode;
        //if (!isLifeMode)
        //{
        //    score = GameObject.FindGameObjectWithTag("Score").GetComponent<Scoresystem>();
        //}
    }

    //private IEnumerator StartTimer()
    //{
    //    yield return new WaitForSeconds(time);
    //    EndGame("EndOfTheGame");
    //}

    void FixedUpdate()
    {
        if (player.IsDead)
        {
            return;
        }

        if (transform.position.y < threshold)
        {
            UpdateScores();
            UpdateLives();
            UpdateKills();
            playerStats.Deaths++;
            CheckRespawn();
        }
    }

    public void CheckRespawn()
    {
        switch (GameManager.Instance.GameMode)
        {
            case MenuItemEnum.LifeMode: CheckLives(); break;
            default: Respawn(); break;
        }
    }

    public void UpdateScores()
    {
        playerStats.Score -= 25;
        if (playerStats.bully)
        {
            playerStats.bully.GetComponent<PlayerStats>().Score += 50;
        }
    }

    public void UpdateKills()
    {
        if (playerStats.bully)
        {
            playerStats.bully.GetComponent<PlayerStats>().Kills += 1;
        }
    }

    private void UpdateLives()
    {
        playerStats.Lives--;
    }

    private void CheckLives()
    {
        if (playerStats.Lives > 0)
        {
            Respawn();
        }
        else
        {
            Respawn();
            geometry.SetActive(false);
            skeleton.SetActive(false);
            gameObject.GetComponent<ThirdPersonController>().enabled = false;
            player.IsDead = true;
            GetComponent<PlayerStats>().DeadAt = System.DateTime.Now;
        }
    }

    private void Respawn()
    {
        if (playerStats.bully)
        {
            playerStats.bully.GetComponent<PlayerStats>().target = null;
            playerStats.bully = null;
        }
        var safeZones = GameObject.FindGameObjectWithTag("Map").GetComponent<MapScript>().SafeZones;
        characterController.transform.position = safeZones.ElementAt(Random.Range(0, safeZones.Count)).transform.position;
    }
}
