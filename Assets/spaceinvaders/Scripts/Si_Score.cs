using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Si_Score : MonoBehaviour
{
    public static int SIscore = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = SIscore.ToString();
    }

    public void ResetScore(){
        SIscore=0;
    }
}
