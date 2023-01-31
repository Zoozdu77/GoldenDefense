using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Buttons : MonoBehaviour
{
    public void Continue()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        GeneralVars.OverlayIsActive = false;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void quit()
    {
        Application.Quit();
    }
}
