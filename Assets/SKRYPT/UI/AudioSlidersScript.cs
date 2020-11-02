using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioSlidersScript : MonoBehaviour
{
    [SerializeField] MixerController controller;
    public Slider MasterSlider;
    public Slider SFXSlider;
    public Slider MusicSlider;

    private void OnEnable()
    {
        MasterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.9f);
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.9f);
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.9f);

        controller.MasterSlider = MasterSlider;
        controller.SFXSlider = SFXSlider;
        controller.MusicSlider = MusicSlider;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("MasterVolume", MasterSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", MusicSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
        PlayerPrefs.Save();
    }




}
