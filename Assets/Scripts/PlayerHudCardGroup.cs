using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHudCardGroup : MonoBehaviour
{
    private const int maxPlayers = 6;
    //private List<PlayerHudCard> cards = new List<PlayerHudCard>();
    [SerializeField]
    private PlayerHudCard cardPrefab;
    ////[SerializeField]
    //private GameObject cardGroup;

    public PlayerHudCard CreateMyCard()
    {
        return Instantiate(cardPrefab, transform);
        //cards.Add(newCard);
        //return newCard;
    }

    public void DeleteMyCard(PlayerHudCard card)
    {
        Destroy(card);
        //cards.Remove(card);
    }

    // Start is called before the first frame update
    void Awake()
    {
        //cardGroup = GameObject.FindGameObjectWithTag("PlayerCardsHUD");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
