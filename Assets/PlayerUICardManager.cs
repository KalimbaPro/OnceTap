using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUICardManager : MonoBehaviour
{
    //[SerializeField]
    private PlayerHudCardGroup hudCardGroup;
    private PlayerHudCard myCard;

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
        hudCardGroup = GameObject.FindGameObjectWithTag("PlayerCardsHUD").GetComponent<PlayerHudCardGroup>();
        myCard = hudCardGroup.CreateMyCard();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
