using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController: MonoBehaviour
{
    public bool paused;
    bool settingsMenuOpen;
    GameObject pauseMenu;
    GameObject settingsMenu;

    private void Start()
    {
        paused = false;
        pauseMenu = GameObject.FindGameObjectWithTag("Pause Menu");
        if (pauseMenu == null)
            pauseMenu = new GameObject("Fake Pause Menu");
        ClosePauseMenu();

        settingsMenu = GameObject.FindGameObjectWithTag("Settings Menu");
        if (settingsMenu == null)
            settingsMenu = new GameObject("Fake Settings Menu");
        CloseSettingsMenu();
    }

    public void LoadSceneByString(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Handles Pause Menu
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
        if (pauseMenu.name == "Fake Pause Menu")
            return;
        paused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void ClosePauseMenu()
    {
        paused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void OpenSettingsMenu()
    {
        settingsMenuOpen = true;
        settingsMenu.SetActive(true);
    }
    public void CloseSettingsMenu()
    {
        settingsMenuOpen = false;
        settingsMenu.SetActive(false);
    }

    // Handles Settings Menu

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

            if(settingsMenuOpen)
                CloseSettingsMenu();
        }
    }

}
