using UnityEngine;
using System.Collections;

public class PlayBox : MonoBehaviour {

	private PinSetter pinSetter;

	// Use this for initialization
	void Start () {
		pinSetter = GameObject.FindObjectOfType<PinSetter>();
	}

	void OnTriggerExit (Collider col)
	{
		if (col.GetComponent<Ball> ()) {
			pinSetter.BallLeftBox();
		}
	}
}
