using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {

	public float distanceToRaise = 40.0f;
	public GameObject pinSet;


	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
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

	public void Reset ()
	{
		animator.SetTrigger("resetTrigger");
	}

	public void Tidy()
	{
		animator.SetTrigger("tidyTrigger");
	}

	public void PerformAction (ActionMaster.Action action)
	{
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
