using UnityEngine;
using System.Collections;

public class PlayBox : MonoBehaviour {

	private PinCounter pinCounter;

	// Use this for initialization
	void Start () {
		pinCounter = GameObject.FindObjectOfType<PinCounter>();
	}

	void OnTriggerExit (Collider col)
	{
		if (col.GetComponent<Ball> ()) {
			pinCounter.BallLeftBox();
		}
	}
}
