using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LobbyGameSelector : MonoBehaviour
{
    private void Start()
    {
        SetupPlayer();
    }

    public void SetupPlayer()
    {
        if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().GameStarted)
        {
            GetComponent<PlayerUICardManager>().enabled = true;
            GetComponent<GameRespawn>().enabled = true;
            GetComponent<LobbyPlayer>().enabled = false;
            GetComponent<ThirdPersonController>().InLobbyMode = false;
            var safeZones = GameObject.FindGameObjectWithTag("Map").GetComponent<MapScript>().SafeZones;
            transform.position = safeZones.ElementAt(Random.Range(0, safeZones.Count)).position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
