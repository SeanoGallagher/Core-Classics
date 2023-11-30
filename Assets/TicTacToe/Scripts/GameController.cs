using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //declaring the variables 

    //Game Setup 
    public int whoseTurn; // 0 = X and 1 = O
    public int turnCount; // Counting the number of turns played
    public GameObject[] turnIcons; //displaying who's turn it is 
    public Sprite[] playerIcons; //0 = x icons and 1 = o icons
    public Button[] tictactoeSpaces; //playable spaces for the game 
    public int[] markedSpaces; //shows which spaces was marked by which player 

    public Text winnerText; //Holds text component of the winner text 
    public GameObject[] winningLine; // holds line component
    public GameObject winnerPanel;

    public int xPlayersScore; 
    public int oPlayersScore; 
    public Text xPlayersScoreText ; 
    public Text oPlayersScoreText;

    public Button xPlayersButton;
    public Button  oPlayersButton ; 

    public GameObject catImage; //If its a tie between the players 


    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
        
    }


    void GameSetup()
    {
        whoseTurn = 0 ; 
        turnCount= 0 ; 
        
        turnIcons[0].SetActive(true);
        turnIcons[1].SetActive(false);
        for(int i = 0 ; i <tictactoeSpaces.Length; i++)
        {
            tictactoeSpaces[i].interactable = true; 
            tictactoeSpaces[i].GetComponent<Image>().sprite=null; // S
        }
        for(int i = 0 ; i <markedSpaces.Length; i++)
        {
            markedSpaces[i] = -100; 
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

public void TicTacToeButton(int whichNumber) //which of the 9 boxes was clicked 
{

    xPlayersButton.interactable = false;
    oPlayersButton.interactable = false; 

    //visual aspect marking the cell X or an O 

    tictactoeSpaces[whichNumber].image.sprite = playerIcons[whoseTurn];
    //making the button that was clicked not be clicked again 
    tictactoeSpaces[whichNumber].interactable=false;

   markedSpaces[whichNumber] = whoseTurn+1; //identifying which spaces was marked by which player 
   turnCount++;
   if (turnCount > 4)
   {
   bool isWinner = WinnerCheck();

    if(turnCount ==  9 && isWinner == false)
    {
    Cat();
    }


   }
    //changing the turn 

    if(whoseTurn == 0 )
    {
        whoseTurn = 1; 

        //red circle indicator showing whose turn it is 
        turnIcons[0].SetActive(false);
        turnIcons[1].SetActive(true);
    }
    else 
    {
        whoseTurn = 0 ;
        // red circle indicator showing whose turn it is 
        turnIcons[0].SetActive(true);
        turnIcons[1].SetActive(false);
    }


} 


bool WinnerCheck()
{
    //8 possible ways to win tictactoe 
    int s1 = markedSpaces[0] + markedSpaces[1] + markedSpaces[2]; // s1 = solution  first row 
    int s2 = markedSpaces[3] + markedSpaces[4] + markedSpaces[5]; // s2 = solution  middle row  
    int s3 = markedSpaces[6] + markedSpaces[7] + markedSpaces[8]; // s3 = solution  bottom row

    int s4 = markedSpaces[0] + markedSpaces[3] + markedSpaces[6]; // s4 = solution  vertical 
    int s5 = markedSpaces[1] + markedSpaces[4] + markedSpaces[7]; // s5 = solution  vertical 
    int s6 = markedSpaces[2] + markedSpaces[5] + markedSpaces[8]; // s6 = solution  vertical 

    int s7 = markedSpaces[0] + markedSpaces[4] + markedSpaces[8]; // s7 = solution  horizontal

    //logic error somewhere !!!!!!! possible change to 2 instead of 0 
    int s8 = markedSpaces[2] + markedSpaces[4] + markedSpaces[6]; // s8 = solution  horizontal

    //creating array 

    var solutions = new int[] { s1, s2 , s3 , s4, s5, s6, s7, s8};

    for(int i = 0; i < solutions.Length; i++)
    {
        if(solutions[i] == 3 * (whoseTurn+1)) 
        {
            WinnerDisplay(i);
            return true;
        }
    }
    return false;
}


//DISPLAY THE WINNER 
void WinnerDisplay(int indexIn)
{

    // checking which player won the game 
    winnerPanel.gameObject.SetActive(true);
    if(whoseTurn == 0)
    {
        xPlayersScore++; // updating the score for X
        PlayerPrefs.SetInt("TicTacToeP1HighScore", (PlayerPrefs.GetInt("TicTacToeP1HighScore")) + 1); //Line of code added by Mason Audet on 11/29/23 for global score
        xPlayersScoreText.text = xPlayersScore.ToString(); // updating the text 
        winnerText.text = " Player X wins!";
    }
    else if(whoseTurn == 1)
    {
        oPlayersScore++; // updating the score for O
        PlayerPrefs.SetInt("TicTacToeP2HighScore", (PlayerPrefs.GetInt("TicTacToeP2HighScore")) + 1); //Line of code added by Mason Audet on 11/29/23 for global score
        oPlayersScoreText.text = oPlayersScore.ToString();//updating the text 
        winnerText.text = " Player O wins!";
    }
    winningLine[indexIn].SetActive(true);






      //  for(int i = 0; i < tictactoeSpaces.Length; i ++ )
    //{
     //   tictactoeSpaces[i].interactable = false; 

    //}

}

//REMATCH BUTTON
public void Rematch()
{
    GameSetup(); //button is clicked it calls the game setup 
    for(int i = 0 ; i <winningLine.Length; i++)
    {
        winningLine[i].SetActive(false); //disable line 
    
    }
    winnerPanel.SetActive(false);
    xPlayersButton.interactable = true;
    oPlayersButton.interactable= true;
     catImage.SetActive(false);

}
//RESTART BUTTON
public void Restart()
{
    Rematch();
    xPlayersScore = 0 ; 
    oPlayersScore = 0;
    xPlayersScoreText.text = "0";
    oPlayersScoreText.text = "0";
   // catImage.SetActive(false);
}

//Allows user to click which player to start "X" or "O" 
public void SwitchPlayer(int whichPlayer)
{
    if(whichPlayer == 0 )
    {
        whoseTurn = 0;
        turnIcons[0].SetActive(true);
        turnIcons[1].SetActive(false);

    }
    else if(whichPlayer == 1)
    {
        whoseTurn = 1; 
        turnIcons[0].SetActive(false);
        turnIcons[1].SetActive(true);
    }
}

//cat just refers to a tie between the players 
//it displays a letter C hinting that there is no winner in the game 

void Cat()
{
    //enabling the winner panel and c image to dsiplay the text 
    winnerPanel.SetActive(true);
    catImage.SetActive(true);
    winnerText.text = " TIE "; 

}



//quit button 
void QuitButton ()
{
    Application.Quit();
    Debug.Log("Game is exiting ");
}











}
