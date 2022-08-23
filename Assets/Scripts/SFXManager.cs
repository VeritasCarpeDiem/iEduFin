using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip click;
    public AudioClip highlight;
    public static SFXManager sfxInstance;

    private void Awake()
    {
        if (sfxInstance != null && sfxInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        sfxInstance = this;
        DontDestroyOnLoad(this);
    }

    public void PlayHighlightSFX()
    {
        audio.PlayOneShot(highlight);
    }
}
