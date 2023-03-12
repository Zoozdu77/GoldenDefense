using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Buttons : MonoBehaviour
{
    public AudioClip[] SoundEffect;
    public AudioSource SoundSource;

    public void StartGame()
    {
        SoundSource.clip = SoundEffect[0];
        SoundSource.Play();
        DontDestroyOnLoad(gameObject);
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
