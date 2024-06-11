using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHudCard : MonoBehaviour
{
    public TMP_Text Username;
    public RGBFade StrikeBox;
    public GameObject livesBox;
    public GameObject deathsBox;
    public TMP_Text livesText;
    public TMP_Text deathsText;
    public TMP_Text killsText;
    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        bool isLifeMode = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().GameMode == MenuItemEnum.LifeMode;
        livesBox.SetActive(isLifeMode);
        deathsBox.SetActive(!isLifeMode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
