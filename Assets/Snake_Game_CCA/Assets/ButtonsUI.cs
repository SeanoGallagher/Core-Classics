using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetTimeScale(float scale) // Function that passes a value to set the timescale to
    {
        Time.timeScale = scale;
    }

    public void Speed1Button() // When the first button is clicked, the game speed is set to the original speed
    {

        SetTimeScale(1f);

    }

    public void Speed2Button() // When the second button is clicked, the game speed is set to 1.5x original speed
    {

        SetTimeScale(1.25f);

    }

    public void Speed3Button() // When the third button is clicked, the game speed is set to 2x original speed
    {

        SetTimeScale(1.5f);

    }
}
