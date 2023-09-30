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
            paused = false;
            ClosePauseMenu();
        }
        else
        {
            paused = true;
            OpenPauseMenu();
        }
    }
    void OpenPauseMenu()
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            return;
        }
        pauseMenu.SetActive(true);
    }
    void ClosePauseMenu()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            return;
        }
        pauseMenu.SetActive(false);
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
