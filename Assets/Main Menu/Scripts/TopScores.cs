// Author: Mason Audet      Date: 11/29/23
//
// This is a script that displays the kept high scores for each of the games in the arcade. They are only updated
// at the start of the scene because the values of the scores shouldn't change unless the player leaves the main menu
// P1 for pong is left side player
// P2 for pong is right side player
// P1 for TTT is X
// P2 for TTT is O

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopScores : MonoBehaviour
{

    // These varaibles should be very self explanatory. They create an instance of a text box that we
    // reference a text object to.

    public Text SnakeHighScoreText;
    public Text TicTacToeP1HighScoreText;
    public Text TicTacToeP2HighScoreText;
    public Text PongP1HighScoreText;
    public Text PongP2HighScoreText;
    public Text SpaceInvadersHighScoreText;
    public Text DonkeyKongHighScoreText;
    public Text PixelParryHighScoreText;
    public Text FlappyBirdHighScoreText;

    // Start is called before the first frame update
    void Start()
    {
        //Updates the high score text for Snake
        SnakeHighScoreText.text = "High Score: " + PlayerPrefs.GetInt("SnakeHighScore");
        //Updates the win scores for TTT
        TicTacToeP1HighScoreText.text = "X Wins: " + PlayerPrefs.GetInt("TicTacToeP1HighScore");
        TicTacToeP2HighScoreText.text = "O Wins: " + PlayerPrefs.GetInt("TicTacToeP2HighScore");
        //Updates the win scores for each Pong player
        PongP1HighScoreText.text = "P1: " + PlayerPrefs.GetInt("PongP1HighScore");
        PongP2HighScoreText.text = "P2: " + PlayerPrefs.GetInt("PongP2HighScore");
        //Updates the high score for the Space Invaders game
        SpaceInvadersHighScoreText.text = "High Score: " + PlayerPrefs.GetInt("SpaceInvadersHighScore");
        //Updates the high score for the Donkey Kong game
        DonkeyKongHighScoreText.text = "Total Wins: " + PlayerPrefs.GetInt("DonkeyKongHighScore");
        //Updates player win count for the Pixel Parry game
        PixelParryHighScoreText.text = "Total Player Wins: " + PlayerPrefs.GetInt("PixelParryHighScore");
        //Updates the high score for Flappy Bird
        FlappyBirdHighScoreText.text = "High Score: " + PlayerPrefs.GetInt("FlappyBirdHighScore");

        
    }
}
