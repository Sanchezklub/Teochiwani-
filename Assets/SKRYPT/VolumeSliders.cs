using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliders : MonoBehaviour
{
    public Slider GeneralVolumeSlider;
    public Slider MusicVolumeSlider;
    public Slider SFXVolumeSlider;
    public float GeneralVolume;
    public float MusicVolume;
    public float SFXVolume;

    public void SaveGeneralVolume()
    {
        float GeneralVolume = GeneralVolumeSlider.value;
    }
    public void SaveMusicVolume()
    {
        float MusiclVolume = MusicVolumeSlider.value;
    }
    public void SaveSFXVolume()
    {
        float SFXlVolume = SFXVolumeSlider.value;
    }

    void Update()
    {
        Debug.Log(GeneralVolume);
        Debug.Log(MusicVolume);
        Debug.Log(SFXVolume);
    }
}
