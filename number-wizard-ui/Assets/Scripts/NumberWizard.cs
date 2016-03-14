using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class NumberWizard : MonoBehaviour {
	int max;
	int min;
	int guess;

	int guesses;

	public int maxGuesses = 10;

	public Text txt_guess;
	public Text txt_guesses;


	// Use this for initialization
	void Start () {
		max = 1000;
		min = 1;
		guess = Random.Range(1, max + min);
		max++;
		guesses = 1;
		txt_guess.text = guess + "?";
	}

	public void NextGuess ()
	{
		if (guesses >= maxGuesses) {
			SceneManager.LoadScene ("Win");			
		} else {
			if (guesses%3==0)
				guess = Random.Range(min, max);
			else
				guess = (max + min) / 2;
			guesses++;

			txt_guess.text = guess + "?";
			txt_guesses.text = "I've tried " + guesses + ", ok...";
		}
	}

	public void guessHigher ()
	{
			min = guess;
			NextGuess();		
	}
	public void guessLower ()
	{
			max = guess;
			NextGuess();
	}
}
