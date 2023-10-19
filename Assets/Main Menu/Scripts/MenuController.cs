using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController: MonoBehaviour
{
    public bool paused;
    GameObject pauseMenu;

    private void Awake()
    {
        paused = false;
        pauseMenu = GameObject.FindGameObjectWithTag("Pause Menu");
        Debug.Log(pauseMenu.name);
        ClosePauseMenu();
    }

    public void LoadSceneByString(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void OpenClosePauseMenu()
    {
        if (paused)
        {
            ClosePauseMenu();
        }
        else
        {
            OpenPauseMenu();
        }
    }
    public void OpenPauseMenu()
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            return;
        }
        paused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void ClosePauseMenu()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            return;
        }
        paused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            OpenClosePauseMenu();
        }
    }

}