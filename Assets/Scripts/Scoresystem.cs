using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoresystem : MonoBehaviour
{
    private int point = 0;
    public TMP_Text score;
    public void AddPoint()
    {
        point += 1;
        score.text = "Player 1 score : " + point.ToString();
    }

    public void LoosePoint()
    {
        point -= 1;
        score.text = "Player 1 score : " + point.ToString();
    }
}
