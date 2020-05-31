using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MixerController : MonoBehaviour
{
    public AudioMixer mixer;

    public Slider MasterSlider;
    public Slider MusicSlider;
    public Slider SFXSlider;

    public void SetMasterVolume (float volume)
    {
        mixer.SetFloat("MasterVolume", volume);
    }
    public void SetMusicVolume(float volume)
    {
        mixer.SetFloat("MusicVolume", volume);
    }
    public void SetSFXVolume(float volume)
    {
        mixer.SetFloat("SFXVolume", volume);
    }

    private void Start()
    {
        MasterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0);
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0);
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0);
    }


    private void OnDisable()
    {
        float MasterVolume = 0;
        float MusicVolume = 0;
        float SFXVolume = 0;

        mixer.GetFloat("MasterVolume", out MasterVolume);
        mixer.GetFloat("MusicVolume", out MusicVolume);
        mixer.GetFloat("SFXVolume", out SFXVolume);



        PlayerPrefs.SetFloat("MasterVolume", MasterVolume);
        PlayerPrefs.SetFloat("MusicVolume", MusicVolume);
        PlayerPrefs.SetFloat("SFXVolume", SFXVolume);
        PlayerPrefs.Save();

    }
}
