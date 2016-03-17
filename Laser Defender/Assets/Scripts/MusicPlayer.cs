using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{

    public AudioClip menuClip;
    public AudioClip inGameClip;

    private static MusicPlayer instance;
    private AudioSource music;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
        }
        else {
            Destroy(gameObject);
        }
    }

    public void OnLevelWasLoaded(int level)
    {
        music.Stop();
        if (level != 1)
            music.clip = menuClip;
        else
            music.clip = inGameClip;

        music.loop = true;
        music.Play();
    }




    // Update is called once per frame
    void Update()
    {

    }
}
