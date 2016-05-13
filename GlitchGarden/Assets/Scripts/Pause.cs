using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pause : MonoBehaviour {

	public Sprite stopImage;
	public Sprite resumeImage;
	public bool IsPaused {
		get{ 
			return isPaused;
		}
	}

	private AdsManager adsManager;
	private Image image;
	private bool isPaused = false;


	// Use this for initialization
	void Start () {
		image = GetComponent<Image>();
		adsManager = GameObject.FindObjectOfType<AdsManager>();
	}


	public void OnClick ()
	{
		isPaused = !isPaused;
		if (isPaused) {
			PauseAction();
		} else {
			ResumeAction();
		}
	}

	private void PauseAction()
	{
		image.sprite = resumeImage;
		Time.timeScale = 0.0f;
		MusicPlayer.Pause();
		if (adsManager!=null) adsManager.RequestBanner();
	}
	private void ResumeAction()
	{
		if (adsManager!=null) adsManager.DestroyBanner();
		image.sprite = stopImage;
		Time.timeScale = 1.0f;
		MusicPlayer.Resume();
	}
}
