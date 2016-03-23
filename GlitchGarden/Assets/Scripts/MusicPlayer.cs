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
}
