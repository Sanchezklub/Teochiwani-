using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private VideoClip Intro;
    [SerializeField] private VideoClip HumanEnding;
    [SerializeField] private VideoClip GodsEnding;
    [SerializeField] private GameObject CutsceneObject;
    [ContextMenu("test")]
    public void PlayHumanEnding()
    {
        CutsceneObject.SetActive(true);
        videoPlayer.clip = HumanEnding;
        videoPlayer.Play();
    }

    public void PlayGodsEnding()
    {
        CutsceneObject.SetActive(true);
        videoPlayer.clip = GodsEnding;
        videoPlayer.Play();
    }

    public void PlayIntro()
    {
        CutsceneObject.SetActive(true);
        videoPlayer.clip = Intro;
        videoPlayer.Play();
    }










}
