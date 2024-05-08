using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public int health = 5;

    public Image[] hearts;

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }
    }
    public void RemoveHeart()
    {
        health -= 1;
    }
}
