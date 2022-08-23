using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class AudioManager : MonoBehaviour
{
    public static AudioManager BgInstance;

    public AudioSource BGM;
    
    private void Awake()
    {
        if (BgInstance != null && BgInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        BgInstance = this;
        DontDestroyOnLoad(this);
    }

    public void ChangeBGM(AudioClip music)
    {
        if (BGM.clip.name == music.name)
            return;
        
        BGM.Stop();
        BGM.clip = music;
        BGM.Play();
    }

}


