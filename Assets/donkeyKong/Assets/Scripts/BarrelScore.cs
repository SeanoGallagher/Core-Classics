using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScore : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {
            DKScore.DK_score++;
        }
    }
}
