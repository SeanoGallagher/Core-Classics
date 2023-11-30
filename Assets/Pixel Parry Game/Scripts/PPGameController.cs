using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPGameController : MonoBehaviour
{
    public GameObject player;
    public GameObject AI;
    public MenuController menuController;

    public float gameEndTimer = 2;

    public void PlayerWon()
    {
        StartCoroutine(PlayerWonCoroutine());
    }

    IEnumerator PlayerWonCoroutine()
    {
        Destroy(AI);

        yield return new WaitForSeconds(gameEndTimer);

        //Added in this line to track the global game score.
        PlayerPrefs.SetInt("PixelParryHighScore", PlayerPrefs.GetInt("PixelParryHighScore") + 1);

        menuController.LoadSceneByString("PPGameWon");
    }


    public void AiWon()
    {
        StartCoroutine(AIWonCoroutine());
    }
    IEnumerator AIWonCoroutine()
    {
        Destroy(player);

        yield return new WaitForSeconds(gameEndTimer);

        menuController.LoadSceneByString("PPGameOver");
    }
}
