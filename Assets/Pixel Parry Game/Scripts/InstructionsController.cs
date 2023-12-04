using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsController : MonoBehaviour
{
    [SerializeField] GameObject instructionsMenu;
    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        CloseInstructionsMenu();
    }

    public void CloseInstructionsMenu()
    {
        isOpen = false;
        instructionsMenu.SetActive(false);
    }

    public void OpenInstructionsMenu()
    {
        isOpen = true;
        instructionsMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseInstructionsMenu();
        }
    }
}
