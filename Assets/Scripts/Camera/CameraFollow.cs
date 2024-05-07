using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 cameraOffset;
    public float smoothFactor = 0.5f;

    private GameObject player;
    private bool first = true;

    // Start is called before the first frame update
    void Start()
    {
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void Update()
    {
        getPlayer();
    }

    private void getPlayer()
    {
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player)
        {
            if (first)
            {
                cameraOffset = transform.position - player.transform.position;
                first = false;
            }

            Vector3 newPosition = player.transform.position + cameraOffset;
            transform.position = newPosition;
        }
    }
}
