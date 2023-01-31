using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Buttons : MonoBehaviour
{
    public AudioClip[] SoundEffect;
    public AudioSource SoundSource;

    public void Continue()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        GeneralVars.OverlayIsActive = false;
    }

    public void StartGame()
    {
        SoundSource.PlayOneShot(SoundEffect[0]);
        DontDestroyOnLoad(gameObject);
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
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
