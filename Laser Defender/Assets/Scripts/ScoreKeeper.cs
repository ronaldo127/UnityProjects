using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    private int score = 0;

	// Use this for initialization
	void Start () {
        Reset();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Score(int points)
    {
        this.score += points;
        this.GetComponent<Text>().text = "Score = " + this.score;
    }

    public void Reset()
    {
        this.score = 0;
        this.Score(0);
    }
}
