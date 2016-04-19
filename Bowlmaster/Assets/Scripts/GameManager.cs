using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	private IList<int> bowls = new List<int>();

	private PinSetter pinSetter;
	private Ball ball;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		pinSetter = GameObject.FindObjectOfType<PinSetter>();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Bowl (int pinFall)
	{
		bowls.Add(pinFall);
		ActionMaster.Action action = ActionMaster.NextAction (bowls);
		pinSetter.PerformAction(action);
		ball.Reset ();
	}
}
