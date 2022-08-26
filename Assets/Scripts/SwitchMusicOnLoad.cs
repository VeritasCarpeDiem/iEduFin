using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicOnLoad : MonoBehaviour
{
    public AudioClip newTrack;

    private AudioManager theAM;

   void Awake()
   {
       theAM = FindObjectOfType<AudioManager>();
       
       if (newTrack != null)
            theAM.ChangeBGM(newTrack);
    }
}
