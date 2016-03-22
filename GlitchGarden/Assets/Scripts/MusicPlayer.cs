using UnityEngine;
using System.Collections;

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
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void OnLevelWasLoaded(int level)
    {
        audioSource.Stop();
        if (level > 0 && level <= musicChangeArray.Length && musicChangeArray[level]!=null) {
            audioSource.clip = (musicChangeArray[level]);
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
