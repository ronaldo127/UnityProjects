using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {

	public Text standingText;
	public float distanceToRaise = 40.0f;
	public GameObject pinSet;

	private int lastStandingCount = -1;
	private bool ballLeftBox = false;
	private float lastChangeTime;

	private Ball ball;
	private Animator animator;
	private ActionMaster player1;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		animator = GetComponent<Animator>();
		player1 = new ActionMaster();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (ballLeftBox) {
			UpdateStandingCount();
			UpdatePinSettled();
		}
	}

	public void RaisePins()
	{
		Pin[] pins = GameObject.FindObjectsOfType<Pin>();
		foreach (Pin pin in pins) {
			pin.Raise(distanceToRaise);
		}
	}

	public void LowerPins ()
	{
		Pin[] pins = GameObject.FindObjectsOfType<Pin>();
		foreach (Pin pin in pins) {
			pin.Lower(distanceToRaise);
		}
	}

	public void RenewPins ()
	{
		Instantiate(pinSet, pinSet.transform.position, Quaternion.identity);
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
			ActionMaster.Action action = player1.Bowl (CountFallen ());
			ball.Reset ();
			lastStandingCount = -1;
			ballLeftBox = false;

			float r = 0x4c;
			float g = 0xaf;
			float b = 0x50;
			float max = 0xff;
			standingText.color = new Color (r / max, g / max, b / max);
			switch (action) {
			case ActionMaster.Action.RESET:
				{
					Reset();
					break;
				}
			case ActionMaster.Action.TIDY:
				{
					Tidy();
					break;
				}
			case ActionMaster.Action.END_TURN:
				{
					Reset();
					break;
				}
			}
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


	public void Reset ()
	{
		standingText.color = Color.black;
		animator.SetTrigger("resetTrigger");
	}
	public void Tidy()
	{
		animator.SetTrigger("tidyTrigger");
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
