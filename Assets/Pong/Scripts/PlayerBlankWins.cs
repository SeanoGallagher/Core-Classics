// Author: Mason Audet      Date: 11/29/23
// I created this script to add text that displays which player won the pong game
// because no such meothd existed in the games current state.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBlankWins : MonoBehaviour
{

    public static bool playerWin;
    public Text PlayerBlankW;

    // Start is called before the first frame update
    void Start()
    {
        if(playerWin == true){
            PlayerPrefs.SetInt("PongP1HighScore", PlayerPrefs.GetInt("PongP1HighScore") + 1);
            PlayerBlankW.text = "Player 1 Wins!";
        }else{
            PlayerPrefs.SetInt("PongP2HighScore", PlayerPrefs.GetInt("PongP2HighScore") + 1);
            PlayerBlankW.text = "Player 2 Wins!";
        }
    }
}
