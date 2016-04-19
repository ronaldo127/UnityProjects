using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PinCounter : MonoBehaviour {

	public Text standingText;


	private bool ballLeftBox = false;
	private float lastChangeTime;
	private int lastStandingCount = -1;

	private GameManager gameManager;
	private Ball ball;


	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		gameManager = GameObject.FindObjectOfType<GameManager>();
	}

	// Update is called once per frame
	void Update ()
	{
		if (ballLeftBox) {
			UpdateStandingCount();
			UpdatePinSettled();
		}
	}

	void UpdateStandingCount ()
	{
		int currentStanding = CountStanding ();
		standingText.text = currentStanding.ToString();
		if (lastStandingCount != currentStanding) {
			lastStandingCount = currentStanding;
			lastChangeTime = Time.time;
		}
	}

	void UpdatePinSettled ()
	{
		if (Time.time - lastChangeTime >= 3.0f) {
			gameManager.Bowl(CountFallen());

			lastStandingCount = -1;
			ballLeftBox = false;

			float r = 0x4c;
			float g = 0xaf;
			float b = 0x50;
			float max = 0xff;
			standingText.color = new Color (r / max, g / max, b / max);
		}
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

	public int CountFallen ()
	{
		return 10-CountStanding();
	}


	public void BallLeftBox ()
	{
		float r = 0xf4;
		float g = 0x43;
		float b = 0x36;
		float max = 0xff;
		standingText.color = new Color(r/max, g/max, b/max);
		ballLeftBox = true;
	}
}
