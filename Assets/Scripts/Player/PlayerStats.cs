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
    public bool IsStrikeReady = true;
    public DateTime? DeadAt = null;
    public GameObject bully = null;
    public GameObject target = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
