using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DKGameManager : MonoBehaviour
{
    private int level; //keeping track of current level 
    private int lives ; //keeping track of how many lives 
    private int score; //keeping track of the score 

    private void Start()
    {
        DontDestroyOnLoad(gameObject); //doesnt destroy when loaded a new scene 
        NewGame();
    }
    private void NewGame()
    {
        lives = 3; 
        score = 0;
        LoadLevel(1);
    }


    private void LoadLevel(int index)
   {
    level = index;

   //Camera camera = Camera.main;
   //if (camera != null){
    //  camera.cullingMask=0;
    //}

    Invoke(nameof(LoadScene), 1f);
   }

    private void LoadScene()
    {
        SceneManager.LoadScene("StartMenu"); //level
    }

    //determine win or fail 

    public void LevelComplete()
    {
score += 1000;
//loads next level 
int nextLevel = level + 1;

if (nextLevel < SceneManager.sceneCountInBuildSettings){
    LoadLevel(nextLevel);
}else {
    LoadLevel(1);
}
    }


    public void LevelFailed()
    {
lives--;
if (lives <= 0 ){
    NewGame();
} else {
    
    LoadLevel(level);
}
    }
}
