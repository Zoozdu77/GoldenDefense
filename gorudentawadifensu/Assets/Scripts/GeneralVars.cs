using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GeneralVars : MonoBehaviour
{
    public GameObject Pause;
    public GameObject[] Hearts;
    public Text MoneyText;
    public Text scoreText;
    public Image SpeedButton;
    public Sprite Speedfast;
    public Sprite Speedslow;

    public static bool OverlayIsActive = false;
    public static int Money = 3000;
    public static int score;
    public static int throneHealth = 3;
    public static int TimeSpeed = 1;
    public static float BonusHp;
    public static int ennemyNumber;

    private void Start()
    {
        Money = 3000;
        score = 0;
        TimeSpeed = 1;
        throneHealth = 3;
        GeneralVars.OverlayIsActive = false;
    }

    private void Update()
    {
        MoneyText.text = "Gold : " + Money.ToString();
        scoreText.text = "Score : " + score.ToString();
        BonusHp = Time.time / 20;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseTheGame();
        }

        for (int i = 0; i < Hearts.Length; i++)
        {
            if (i >= throneHealth)
            {
                Hearts[i].SetActive(true);
            }
        }

        if (throneHealth <= 0)
        {
            if (PlayerPrefs.GetInt("HighScore") < score)
            {
            PlayerPrefs.SetInt("High Score", score);
            }
            SceneManager.LoadScene(2);
        }

        TimeUse();
    }

    #region(fonctions)
    public void PauseTheGame()
    {
        Time.timeScale = 0f;
        GeneralVars.OverlayIsActive = true;
        Pause.SetActive(true);
    }

    public void TimeControl()
    {
        if (TimeSpeed > 1)
        {
            TimeSpeed = 1;
        } else
        {
            TimeSpeed = 3;
        }
    }

    public void TimeUse()
    {
        if (Time.timeScale < TimeSpeed || Time.timeScale > TimeSpeed)
        {
            if (Time.timeScale != 0)
            {
                Time.timeScale = TimeSpeed;
            }
        }

        if (TimeSpeed > 1)
        {
            SpeedButton.sprite = Speedfast;
        } else
        {
            SpeedButton.sprite = Speedslow;
        }
    }
    #endregion
}
