using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndOfGameButton : MonoBehaviour
{
    public void GoToMainMenu()
    {
        Debug.Log("test");
        SceneManager.LoadScene("MainMenuScene");
    }
    public void RestartGame()
    {
        Debug.Log("test1");
        SceneManager.LoadScene("GameScene");
    }
}
