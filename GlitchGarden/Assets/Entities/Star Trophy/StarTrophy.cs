using UnityEngine;
using System.Collections;

public class StarTrophy : MonoBehaviour {

	public int starsPoints;

	private StarDisplay starDisplay;

	void Start(){
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}

	public void AddStars ()
	{
		starDisplay.AddStars(starsPoints);
	}

}
