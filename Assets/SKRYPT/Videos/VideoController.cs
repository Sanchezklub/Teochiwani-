using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class VideoController : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private VideoClip Intro;
    [SerializeField] private VideoClip HumanEnding;
    [SerializeField] private VideoClip GodsEnding;
    [SerializeField] private GameObject CutsceneObject;
    [SerializeField] private PauseController pause;
    [SerializeField] private AudioSource source;
    //[SerializeField] private AudioMixerGroup group;
    [SerializeField] private AudioMixer mixer;
    private float MixerOldFloat;
    [ContextMenu("test")]
    public void PlayHumanEnding()
    {
        GameController.instance.DataStorage.PlayerInfo.BeatenGame = true;
        videoPlayer.loopPointReached += ReloadScene;
        AudioManager.instance.MuteSounds();
        CutsceneObject.SetActive(true);
        mixer.GetFloat("SFXVolume", out MixerOldFloat);
        //mixer.SetFloat("SFXVolume", 0.0001f);
        mixer.SetFloat("SFXVolume", Mathf.Log10(0.0001f) * 20);
        videoPlayer.clip = HumanEnding;
        videoPlayer.SetTargetAudioSource(0, source);
        videoPlayer.Play();
    }

    void ReloadScene(VideoPlayer videoPlayer)
    {
        mixer.SetFloat("SFXVolume", MixerOldFloat);
        SaveSystem.Instance.FullySaveGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayGodsEnding()
    {
        GameController.instance.DataStorage.PlayerInfo.BeatenGame = true;
        videoPlayer.loopPointReached += ReloadScene;
        AudioManager.instance.MuteSounds();
        CutsceneObject.SetActive(true);
        mixer.GetFloat("SFXVolume", out MixerOldFloat);
        //mixer.SetFloat("SFXVolume", -80f);
        mixer.SetFloat("SFXVolume", Mathf.Log10(0.0001f) * 20);
        videoPlayer.clip = GodsEnding;
        videoPlayer.SetTargetAudioSource(0,source);
        videoPlayer.Play();
    }

    public void PlayIntro()
    {
        AudioManager.instance.MuteSounds();
        CutsceneObject.SetActive(true);
        videoPlayer.clip = Intro;
        videoPlayer.Play();
    }
    
    void PrepareSource()
    {
    }

    






}
