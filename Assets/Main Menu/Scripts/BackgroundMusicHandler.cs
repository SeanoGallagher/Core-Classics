using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusicHandler : MonoBehaviour
{
    public static BackgroundMusicHandler Instance;
    [SerializeField] GameObject backgroundMusic;
    [SerializeField] Slider volumeSlider;

    private GameObject bgmObject;
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            bgmObject = Instantiate(backgroundMusic, gameObject.transform);
            audioSource = bgmObject.GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if( !PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        AudioListener.volume = volumeSlider.value;
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
        AudioListener.volume = volumeSlider.value;
    }
}
