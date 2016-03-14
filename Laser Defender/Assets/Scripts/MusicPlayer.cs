using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	private static MusicPlayer instance;

	void Awake ()
	{
		if (instance == null) {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		} else {
			Destroy(gameObject);
		}
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
