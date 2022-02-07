using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundSettingsLoad : MonoBehaviour
{   
    public AudioMixer musicMixer;
    public AudioMixer effectMixer;
    void Start(){
        musicMixer.SetFloat("MasterVolume", Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume", 0.75f)) * 20);
        effectMixer.SetFloat("MasterVolume", Mathf.Log10(PlayerPrefs.GetFloat("EffectsVolume", 0.75f)) * 20);
    }
}
