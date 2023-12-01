using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int scoreToReach;
    private int player1Score = 0;
    private int player2Score = 0;

    public TextMeshProUGUI scoreP1;
    public TextMeshProUGUI scoreP2;

    [SerializeField] private string gameOverSceneName = "Pong Game Over";

    public void Player1Goal()
    {
        player1Score++;
        scoreP1.text = player1Score.ToString();
        CheckScore();
    }

    public void Player2Goal()
    {
        player2Score++;
        scoreP2.text = player2Score.ToString();
        CheckScore();
    }
    private void CheckScore()
    {
        // Mason Audet altered the code on 11/29/23 to add in the global score saving elements

        if(player1Score == scoreToReach)
        {
            PlayerBlankWins.playerWin = true;
            SceneManager.LoadScene(gameOverSceneName);
        }

        if(player2Score == scoreToReach)
        {
            PlayerBlankWins.playerWin = false;
            SceneManager.LoadScene(gameOverSceneName);
        }
    }


}
