using UnityEngine.Audio;
using System;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioManager audioManager;
    public Sound[] ThemeSounds;

    // Start is called before the first frame update
    public void Awake()
    {
        audioManager=AudioManager.instance;
        


        

		ThemeSounds[0]=  Array.Find(audioManager?.sounds, item => item.name == "Theme");
        ThemeSounds[1]=  Array.Find(audioManager?.sounds, item => item.name == "Theme2");
        ThemeSounds[2]=  Array.Find(audioManager?.sounds, item => item.name == "Theme3");
        //DontDestroyOnLoad(this.gameObject);
	
    }///  AudioSource.isPlaying
    public void ChangeTheme1()
    {
        if(ThemeSounds[0].source != null)
        {
            Invoke("ChangeTheme2",ThemeSounds[0].source.clip.length+1.0f);
        }
        Debug.Log("Theme1 sie skonczyl  ");
    }
    void ChangeTheme2()
    {
        Debug.Log("Theme2 zaczynam ");
        AudioManager.instance.Play("Theme2");
        if (ThemeSounds[1].source != null)
        {
            Invoke("ChangeTheme3", ThemeSounds[0].source.clip.length + 1.0f);
        }
    }
    public void ChangeTheme3()
    {
        Debug.Log("Theme3 zaczynam ");
        AudioManager.instance.Play("Theme3");
        if (ThemeSounds[2].source != null)
        {
            Invoke("ChangeTheme4", ThemeSounds[2].source.clip.length + 1.0f);
        }
    }
    public void ChangeTheme4()
    {
        AudioManager.instance.Play("Theme");
        if (ThemeSounds[0].source != null)
        {
            Invoke("ChangeTheme2", ThemeSounds[0].source.clip.length + 1.0f);
        }
        Debug.Log("Theme1 sie skonczyl  ");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
