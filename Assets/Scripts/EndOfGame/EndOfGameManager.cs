using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public MenuItemEnum GameMode;
    public PlayerStats[] playerStats;
    public GameObject LastManScoreBoard;
    public GameObject KillScoreBoard;
    public GameObject ScoreModeScoreBoard;
    private GameObject entryContainer;
    private Transform entryTemplate;

    private void Awake()
    {
        if (GameMode == MenuItemEnum.KillsMode)
        {
            KillScoreBoard.SetActive(true);
            Array.Sort(playerStats, delegate (PlayerStats x, PlayerStats y) { return y.Kills.CompareTo(x.Kills); });
            entryContainer = GameObject.Find("KMScoreboardEntryContainer");
            entryTemplate = entryContainer.GameObject().transform.Find("KMScoreBoardEntryTemplate");
        }
        else if (GameMode == MenuItemEnum.ScoreMode)
        {
            ScoreModeScoreBoard.SetActive(true);
            Array.Sort(playerStats, delegate (PlayerStats x, PlayerStats y) { return y.Score.CompareTo(x.Score); });
            entryContainer = GameObject.Find("SMScoreboardEntryContainer");
            entryTemplate = entryContainer.GameObject().transform.Find("SMScoreBoardEntryTemplate");
        }
        else
        {
            LastManScoreBoard.SetActive(true);
            Array.Sort(playerStats, delegate (PlayerStats x, PlayerStats y) { return y.Lives.CompareTo(x.Lives); });
            entryContainer = GameObject.Find("LMScoreBoardEntryContainer");
            entryTemplate = entryContainer.GameObject().transform.Find("LMScoreBoardEntryTemplate");
        }
        entryTemplate.gameObject.SetActive(false);
        float templateHeight = 30f;
        int ranking = 1;
        for (int i = 0; i < playerStats.Length; i++)
        {
            ranking = i + 1;
            Transform entryTransform = Instantiate(entryTemplate, entryContainer.transform);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);

            switch (GameMode)
            {
                case MenuItemEnum.LifeMode:
                    LifeModeBehaviour(entryTransform, playerStats[i], ranking);
                    break;
                case MenuItemEnum.KillsMode:
                    KillModeBehaviour(entryTransform, playerStats[i], ranking);
                    break;
                case MenuItemEnum.ScoreMode:
                    ScoreModeBehaviour(entryTransform, playerStats[i], ranking);
                    break;
                default:
                    LifeModeBehaviour(entryTransform, playerStats[i], ranking);
                    break;
            }
        }
    }

    private void LifeModeBehaviour(Transform entryTransform, PlayerStats playerStat, int ranking)
    {
        entryTransform.Find("Number").GetComponent<TMP_Text>().text = ranking.ToString();
        entryTransform.Find("Name").GetComponent<TMP_Text>().text = playerStat.Username;
        entryTransform.Find("Time").GetComponent<TMP_Text>().text = "Define later";
        entryTransform.Find("Kill").GetComponent<TMP_Text>().text = playerStat.Kills.ToString();
        entryTransform.Find("Death").GetComponent<TMP_Text>().text = playerStat.Deaths.ToString();
        entryTransform.Find("Assist").GetComponent<TMP_Text>().text = playerStat.Assists.ToString();
    }
    private void KillModeBehaviour(Transform entryTransform, PlayerStats playerStat, int ranking)
    {
        entryTransform.Find("Number").GetComponent<TMP_Text>().text = ranking.ToString();
        entryTransform.Find("Name").GetComponent<TMP_Text>().text = playerStat.Username;
        entryTransform.Find("Kill").GetComponent<TMP_Text>().text = playerStat.Kills.ToString();
        entryTransform.Find("Death").GetComponent<TMP_Text>().text = playerStat.Deaths.ToString();
        entryTransform.Find("Assist").GetComponent<TMP_Text>().text = playerStat.Assists.ToString();
    }
    private void ScoreModeBehaviour(Transform entryTransform, PlayerStats playerStat, int ranking)
    {
        entryTransform.Find("Number").GetComponent<TMP_Text>().text = ranking.ToString();
        entryTransform.Find("Name").GetComponent<TMP_Text>().text = playerStat.Username;
        entryTransform.Find("Score").GetComponent<TMP_Text>().text = playerStat.Score.ToString();
        entryTransform.Find("Kill").GetComponent<TMP_Text>().text = playerStat.Kills.ToString();
        entryTransform.Find("Death").GetComponent<TMP_Text>().text = playerStat.Deaths.ToString();
        entryTransform.Find("Assist").GetComponent<TMP_Text>().text = playerStat.Assists.ToString();
    }
}
