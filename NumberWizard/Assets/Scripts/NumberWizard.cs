using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour {

	int max;
	int min;
	int guess;

	// Use this for initialization
	void Start () {
		max = 1000;
		min = 1;
		guess = 500;

		print ("Welcome to Number Wizard");
		print ("Pick a number in your head, but don't tell me!");

		print ("It has to be between "+min+" and "+max);
		print ("Is the number equal to "+guess+"?");
		print ("Press up for higher, down for lower and return for equal");

		max++;

	}

	public void NextGuess(){
		guess = (max + min) / 2;
		print ("Is the number equal to "+guess+"?");
	}

	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			min = guess;
			NextGuess();
		} else

		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			max = guess;
			NextGuess();
		} else
		if (Input.GetKeyDown (KeyCode.Return)) {
			print ("I won!");
			Start();
		}
	}
}
