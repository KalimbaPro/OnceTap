using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float recoveryTime;
    public string Username = "Username";
    public int Lives = 3;
    public int Kills = 0;
    public int Deaths = 0;
    public int Assists = 0;
    public int Score = 0;
    public bool IsStrikeReady = false;
    public DateTime? DeadAt = null;
    public GameObject bully = null;
    public GameObject target = null;
    private bool cooldownStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target && !cooldownStarted)
        {
            cooldownStarted = true;
            StartCoroutine(TargetCooldown());
        }
    }

    private IEnumerator TargetCooldown()
    {
        yield return new WaitForSeconds(6);
        target = null;
        cooldownStarted = false;
    }
}
