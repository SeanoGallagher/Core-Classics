using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class  DKMainMenu : MonoBehaviour
{
    public void  PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }
    
}
