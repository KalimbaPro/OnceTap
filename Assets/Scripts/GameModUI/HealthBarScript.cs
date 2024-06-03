using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public int HealthMax = 5;
    public int NbPlayer = 1;
    public Image[] Hearts;
    public GameObject HealthbarPrefab = null;
    [Tooltip("The health bar prefab")]
    private GameObject Healthbar;
    [Tooltip("The health bar of the player")]
    private int[] PlayersLife;

    void Start()
    {
        PlayersLife = new int[NbPlayer];

        for (int i = 0; i < NbPlayer; i++)
        {
            PlayersLife[i] = HealthMax;
            if (HealthbarPrefab != null)
            {
                Healthbar = Instantiate(HealthbarPrefab, new Vector3(0, 0, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("LifeModeUICanvas").transform);
                Healthbar.GetComponent<RectTransform>().SetLocalPositionAndRotation(new Vector3(-382, -245, 0), Quaternion.identity);
            }
            else
            {
                Debug.Log("Please stop the game and give a gameobject to GameModManager");
            }
        }
    }
    void Update()
    {
        for (int i = 0; i < Hearts.Length; i++)
        {
            if (i < HealthMax)
                Hearts[i].enabled = true;
            else
                Hearts[i].enabled = false;
        }
    }
    public void RemoveHeart()
    {
        HealthMax -= 1;
    }
}
