using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private void Start()
    {
        Time.timeScale=1;

    }

    public void GameOver(){
        SceneManager.LoadScene("Flappy GameOver");
        Time.timeScale=0;
    }
}
