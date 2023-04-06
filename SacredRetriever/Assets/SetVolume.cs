using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider MasterVolume;
    public Slider MusicVolume;
    public Slider FXVolume;

    public void Start()
    {
        
    }
    public void SetLevelMaster(float sliderValue)
    {
        mixer.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20);

    }
    public void SetLevelMusic(float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);

    }
    public void SetLevelFX(float sliderValue)
    {
        mixer.SetFloat("FXVol", Mathf.Log10(sliderValue) * 20);
    }

    public void SetRosultion() {

    }
}
