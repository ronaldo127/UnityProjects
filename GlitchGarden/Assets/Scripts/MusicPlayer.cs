using UnityEngine;
using System.Collections;
using System;

public class MusicPlayer : MonoBehaviour
{

    private static MusicPlayer instance;

    public AudioClip[] musicChangeArray;

    private AudioSource audioSource;

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


    // Update is called once per frame
    void Update()
    {

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

    public static void PlayAudio (AudioClip audio)
	{
		if (instance) {
			if (audio) {
				instance.PlayOneShot (audio);
			}
		} else {
			LogWarningNotFound();
		}
    }


    public static void LogWarningNotFound(){
		Debug.LogWarning ("There is no MusicPlayer in Scene, so load SplashScreen first.");
    }
}
