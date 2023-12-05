using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SIScores : MonoBehaviour
{
    public int score;
    private int highScore;
    public TMP_Text text;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("SpaceInvadersHighScore");
        text.text = "Score: 0";
    }

    public void IncrementScore()
    {
        score++;
        ChangeText();
        if (score >= highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("SpaceInvadersHighScore", highScore);
        }
    }

    private void ChangeText()
    {
        text.text = "Score: " + score;
    }
}
