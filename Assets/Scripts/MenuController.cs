using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController: MonoBehaviour
{
    public bool paused;
    GameObject pauseMenu;

    private void Start()
    {
        paused = false;
        pauseMenu = GameObject.FindGameObjectWithTag("Pause Menu");
    }

    public void LoadSceneByString(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void OpenClosePauseMenu()
    {
        paused = !paused;
        if(SceneManager.GetActiveScene().name == "Main")
        {
            return;
        }
        pauseMenu.SetActive(paused);
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
