using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerController : MonoBehaviour
{
    public AudioMixer mixer;

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
}
