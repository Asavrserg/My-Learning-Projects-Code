using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static public int hScore = 1000;

    void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            hScore = PlayerPrefs.GetInt("HighScore");
        }
        
        PlayerPrefs.SetInt("HighScore", hScore);
    }

    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score: " + hScore;

        if (hScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", hScore);
        }
    }
}
