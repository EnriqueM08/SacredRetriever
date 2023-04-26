using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundOptions : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start(){
        if(PlayerPrefs.GetInt("setFirstTimeVolume") == 0) {
            PlayerPrefs.SetInt("setFirstTimeVolume", 1);
            masterSlider.value = .25f;
            musicSlider.value = .25f;
            sfxSlider.value = .25f;
        } else {
            masterSlider.value = PlayerPrefs.GetFloat("MasterVol");
            musicSlider.value = PlayerPrefs.GetFloat("MusicVol");
            sfxSlider.value = PlayerPrefs.GetFloat("SFX");
        }
    }

    public void SetMasterVolume() {
        SetVolume("MasterVol", masterSlider.value);
    }

    public void SetMusicVolume() {
        SetVolume("MusicVol", musicSlider.value);
    }

    public void SetSFXVolume() {
        SetVolume("SFX", sfxSlider.value);
    }

    void SetVolume(string name, float value) {
        float volume = Mathf.Log10(value) * 20;
        if(value == 0)
        {
            volume = -80;
        }

        audioMixer.SetFloat(name, volume);
        PlayerPrefs.SetFloat(name, value);
    }
}
