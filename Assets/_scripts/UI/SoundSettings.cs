using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public AudioMixer musicMixer;
    public AudioMixer effectMixer;

    public Slider musicSlider;
    public Slider effectSlider;
    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        effectSlider.value = PlayerPrefs.GetFloat("EffectsVolume", 0.75f);
    }
    public void SetLevelEffects (float sliderValue)
    {
        effectMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("EffectsVolume", sliderValue);
    }
    public void SetLevelMusic (float sliderValue)
    {
        musicMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
