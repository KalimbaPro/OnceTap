using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUICardManager : MonoBehaviour
{
    //[SerializeField]
    private PlayerHudCardGroup hudCardGroup;
    private PlayerHudCard myCard;
    private PlayerStats stats;

    private void Awake()
    {
    }

    private void OnDestroy()
    {
        hudCardGroup.DeleteMyCard(myCard);
    }

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<PlayerStats>();
        hudCardGroup = GameObject.FindGameObjectWithTag("PlayerCardsHUD").GetComponent<PlayerHudCardGroup>();
        myCard = hudCardGroup.CreateMyCard();
        myCard.Username.text = stats.Username;
    }

    // Update is called once per frame
    void Update()
    {   
        myCard.livesText.text = stats.Lives.ToString();
        myCard.killsText.text = stats.Kills.ToString();
        myCard.scoreText.text = stats.Score.ToString();
    }
}
