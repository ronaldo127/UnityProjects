using UnityEngine;
using System.Collections;

public class StarTrophy : MonoBehaviour {

	public int starsPoints;
	public AudioClip coinSound;

	private StarDisplay starDisplay;

	void Start(){
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		if (!starDisplay) Debug.LogWarning("No StarDisplay on scene!");
	}

	public void AddStars ()
	{
		if (starDisplay) {
			MusicPlayer.PlayAudio(coinSound);
			starDisplay.AddStars (starsPoints);
		}
	}

}
