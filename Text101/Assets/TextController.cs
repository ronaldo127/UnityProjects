using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;

	private enum States
	{
		initial,
		cell,
		mustache,
		sheets_0,
		look_0,
		throw_mustache,
		sheets_1,
		look_1,
		freedom
	}

	private States currentState;

	// Use this for initialization
	void Start () {
		currentState = States.initial;
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (currentState) {
			case States.initial:
				stateInitial();
				break;
			case States.cell:
				stateCell ();
			break;
			case States.sheets_0:
				stateSheet0 ();
				break;
			case States.look_0:
				stateLook0 ();
			break;
			case States.sheets_1:
				stateSheet1 ();
				break;
			case States.look_1:
				stateLook1 ();
			break;
			case States.mustache:
				stateMustache ();
			break;
			case States.throw_mustache:
				stateThrowMustache ();
				break;
			case States.freedom:
				stateFreedom();
			break;
		}
	}
	void stateInitial (){
		text.alignment = TextAnchor.MiddleCenter;
		text.text = "Press space to start";
		if (Input.GetKeyDown (KeyCode.Space)) {
			text.alignment = TextAnchor.UpperLeft;
			currentState=States.cell;
		}
	}

	void stateCell ()
	{
		text.text = "Once upon time, in a southern hot land called Lizarb a boy was forced" +
					" to stay in a room every morning for listening to a big lizard talking." +
					" However today he felt something different, he heard something inside his" +
					" head. I believe it is you, so go on help our heroe to get off this room." +
					" Make he knows what means freedom\n\n" +
					"Press S to view Sheets of paper, M to grab Mustache eraser and L to Look at the Door ";

		if (Input.GetKeyDown (KeyCode.S)) {
			currentState = States.sheets_0;
		}
		if (Input.GetKeyDown (KeyCode.M)) {
			currentState = States.mustache;
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			currentState = States.look_0;
		}

	}

	void stateSheet0 ()
	{
		text.text = "Why do I have to copy all theses things if I won't read them?\n" +
					"After all, books are for it. They save the information to someone else read them, I must write only thing that nobody has written, don't I? " +
					"Why that lizard keep telling me to write down the book? It doesn't make sense for me... I should get out of here! It is a waste of time..." +
					"\n\n" +
					"Press R to Return to seeking a way out";

		if (Input.GetKeyDown (KeyCode.R)) {
			currentState = States.cell;
		}
		
	}

	void stateLook0 ()
	{
		text.text = "I wonder what is outside this room. The corridors are so full when I arrive and leave. Is it empty now? Everyone is inside a room like this?"+
					" But why? Anyway, I still have to find my way out. If only The lizard looked away, so I would be able to leave in peace..."+
					"\n\n"+
					"Press R to Return to seeking a way out";
		if (Input.GetKeyDown (KeyCode.R)) {
			currentState = States.cell;
		}
	}

	void stateMustache ()
	{
		text.text = "Hum... a mustache eraser it is a different object indeed. Maybe if I throw it, it will help me some how." +
		"\n\n" +
		"Press T to throw the mustache or press R to Return to seeking a way out";
		if (Input.GetKeyDown (KeyCode.T)) {
			currentState = States.throw_mustache;
		}
		else if (Input.GetKeyDown (KeyCode.R)) {
			currentState = States.cell;
		}
	}

	void stateThrowMustache(){

		text.text = "My eraser fell on the other side of the room." +
				" Whatta ugly old lizard or wizard? He thinks is so smart that can do magic with the right ingredients. He is really crazy lol." +
				" It doesn't matter. Come on what is next?" +
				"\n\n" +
				"Press S to view Sheets of paper, L to Look at the Door ";

		if (Input.GetKeyDown (KeyCode.S)) {
			currentState = States.sheets_1;
		}else
		if (Input.GetKeyDown (KeyCode.L)) {
			currentState = States.look_1;
		}
	}

	void stateSheet1 ()
	{
		text.text = "Man I wrote a lot. Anyway, he still is looking at my eraser\n" +
					"I should grab this opportunity!" +
					"\n\n" +
					"Press R to Return to seeking a way out";

		if (Input.GetKeyDown (KeyCode.R)) {
			currentState = States.throw_mustache;
		}
		
	}

	void stateLook1 ()
	{
		text.text = "This is my opportunity. I how he didn't see me throwing it. Peharps he doesn't want to be there. "+
					"He is probably thinking about his personal problems. Does he play at home? "+
					"Dude, I think a lot I should act more."+
					"\n\n"+
					"Press F to be free or press R to Return to seeking a way out";
		if (Input.GetKeyDown (KeyCode.R)) {
			currentState = States.throw_mustache;
		}
		if (Input.GetKeyDown (KeyCode.F)) {
			currentState = States.freedom;
		}
	}
	void stateFreedom ()
	{
		text.text = "Our heroe is free to think by himself! But he doesn't know what to do now, anyway congrats for finishing the game.!"+
					"\n\n" +
					"Press P to play again!";
		if (Input.GetKeyDown (KeyCode.P)) {
			currentState = States.initial;
		}
	}
}
