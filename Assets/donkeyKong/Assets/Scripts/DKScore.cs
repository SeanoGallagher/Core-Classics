using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DKScore : MonoBehaviour
{
    public static int DK_score = 0;

    private void Start(){

    }

    private void Update(){
        GetComponent<UnityEngine.UI.Text>().text = DK_score.ToString();
    }

    public void ResetScore(){
        DK_score=0;
    }
}
