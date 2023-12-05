using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicHandler : MonoBehaviour
{
    public static BackgroundMusicHandler Instance;
    [SerializeField] GameObject backgroundMusic;

    private GameObject bgmObject;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            bgmObject = Instantiate(backgroundMusic, gameObject.transform);
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }

    public void SetVolume(float value)
    {
        AudioListener.volume = value;
    }
}
