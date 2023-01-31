    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHighScore : MonoBehaviour
{
    public Text HighScore;

    private void Start()
    {
        if (PlayerPrefs.GetInt("High Score") != 0)
        {
            HighScore.text = "High score : " + PlayerPrefs.GetInt("High Score").ToString();
        } else
        {
            HighScore.text = null;
        }
    }
}
