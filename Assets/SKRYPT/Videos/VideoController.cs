using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class VideoController : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private VideoClip Intro;
    [SerializeField] private VideoClip HumanEnding;
    [SerializeField] private VideoClip GodsEnding;
    [SerializeField] private GameObject CutsceneObject;
    [SerializeField] private PauseController pause;
    [ContextMenu("test")]
    public void PlayHumanEnding()
    {
        GameController.instance.DataStorage.PlayerInfo.BeatenGame = true;
        videoPlayer.loopPointReached += ReloadScene;
        AudioManager.instance.MuteSounds();
        CutsceneObject.SetActive(true);
        videoPlayer.clip = HumanEnding;
        videoPlayer.Play();
    }

    void ReloadScene(VideoPlayer videoPlayer)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayGodsEnding()
    {
        GameController.instance.DataStorage.PlayerInfo.BeatenGame = true;
        videoPlayer.loopPointReached += ReloadScene;
        AudioManager.instance.MuteSounds();
        CutsceneObject.SetActive(true);
        videoPlayer.clip = GodsEnding;
        videoPlayer.Play();
    }

    public void PlayIntro()
    {
        AudioManager.instance.MuteSounds();
        CutsceneObject.SetActive(true);
        videoPlayer.clip = Intro;
        videoPlayer.Play();
    }
    









}
