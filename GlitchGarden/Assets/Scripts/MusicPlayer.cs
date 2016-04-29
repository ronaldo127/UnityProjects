using UnityEngine;
using System.Collections;
using System;

delegate void Method(); 

public class MusicPlayer : MonoBehaviour
{

    private static MusicPlayer instance;

    public AudioClip[] musicChangeArray;

    private AudioSource audioSource;

	private MusicPlayer ()
	{
	}

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
        OnLevelWasLoaded(0);
    }

    internal void SetVolume(float value)
    {
        audioSource.volume = value;
    }

    public void OnLevelWasLoaded(int level)
    {
        audioSource.Stop();
        if (level >= 0 && level <= musicChangeArray.Length && musicChangeArray[level]!=null) {
            audioSource.clip = (musicChangeArray[level]);
            audioSource.loop = level>0;
            audioSource.Play();
        }
	}

	public void PlayOneShot (AudioClip audio)
	{
		if (audio) {
			audioSource.PlayOneShot (audio);
		}
	}

	public static void Pause ()
	{
		Method m = delegate (){
			instance.audioSource.Pause();
		};
		LogWrapper(m);
	}
	public static void Resume ()
	{
		Method m = delegate (){
			instance.audioSource.UnPause();
		};
		LogWrapper(m);
	}



    public static void PlayAudio (AudioClip audio)
	{
		Method m = delegate (){
			if (audio) {
				instance.PlayOneShot (audio);
			}
		};
		LogWrapper(m);
    }

	private static void LogWrapper(Method m){//this technique avoids repetition
		if (instance) {
			m();
		} else {
			LogWarningNotFound();
		}
    }

    public static void LogWarningNotFound(){
		Debug.LogWarning ("There is no MusicPlayer in Scene, so load SplashScreen first.");
    }
}
