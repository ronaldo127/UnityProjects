using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pause : MonoBehaviour {

	public Sprite stopImage;
	public Sprite resumeImage;


	private Image image;
	private bool isPaused = false;


	// Use this for initialization
	void Start () {
		image = GetComponent<Image>();
	}


	public void OnClick ()
	{
		isPaused = !isPaused;
		if (isPaused) {
			image.sprite = resumeImage;
			Time.timeScale = 0.0f;
			MusicPlayer.Pause();
		} else {
			image.sprite = stopImage;
			Time.timeScale = 1.0f;
			MusicPlayer.Resume();
		}
	}
}
