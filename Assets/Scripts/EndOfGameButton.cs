using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndOfGameButton : MonoBehaviour
{
    public void GoToMainMenu()
    {
        GameObject.FindGameObjectsWithTag("Player").ToList().ForEach(gameObject =>
        {
            Destroy(gameObject);
        });

        Debug.Log("test");
        Destroy(GameObject.FindGameObjectWithTag("GameManager"));
        SceneManager.LoadScene("MainMenuScene");
    }
    public void RestartGame()
    {
        GameObject.FindGameObjectsWithTag("Player").ToList().ForEach(gameObject =>
        {
            Destroy(gameObject);
        });

        Debug.Log("test1");
        Destroy(GameObject.FindGameObjectWithTag("GameManager"));
        SceneManager.LoadScene("GameScene");
    }
}
