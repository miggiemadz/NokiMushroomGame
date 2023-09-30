using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public AudioSource Music;
    [SerializeField] Slider musicVolumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 1);
            LoadVolume();
        }
        else
        {
            LoadVolume();
        }
    }

    private void Update()
    {
        Music.volume = musicVolumeSlider.value;
        SaveVolume();
    }

    public void ChangeVolume()
    {
        AudioListener.volume = musicVolumeSlider.value;
    }

    private void LoadVolume()
    {
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        SaveVolume();
    }

    private void SaveVolume()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
    }
}
