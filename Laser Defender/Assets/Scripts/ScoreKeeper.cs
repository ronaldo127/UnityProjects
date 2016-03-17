using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public static int score = 0;
    

	// Use this for initialization
	void Start () {
        Reset();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Score(int points)
    {
        score += points;
        this.GetComponent<Text>().text = "Score = " + score;
    }

    public static void Reset()
    {
        score = 0;
    }
}
