using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreDisplay : MonoBehaviour {

	public List<Text> rollTexts;
	public List<Text> frameTexts;
	public bool autoSetupTexts = true;

	private Text[] texts;

	// Use this for initialization
	void Start ()
	{
		if (autoSetupTexts) {
			SetupTexts ();
		}
	}

	private void SetupTexts ()
	{
		rollTexts = new List<Text> ();
		frameTexts = new List<Text> ();
		texts = this.transform.GetComponentsInChildren<Text> ();
		for (int i = 0; i < 27; i++) {
			if (i % 3 == 2) {
				texts [i].text = "";
				frameTexts.Add (texts [i]);
			}
			else {
				texts [i].text = "";
				rollTexts.Add (texts [i]);
			}
		}
		for (int i = 27; i < 30; i++) {
			texts [i].text = "";
			rollTexts.Add (texts [i]);
		}
		texts [30].text = "";
		frameTexts.Add (texts [30]);
	}

	public void FillRolls (IList<int> rolls)
	{
		string scoresStrings = FormatRolls(rolls);
		for (int i = 0;i<scoresStrings.Length; i++) {
			rollTexts[i].text = scoresStrings[i].ToString();
		}
	}

	public void FillFrames (IList<int> frames)
	{
		for (int i = 0;i<frames.Count; i++) {
			frameTexts[i].text = frames[i].ToString();
		}
	}

	public static string FormatRolls (IList<int> rolls)
	{
		string output = "";
		//code here
		return output;
	}
}
