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
        mixer.SetFloat("MasterVolume", Mathf.Log10(volume)*20);
    }
    public void SetMusicVolume(float volume)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }
    public void SetSFXVolume(float volume)
    {
        mixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }

    private void Start()
    {
        MasterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.9f);
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.9f);
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.9f);
    }


    private void OnDisable()
    {
        //float MasterVolume = 0;
        //float MusicVolume = 0;
        //float SFXVolume = 0;

        //mixer.GetFloat("MasterVolume", out MasterVolume);
        //mixer.GetFloat("MusicVolume", out MusicVolume);
        //mixer.GetFloat("SFXVolume", out SFXVolume);



        PlayerPrefs.SetFloat("MasterVolume", MasterSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", MusicSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
        PlayerPrefs.Save();

    }
}
