using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {

	public Text standingText;

	private bool ballEnteredBox = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		standingText.text = CountStanding().ToString();
	}

	public int CountStanding ()
	{
		Pin[] pins = GameObject.FindObjectsOfType<Pin>();
		int count = 0;
		foreach (Pin pin in pins) {
			if (pin.IsStanding())
				count++;
		}
		return count;
	}

	void OnTriggerEnter (Collider collider)
	{
		Ball ball = collider.GetComponent<Ball>();
		if (ball){
			standingText.color = Color.red;
			ballEnteredBox = true;
		}
	}
	void OnTriggerExit (Collider collider)
	{
		Pin pin = collider.GetComponentInParent<Pin>();
		if (pin) {
			Destroy(pin);
		}
	}
}
