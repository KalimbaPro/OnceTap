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

    void Start()
    {
        player = GetComponent<ThirdPersonController>();
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
            transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
}
