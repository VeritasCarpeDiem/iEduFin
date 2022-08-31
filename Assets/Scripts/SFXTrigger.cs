using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXTrigger : MonoBehaviour
{
    public void PlayHighlightSFX()
    {
        Debug.Log("play highlight sfx");
        SFXManager.sfxInstance.audio.PlayOneShot(SFXManager.sfxInstance.highlight);
    }
    
    public void PlaySelectSFX()
    {
        Debug.Log("play select sfx");
        SFXManager.sfxInstance.audio.PlayOneShot(SFXManager.sfxInstance.click);
    }
}
