using UnityEngine;
using System.Collections;

public class StarTrophy : MonoBehaviour {

	public int starsPoints;

	private StarDisplay starDisplay;

	void Start(){
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		if (!starDisplay) Debug.LogWarning("No StarDisplay on scene!");
	}

	public void AddStars ()
	{
		if (starDisplay) starDisplay.AddStars(starsPoints);
	}

}
