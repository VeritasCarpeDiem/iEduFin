using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] private Slider musicVolumeSlider;
    //[SerializeField] private Slider SFXVolumeSlider;
    void Start()
    {
        Debug.Log("at start");
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            Debug.Log("haskey");
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Debug.Log("hasnokey");
            Load();
        }
    }

    public void ChangeVolume()
    {
        Debug.Log("changevol");
        AudioListener.volume = musicVolumeSlider.value;
        Save();
    }

    private void Load()
    {
        Debug.Log("load");
        musicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        Debug.Log("save");
        PlayerPrefs.SetFloat("musicVolume", musicVolumeSlider.value);
    }
}
