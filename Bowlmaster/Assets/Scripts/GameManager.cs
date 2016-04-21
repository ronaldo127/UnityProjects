using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour {

	private List<int> rolls = new List<int>();

	private PinSetter pinSetter;
	private Ball ball;
	private ScoreDisplay scoreDisplay;
	private PinCounter pinCounter;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		pinSetter = GameObject.FindObjectOfType<PinSetter>();	
		scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
		pinCounter = GameObject.FindObjectOfType<PinCounter>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Bowl (int pinFall)
	{
		rolls.Add(pinFall);
		ActionMaster.Action action = ActionMaster.NextAction (rolls);

		if (action==ActionMaster.Action.RESET || action==ActionMaster.Action.END_TURN)
			pinCounter.Reset();

		pinSetter.PerformAction(action);

		scoreDisplay.FillRolls(rolls);
		scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));

		ball.Reset ();
	}
}
