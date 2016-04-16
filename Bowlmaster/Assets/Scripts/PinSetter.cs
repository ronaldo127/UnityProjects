using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {

	public int lastStandingCount = -1;
	public Text standingText;
	public float distanceToRaise = 40.0f;
	public GameObject pinSet;

	private Ball ball;
	private float lastChangeTime;
	private bool ballEnteredBox = false;
	private Animator animator;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		standingText.text = CountStanding ().ToString ();
		if (ballEnteredBox) {
			UpdateStandingCountAndSettle();
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
		print("RenewPins!");
		Instantiate(pinSet, pinSet.transform.position, Quaternion.identity);
	}

	void UpdateStandingCountAndSettle ()
	{
		int currentStanding = CountStanding ();
		if (lastStandingCount != currentStanding) {
			lastStandingCount = currentStanding;
			lastChangeTime = Time.time;
		}
			PinHaveSettled();
	}

	void PinHaveSettled ()
	{
		if (Time.time - lastChangeTime >= 3.0f) {
			ball.Reset();
			lastStandingCount=-1;
			ballEnteredBox=false;

			float r = 0x4c;
			float g = 0xaf;
			float b = 0x50;
			float max = 0xff;
			standingText.color = new Color(r/max, g/max, b/max);
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

	void OnTriggerEnter (Collider collider)
	{
		Ball ball = collider.GetComponent<Ball>();
		if (ball){
			float r = 0xf4;
			float g = 0x43;
			float b = 0x36;
			float max = 0xff;
			standingText.color = new Color(r/max, g/max, b/max);
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

	public void Reset ()
	{
		animator.SetTrigger("resetTrigger");
	}
	public void Tidy()
	{
		animator.SetTrigger("tidyTrigger");
	}
}
