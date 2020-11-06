using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{

	public static AudioManager instance;

	public MusicManager musicManager;

	public AudioMixerGroup mixerGroup;

	public float fadeOutDuration;

	public Sound[] sounds;

	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			//DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;
			s.startVolume = s.volume;

			s.source.outputAudioMixerGroup = s.mixerGroup;
		}
	}

	void Start()
	{
		Play("Menu Theme");
	}
	
	public void OnDie()
    {
		MuteSounds();
		musicManager.deathTrack.Play();
    }

	[ContextMenu("Mute")]
	public void MuteSounds()
    {
		StopAllCoroutines();
		StartCoroutine(ChangeSoundVolume(true));
    }

	[ContextMenu("UnMute")]
	public void UnMuteSounds()
    {
		StopAllCoroutines();
		StartCoroutine(ChangeSoundVolume(false));
	}

	public IEnumerator ChangeSoundVolume(bool muteSounds)
    {
		Debug.Log("StartCorouting");
		float startTime = Time.realtimeSinceStartup;
		var progress = 0f;
		while(progress <= 1)
        {
			progress = (Time.realtimeSinceStartup - startTime) / fadeOutDuration;

			foreach (var sound in sounds)
			{
				sound.source.volume = Mathf.Lerp(sound.source.volume, muteSounds ? 0f : sound.startVolume, progress);
			}
			yield return null;
		}
		Debug.Log("FinishCorouting");
	}

	public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));
		s.source.Play();
	}

    public void Stop(string sound)
    {
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}
		s.source.Stop();
	}

}
